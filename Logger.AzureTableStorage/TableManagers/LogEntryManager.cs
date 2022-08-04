using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger.AzureTableStorage.Models;
using Azure.Data.Tables;
using System.IO;

namespace Logger.AzureTableStorage.TableManagers;

internal class LogEntryManager : ITableDataAccessor<LogEntry>
{
    private readonly TableClient _tableClient;

    public LogEntryManager(TableClient tableClient)
    {
        _tableClient = tableClient;
    }

    public async Task Add(LogEntry entity)
    {
        var result = await _tableClient.AddEntityAsync<LogEntry>(entity);
        // TODO: check if the result of writing away is succesfull. If not we are in quite big trouble
    }
}
