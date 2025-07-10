namespace AppTracker.Models;

public class AppSettings
{
    public int PollingIntervalSeconds { get; set; } = 30;
    public bool IsTimeTrackingEnabled { get; set; } = false;
    public TimeSpan StartTime { get; set; } = new(9, 0, 0); // 9:00 AM
    public TimeSpan EndTime { get; set; } = new(17, 30, 0); // 5:30 PM
}
