using AppTracker.Services;

namespace AppTracker;

public partial class SettingsForm : Form
{
    private readonly AppTrackerService _appTracker;

    public SettingsForm(AppTrackerService appTracker)
    {
        _appTracker = appTracker;
        InitializeComponent();
        LoadSettings();
    }

    private void LoadSettings()
    {
        numPollingInterval.Value = _appTracker.PollingIntervalSeconds;
        chkEnableTimeTracking.Checked = _appTracker.IsTimeTrackingEnabled;
        dtpStartTime.Value = DateTime.Today.Add(_appTracker.StartTime);
        dtpEndTime.Value = DateTime.Today.Add(_appTracker.EndTime);
        ToggleTimePickers();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        _appTracker.PollingIntervalSeconds = (int)numPollingInterval.Value;
        _appTracker.IsTimeTrackingEnabled = chkEnableTimeTracking.Checked;
        _appTracker.StartTime = dtpStartTime.Value.TimeOfDay;
        _appTracker.EndTime = dtpEndTime.Value.TimeOfDay;
        _appTracker.UpdatePollingInterval();
        
        MessageBox.Show("Settings saved successfully!", "Settings", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void chkEnableTimeTracking_CheckedChanged(object sender, EventArgs e)
    {
        ToggleTimePickers();
    }

    private void ToggleTimePickers()
    {
        dtpStartTime.Enabled = chkEnableTimeTracking.Checked;
        dtpEndTime.Enabled = chkEnableTimeTracking.Checked;
        lblStartTime.Enabled = chkEnableTimeTracking.Checked;
        lblEndTime.Enabled = chkEnableTimeTracking.Checked;
    }
}
