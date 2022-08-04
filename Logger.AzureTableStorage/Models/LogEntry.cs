using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Logger.AzureTableStorage.Models;

internal class LogEntry : TableEntity
{
    public LogEntry()
    {
        LogDateTimeUtc = DateTime.UtcNow;
    }

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
