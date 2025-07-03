using System.Timers;
using AppTracker.Models;

namespace AppTracker.Services;

public class AppTrackerService
{
    private readonly DatabaseService _databaseService;
    private readonly System.Timers.Timer _pollingTimer;
    private string _currentApplicationName = string.Empty;
    private string _currentWindowTitle = string.Empty;
    private DateTime _currentSessionStart;
    private int _currentEntryId = -1;
    private bool _isTracking = false;

    public int PollingIntervalSeconds { get; set; } = 30;
    
    public event EventHandler<UsageEntry>? NewEntryLogged;
    public event EventHandler<string>? StatusChanged;

    public AppTrackerService()
    {
        _databaseService = new DatabaseService();
        _pollingTimer = new System.Timers.Timer();
        _pollingTimer.Elapsed += OnPollingTimerElapsed;
        UpdatePollingInterval();
    }

    public void StartTracking()
    {
        if (_isTracking) return;

        _isTracking = true;
        _pollingTimer.Start();
        StatusChanged?.Invoke(this, "Tracking started");
        
        // Immediately check current window
        _ = Task.Run(async () => await CheckActiveWindow());
    }

    public void StopTracking()
    {
        if (!_isTracking) return;

        _pollingTimer.Stop();
        
        // Save current session if active
        if (_currentEntryId != -1)
        {
            _ = Task.Run(async () => await SaveCurrentSessionDurationAsync());
        }
        
        _isTracking = false;
        StatusChanged?.Invoke(this, "Tracking stopped");
    }

    public void UpdatePollingInterval()
    {
        _pollingTimer.Interval = PollingIntervalSeconds * 1000;
        if (_isTracking)
        {
            _pollingTimer.Stop();
            _pollingTimer.Start();
        }
    }

    private async void OnPollingTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        await CheckActiveWindow();
    }

    private async Task CheckActiveWindow()
    {
        try
        {
            var (windowTitle, processName, applicationName) = WindowsApiHelper.GetActiveWindowInfo();
            
            // Ignore empty or system windows
            if (string.IsNullOrEmpty(applicationName) || 
                string.IsNullOrEmpty(windowTitle) ||
                IsSystemWindow(processName))
            {
                return;
            }

            // Check if we've switched applications
            if (applicationName != _currentApplicationName || windowTitle != _currentWindowTitle)
            {
                // Save duration of previous session
                if (_currentEntryId != -1)
                {
                    await SaveCurrentSessionDurationAsync();
                }

                // Start new session
                await StartNewSessionAsync(applicationName, windowTitle, processName);
            }
        }
        catch (Exception ex)
        {
            StatusChanged?.Invoke(this, $"Error: {ex.Message}");
        }
    }

    private async Task StartNewSessionAsync(string applicationName, string windowTitle, string processName)
    {
        _currentApplicationName = applicationName;
        _currentWindowTitle = windowTitle;
        _currentSessionStart = DateTime.Now;

        var entry = new UsageEntry
        {
            Timestamp = _currentSessionStart,
            ApplicationName = applicationName,
            WindowTitle = windowTitle,
            ProcessName = processName,
            DurationSeconds = 0 // Will be updated when session ends
        };

        _currentEntryId = await _databaseService.InsertUsageEntryAsync(entry);
        entry.Id = _currentEntryId;
        
        NewEntryLogged?.Invoke(this, entry);
        StatusChanged?.Invoke(this, $"Now tracking: {applicationName}");
    }

    private async Task SaveCurrentSessionDurationAsync()
    {
        if (_currentEntryId == -1) return;

        var duration = (int)(DateTime.Now - _currentSessionStart).TotalSeconds;
        
        // Only save sessions longer than 5 seconds to avoid noise
        if (duration >= 5)
        {
            await _databaseService.UpdateEntryDurationAsync(_currentEntryId, duration);
        }

        _currentEntryId = -1;
    }

    private static bool IsSystemWindow(string processName)
    {
        var systemProcesses = new[] { "dwm", "winlogon", "csrss", "wininit", "services", "lsass", "svchost" };
        return systemProcesses.Contains(processName.ToLower());
    }

    public async Task<List<DailySummary>> GetDailySummaryAsync(DateTime date)
    {
        return await _databaseService.GetDailySummaryAsync(date);
    }

    public async Task<List<UsageEntry>> GetUsageEntriesAsync(DateTime startDate, DateTime endDate)
    {
        return await _databaseService.GetUsageEntriesAsync(startDate, endDate);
    }

    public void Dispose()
    {
        StopTracking();
        _pollingTimer?.Dispose();
    }
}
