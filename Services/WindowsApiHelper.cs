using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace AppTracker.Services;

public static class WindowsApiHelper
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

    public static (string WindowTitle, string ProcessName, string ApplicationName) GetActiveWindowInfo()
    {
        try
        {
            var handle = GetForegroundWindow();
            
            if (handle == IntPtr.Zero)
                return ("", "", "");

            // Get window title
            var length = GetWindowTextLength(handle);
            var title = new StringBuilder(length + 1);
            GetWindowText(handle, title, title.Capacity);

            // Get process information
            GetWindowThreadProcessId(handle, out uint processId);
            
            using var process = Process.GetProcessById((int)processId);
            var processName = process.ProcessName;
            var applicationName = GetApplicationName(process);

            return (title.ToString(), processName, applicationName);
        }
        catch (Exception ex)
        {
            // Log the error (in a real app, use proper logging)
            Console.WriteLine($"Error getting active window info: {ex.Message}");
            return ("", "", "");
        }
    }

    private static string GetApplicationName(Process process)
    {
        try
        {
            // Try to get the main window title first
            if (!string.IsNullOrEmpty(process.MainWindowTitle))
                return process.MainWindowTitle;

            // Try to get from file description
            if (!string.IsNullOrEmpty(process.MainModule?.FileVersionInfo?.FileDescription))
                return process.MainModule.FileVersionInfo.FileDescription;

            // Try to get product name
            if (!string.IsNullOrEmpty(process.MainModule?.FileVersionInfo?.ProductName))
                return process.MainModule.FileVersionInfo.ProductName;

            // Fallback to process name with proper formatting
            return FormatProcessName(process.ProcessName);
        }
        catch
        {
            return FormatProcessName(process.ProcessName);
        }
    }

    private static string FormatProcessName(string processName)
    {
        if (string.IsNullOrEmpty(processName))
            return "Unknown";

        // Capitalize first letter and handle common cases
        return processName switch
        {
            "chrome" => "Google Chrome",
            "firefox" => "Mozilla Firefox",
            "msedge" => "Microsoft Edge",
            "notepad" => "Notepad",
            "explorer" => "Windows Explorer",
            "devenv" => "Visual Studio",
            "Code" => "Visual Studio Code",
            _ => char.ToUpper(processName[0]) + processName[1..].ToLower()
        };
    }
}
