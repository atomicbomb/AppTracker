using Microsoft.Data.Sqlite;
using AppTracker.Models;

namespace AppTracker.Services;

public class DatabaseService
{
    private readonly string _connectionString;
    private readonly string _databasePath;

    public DatabaseService()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appFolder = Path.Combine(appDataPath, "AppTracker");
        Directory.CreateDirectory(appFolder);
        
        _databasePath = Path.Combine(appFolder, "usage_tracking.db");
        _connectionString = $"Data Source={_databasePath}";
        
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var createTableCommand = connection.CreateCommand();
        createTableCommand.CommandText = @"
            CREATE TABLE IF NOT EXISTS UsageEntries (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Timestamp DATETIME NOT NULL,
                ApplicationName TEXT NOT NULL,
                WindowTitle TEXT NOT NULL,
                ProcessName TEXT NOT NULL,
                DurationSeconds INTEGER NOT NULL DEFAULT 0
            );

            CREATE INDEX IF NOT EXISTS IX_UsageEntries_Timestamp ON UsageEntries(Timestamp);
            CREATE INDEX IF NOT EXISTS IX_UsageEntries_ApplicationName ON UsageEntries(ApplicationName);
        ";
        
        createTableCommand.ExecuteNonQuery();
    }

    public async Task<int> InsertUsageEntryAsync(UsageEntry entry)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO UsageEntries (Timestamp, ApplicationName, WindowTitle, ProcessName, DurationSeconds)
            VALUES (@timestamp, @appName, @windowTitle, @processName, @duration);
            SELECT last_insert_rowid();
        ";

        command.Parameters.AddWithValue("@timestamp", entry.Timestamp);
        command.Parameters.AddWithValue("@appName", entry.ApplicationName);
        command.Parameters.AddWithValue("@windowTitle", entry.WindowTitle);
        command.Parameters.AddWithValue("@processName", entry.ProcessName);
        command.Parameters.AddWithValue("@duration", entry.DurationSeconds);

        var result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result);
    }

    public async Task<List<DailySummary>> GetDailySummaryAsync(DateTime date)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT 
                ApplicationName,
                SUM(DurationSeconds) as TotalSeconds,
                COUNT(*) as SessionCount
            FROM UsageEntries 
            WHERE DATE(Timestamp) = DATE(@date)
            GROUP BY ApplicationName
            ORDER BY TotalSeconds DESC
        ";

        command.Parameters.AddWithValue("@date", date.Date);

        var summaries = new List<DailySummary>();
        
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            summaries.Add(new DailySummary
            {
                ApplicationName = reader.GetString(0),
                TotalTime = TimeSpan.FromSeconds(reader.GetInt32(1)),
                SessionCount = reader.GetInt32(2),
                Date = date.Date
            });
        }

        return summaries;
    }

    public async Task<List<UsageEntry>> GetUsageEntriesAsync(DateTime startDate, DateTime endDate)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, Timestamp, ApplicationName, WindowTitle, ProcessName, DurationSeconds
            FROM UsageEntries 
            WHERE Timestamp >= @startDate AND Timestamp <= @endDate
            ORDER BY Timestamp DESC
        ";

        command.Parameters.AddWithValue("@startDate", startDate);
        command.Parameters.AddWithValue("@endDate", endDate);

        var entries = new List<UsageEntry>();
        
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            entries.Add(new UsageEntry
            {
                Id = reader.GetInt32(0),
                Timestamp = reader.GetDateTime(1),
                ApplicationName = reader.GetString(2),
                WindowTitle = reader.GetString(3),
                ProcessName = reader.GetString(4),
                DurationSeconds = reader.GetInt32(5)
            });
        }

        return entries;
    }

    public async Task UpdateEntryDurationAsync(int entryId, int durationSeconds)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE UsageEntries 
            SET DurationSeconds = @duration 
            WHERE Id = @id
        ";

        command.Parameters.AddWithValue("@duration", durationSeconds);
        command.Parameters.AddWithValue("@id", entryId);

        await command.ExecuteNonQueryAsync();
    }
}
