using AppTracker.Services;
using AppTracker.Models;

namespace AppTracker;

public partial class MainForm : Form
{
    private readonly AppTrackerService _appTracker;
    private NotifyIcon? _notifyIcon;
    private ContextMenuStrip? _contextMenu;
    private bool _isMinimizedToTray = false;

    public MainForm(AppTrackerService appTracker)
    {
        _appTracker = appTracker;
        InitializeComponent();
        InitializeSystemTray();
        SetupEventHandlers();
        
        // Start minimized to tray
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
        _isMinimizedToTray = true;
        
        // Start tracking automatically
        _appTracker.StartTracking();
    }

    private void InitializeSystemTray()
    {
        // Create context menu
        _contextMenu = new ContextMenuStrip();
        _contextMenu.Items.Add("Show", null, ShowApplication);
        _contextMenu.Items.Add("Settings", null, ShowSettings);
        _contextMenu.Items.Add("-"); // Separator
        _contextMenu.Items.Add("View Today's Summary", null, ShowTodaysSummary);
        _contextMenu.Items.Add("-"); // Separator
        _contextMenu.Items.Add("Exit", null, ExitApplication);

        // Create notify icon
        _notifyIcon = new NotifyIcon
        {
            Icon = SystemIcons.Application,
            Text = "AppTracker - Monitoring application usage",
            Visible = true,
            ContextMenuStrip = _contextMenu
        };

        _notifyIcon.DoubleClick += ShowApplication;
    }

    private void SetupEventHandlers()
    {
        _appTracker.StatusChanged += OnStatusChanged;
        _appTracker.NewEntryLogged += OnNewEntryLogged;
        
        // Handle form events
        Resize += MainForm_Resize;
        FormClosing += MainForm_FormClosing;
    }

    private void OnStatusChanged(object? sender, string status)
    {
        if (InvokeRequired)
        {
            Invoke(() => OnStatusChanged(sender, status));
            return;
        }

        lblStatus.Text = status;
		if (_notifyIcon != null)
		{
			// NotifyIcon.Text must not exceed 127 characters
			string text = $"AppTracker - {status}";
			if (text.Length > 127)
			{
				text = text.Substring(0, 127);
			}
			
			_notifyIcon.Text = text;
		}
    }

    private void OnNewEntryLogged(object? sender, UsageEntry entry)
    {
        if (InvokeRequired)
        {
            Invoke(() => OnNewEntryLogged(sender, entry));
            return;
        }

        // Update current activity display
        lblCurrentApp.Text = entry.ApplicationName;
        lblCurrentWindow.Text = entry.WindowTitle;
        lblLastUpdate.Text = entry.Timestamp.ToString("HH:mm:ss");
    }

    private void MainForm_Resize(object? sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            ShowInTaskbar = false;
            _isMinimizedToTray = true;
        }
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            MinimizeToTray();
        }
    }

    private void MinimizeToTray()
    {
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
        _isMinimizedToTray = true;
    }

    private void ShowApplication(object? sender, EventArgs e)
    {
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        _isMinimizedToTray = false;
        BringToFront();
        Activate();
    }

    private void ShowSettings(object? sender, EventArgs e)
    {
        using var settingsForm = new SettingsForm(_appTracker);
        settingsForm.ShowDialog(this);
    }

    private async void ShowTodaysSummary(object? sender, EventArgs e)
    {
        await ShowSummaryForDate(DateTime.Today);
    }

    private async Task ShowSummaryForDate(DateTime date)
    {
        try
        {
            DateTime currentDate = date;
            DialogResult result;
            
            do
            {
                var summary = await _appTracker.GetDailySummaryAsync(currentDate);
                using var summaryForm = new SummaryForm(summary, currentDate);
                result = summaryForm.ShowDialog(this);
                
                // Check if user clicked Previous Day or Next Day
                if (result == DialogResult.Retry && summaryForm.Tag is DateTime newDate)
                {
                    currentDate = newDate;
                }
            } 
            while (result == DialogResult.Retry);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading summary: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ExitApplication(object? sender, EventArgs e)
    {
        _appTracker.StopTracking();
        if (_notifyIcon != null)
            _notifyIcon.Visible = false;
        Application.Exit();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _notifyIcon?.Dispose();
            _contextMenu?.Dispose();
            _appTracker?.Dispose();
        }
        base.Dispose(disposing);
    }

    public async Task ShowSummaryForSpecificDate(DateTime date)
    {
        await ShowSummaryForDate(date);
    }

    private void btnViewSummary_Click(object sender, EventArgs e)
    {
        ShowTodaysSummary(sender, e);
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        ShowSettings(sender, e);
    }

    private void btnMinimize_Click(object sender, EventArgs e)
    {
        MinimizeToTray();
    }
}
