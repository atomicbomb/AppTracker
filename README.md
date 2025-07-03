# AppTracker

A Windows application usage tracking tool that runs in the system tray and monitors your daily application usage patterns.

## Features

- **System Tray Application**: Runs minimized in the system tray by default
- **Automatic Tracking**: Monitors currently active applications and window titles
- **Configurable Polling**: Adjustable polling interval (default: 30 seconds, minimum: 5 seconds)
- **Daily Summaries**: View detailed reports of time spent in each application per day
- **SQLite Database**: Stores usage data locally for privacy and offline access
- **Windows API Integration**: Uses native Windows APIs for accurate window detection

## How It Works

1. The application starts minimized to the system tray
2. Every 30 seconds (configurable), it checks the currently active window
3. Logs the application name, window title, and timestamp to a local SQLite database
4. Calculates session durations when switching between applications
5. Provides daily summaries showing total time spent in each application

## Usage

### Running the Application

1. Build and run the application using Visual Studio or `dotnet run`
2. The application will start minimized to the system tray
3. Look for the AppTracker icon in your system tray
4. Right-click the tray icon to access the context menu

### System Tray Menu Options

- **Show**: Opens the main application window
- **Settings**: Configure the polling interval
- **View Today's Summary**: Shows usage summary for the current day
- **Exit**: Stops tracking and closes the application

### Main Window

The main window displays:
- Current active application being tracked
- Current window title
- Last update timestamp
- Buttons to view summaries, open settings, or minimize to tray

### Settings

- **Polling Interval**: Adjust how frequently the application checks for active windows (5-300 seconds)

### Usage Summary

The summary window shows:
- Date of the summary
- List of applications used with total time and session count
- Navigation buttons to view previous/next days
- Total tracked time for the day

## Data Storage

- Usage data is stored in a local SQLite database
- Database location: `%APPDATA%\AppTracker\usage_tracking.db`
- All data remains on your local machine for privacy

## Technical Details

### Requirements

- Windows operating system
- .NET 9.0 or later
- Windows Forms support

### Building

```bash
dotnet restore
dotnet build
dotnet run
```

### Dependencies

- Microsoft.Data.Sqlite: For local database storage
- Windows Forms: For the user interface
- Windows API (user32.dll): For active window detection

## Privacy

- All tracking data is stored locally on your machine
- No data is transmitted over the network
- You have full control over your usage data

## System Requirements

- Windows 10 or later
- .NET 9.0 Windows Desktop Runtime
- Approximately 50MB of disk space for the application and database

## Notes

- The application automatically filters out system processes and very short sessions (< 5 seconds)
- Window title tracking helps distinguish between different activities within the same application
- The application remembers sessions across restarts by saving current session duration before exit
