using Azure.Data.Tables;
using Logger.AzureTableStorage.Models;
using Logger.AzureTableStorage.TableManagers;
using System;

namespace Logger.AzureTableStorage;

internal class AzureTableStorageContext
{
    public readonly ITableDataAccessor<LogEntry> LogEntryManager;

    public AzureTableStorageContext(string accountName, string accountKey, Uri storageUrl, string tableName)
    {
        TableServiceClient tableServiceClient = new TableServiceClient(storageUrl, new TableSharedKeyCredential(accountName, accountKey));

        TableClient tableClient = tableServiceClient.GetTableClient(tableName);

        tableClient.CreateIfNotExists();

        LogEntryManager = new LogEntryManager(tableClient);
    }
}
