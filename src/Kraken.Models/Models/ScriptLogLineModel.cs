namespace Kraken.Shared.Models;

public class ScriptLogLineModel
{
    public DateTimeOffset Timestamp { get; set; } = DateTime.UtcNow;
    public LogLevel Level { get; set; } = LogLevel.INFO;
    public string Message { get; set; } = string.Empty;
    public int Line { get; set; }
}

public enum LogLevel
{
    INFO,
    DEBUG,
    WARN,
    ERROR
}