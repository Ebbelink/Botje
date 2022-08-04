using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger.AzureTableStorage.Models;
using Azure.Data.Tables;
using System.IO;

namespace Logger.AzureTableStorage.TableManagers;

internal class LogEntryManager : ITableDataAccessor<LogEntry, LogEntry>
{
    private const string _tableName = "LogEntries";
    private readonly TableClient _tableClient;

    public LogEntryManager(TableClient tableClient)
    {
        _tableClient = tableClient;
    }

    public async Task<LogEntry> Add(LogEntry entity)
    {
        var result = await _tableClient.AddEntityAsync<LogEntry>(entity);

        var contentString = new StreamReader(new MemoryStream(result.Content.ToArray())).ReadToEnd();

        return new LogEntry();
    }

}
