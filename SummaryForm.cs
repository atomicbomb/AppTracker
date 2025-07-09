using AppTracker.Models;

namespace AppTracker;

public partial class SummaryForm : Form
{
    private readonly List<DailySummary> _summaries;
    private readonly DateTime _date;

    public SummaryForm(List<DailySummary> summaries, DateTime date)
    {
        _summaries = summaries;
        _date = date;
        InitializeComponent();
        SetupTooltips();
        LoadSummaryData();
    }

    private void SetupTooltips()
    {
        var toolTip = new ToolTip();
        toolTip.SetToolTip(btnPreviousDay, $"View summary for {_date.AddDays(-1):yyyy-MM-dd}");
        toolTip.SetToolTip(btnNextDay, $"View summary for {_date.AddDays(1):yyyy-MM-dd}");
        toolTip.SetToolTip(btnClose, "Close this summary window");
    }

    private void LoadSummaryData()
    {
        lblDate.Text = _date.ToString("dddd, MMMM dd, yyyy");
        
        // Clear existing data
        listViewSummary.Items.Clear();
        
        var totalTime = TimeSpan.Zero;
        
        foreach (var summary in _summaries)
        {
            var item = new ListViewItem(summary.ApplicationName);
            item.SubItems.Add(FormatTimeSpan(summary.TotalTime));
            item.SubItems.Add(summary.SessionCount.ToString());
            
            listViewSummary.Items.Add(item);
            totalTime = totalTime.Add(summary.TotalTime);
        }
        
        // Calculate percentages after we know the total time
        for (int i = 0; i < _summaries.Count; i++)
        {
            var percentage = totalTime.TotalMinutes > 0 
                ? (_summaries[i].TotalTime.TotalMinutes / totalTime.TotalMinutes * 100) 
                : 0;
            listViewSummary.Items[i].SubItems.Add($"{percentage:F1}%");
        }
        
        lblTotalTime.Text = $"Total tracked time: {FormatTimeSpan(totalTime)}";
        
        if (_summaries.Count == 0)
        {
            var noDataItem = new ListViewItem("No data available for this date");
            noDataItem.SubItems.Add("");
            noDataItem.SubItems.Add("");
            noDataItem.SubItems.Add("");
            listViewSummary.Items.Add(noDataItem);
        }
    }

    private static string FormatTimeSpan(TimeSpan timeSpan)
    {
        if (timeSpan.TotalHours >= 1)
        {
            return $"{(int)timeSpan.TotalHours}h {timeSpan.Minutes}m";
        }
        return $"{timeSpan.Minutes}m {timeSpan.Seconds}s";
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnPreviousDay_Click(object sender, EventArgs e)
    {
        // Close this form and let the parent handle showing the previous day
        Tag = _date.AddDays(-1);
        DialogResult = DialogResult.Retry;
        Close();
    }

    private void btnNextDay_Click(object sender, EventArgs e)
    {
        // Close this form and let the parent handle showing the next day
        Tag = _date.AddDays(1);
        DialogResult = DialogResult.Retry;
        Close();
    }
}
