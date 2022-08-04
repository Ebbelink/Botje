using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Logging;
using System;

namespace Logger.AzureTableStorage.Models;

public class LogEntry : ITableEntity
{
    public LogEntry()
    {
        LogDateTimeUtc = DateTime.UtcNow;
    }

    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; } = default!;
    public ETag ETag { get; set; } = default!;

    public LogLevel LogLevel
    {
        get
        {
            return Enum.Parse<LogLevel>(PartitionKey);
        }
        set
        {
            PartitionKey = value.ToString("F");
        }
    }
    public DateTime LogDateTimeUtc
    {
        get
        {
            return DateTime.Parse(RowKey);
        }
        set
        {
            RowKey = value.ToString("o");
        }
    }
    public EventId EventId { get; set; }
    public string Message { get; set; }
    public bool HasException { get; set; }
    public Exception Exception { get; set; }
}
