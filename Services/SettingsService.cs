using System.Text.Json;
using AppTracker.Models;

namespace AppTracker.Services;

public class SettingsService
{
    private readonly string _settingsPath;

    public SettingsService()
    {
        var appFolder = AppDomain.CurrentDomain.BaseDirectory;
        _settingsPath = Path.Combine(appFolder, "settings.json");
    }

    public AppSettings LoadSettings()
    {
        try
        {
            if (File.Exists(_settingsPath))
            {
                var json = File.ReadAllText(_settingsPath);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                return settings ?? new AppSettings();
            }
        }
        catch (Exception ex)
        {
            // Log the error (in a real app, use proper logging)
            Console.WriteLine($"Error loading settings: {ex.Message}");
        }

        return new AppSettings();
    }

    public void SaveSettings(AppSettings settings)
    {
        try
        {
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_settingsPath, json);
        }
        catch (Exception ex)
        {
            // Log the error (in a real app, use proper logging)
            Console.WriteLine($"Error saving settings: {ex.Message}");
        }
    }
}
