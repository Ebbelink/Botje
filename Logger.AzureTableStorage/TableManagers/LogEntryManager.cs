using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger.AzureTableStorage.Models;
using Logger.AzureTableStorage;

namespace Logger.AzureTableStorage.TableManagers;

internal class LogEntryManager : ITableDataAccessor<LogEntry, LogEntry>
{
    private const string _tableName = "LogEntries";
    private readonly CloudTable _table;

    public LogEntryManager(CloudTableClient tableClient)
    {
        // Get a reference to the tables
        _table = tableClient.GetTableReference(_tableName);

        // Create the CloudTable if it does not exist
        _table.CreateIfNotExistsAsync().GetAwaiter().GetResult();
    }

    public async Task<LogEntry> Add(LogEntry entity)
    {
        TableOperation insertOperation = TableOperation.Insert(entity);

        // Execute the insert operation.
        TableResult insertedResult = await _table.ExecuteAsync(insertOperation);
        LogEntry addedEntity = insertedResult.Result as LogEntry;

        return addedEntity;
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<LogEntry>> Get()
    {
        TableQuery<LogEntry> tableQuery = new TableQuery<LogEntry>();
        TableQuerySegment<LogEntry> IdRangeResult = await _table.ExecuteQuerySegmentedAsync(tableQuery, null);

        return IdRangeResult;
    }

    public Task<IEnumerable<LogEntry>> Get(Func<LogEntry, bool> predicate)
    {
        throw new NotImplementedException("This method is not yet implemented because the .NET API is not there yet.");
    }

    public async Task<LogEntry> Get(int id)
    {
        TableQuery<LogEntry> tableQuery = new TableQuery<LogEntry>();
        var filterCon = TableQuery.GenerateFilterConditionForInt("PartitionKey", QueryComparisons.Equal, id);
        tableQuery.Where(filterCon);

        TableQuerySegment<LogEntry> IdRangeResult = await _table.ExecuteQuerySegmentedAsync(tableQuery, null);

        return IdRangeResult.FirstOrDefault();
    }

    public async Task Update(LogEntry entity)
    {
        throw new NotImplementedException();
    }
}
