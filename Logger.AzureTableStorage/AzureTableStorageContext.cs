using Logger.AzureTableStorage.Models;
using Logger.AzureTableStorage.TableManagers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Logger.AzureTableStorage;

internal class AzureTableStorageContext
{
    public readonly ITableDataAccessor<LogEntry, LogEntry> LogEntryManager;

    public AzureTableStorageContext(string accountName, string accountKey)
    {
        CloudStorageAccount storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                accountName,
                accountKey),
                true
            );

        // Create the table client.
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

        // Because Azure Table Storage has no built in identity generation we create or own.
        LogEntryManager = new LogEntryManager(tableClient);
    }
}
