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
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        _appTracker.PollingIntervalSeconds = (int)numPollingInterval.Value;
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
}
