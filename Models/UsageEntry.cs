using System.ComponentModel.DataAnnotations;

namespace AppTracker.Models;

public class UsageEntry
{
    [Key]
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public string ApplicationName { get; set; } = string.Empty;
    
    public string WindowTitle { get; set; } = string.Empty;
    
    public string ProcessName { get; set; } = string.Empty;
    
    public int DurationSeconds { get; set; }
}

public class DailySummary
{
    public string ApplicationName { get; set; } = string.Empty;
    
    public TimeSpan TotalTime { get; set; }
    
    public int SessionCount { get; set; }
    
    public DateTime Date { get; set; }
}
