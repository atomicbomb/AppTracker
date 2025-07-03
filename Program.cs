using AppTracker.Services;

namespace AppTracker;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // Initialize the application tracker
        var appTracker = new AppTrackerService();
        Application.Run(new MainForm(appTracker));
    }    
}