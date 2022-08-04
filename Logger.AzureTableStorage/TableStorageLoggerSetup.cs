using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Logger.AzureTableStorage;

/// <summary>
/// Table storage logger dependency injection extension methods
/// </summary>
public static class TableStorageLoggerSetup
{
    /// <summary>
    /// The storage accounts name
    /// </summary>
    public static string StorageAccountName { get; set; }
    /// <summary>
    /// The storage accounts key
    /// </summary>
    public static string StorageAccountKey { get; set; }

    /// <summary>
    /// Add table storage logger<br/>
    /// Registers: <see cref="ILogger"/>
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddTableStorageLogger(this IServiceCollection services)
    {
        services.AddTransient<ILogger, TableStorageLogger>();

        return services;
    }

    /// <summary>
    /// Use the table storage logger
    /// </summary>
    /// <param name="app"></param>
    /// <param name="azureStorageAccountName"></param>
    /// <param name="azureStorageAccountKey"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseTableStorageLogger(this IApplicationBuilder app, string azureStorageAccountName, string azureStorageAccountKey)
    {
        StorageAccountName = azureStorageAccountName;
        StorageAccountKey = azureStorageAccountKey;

        return app;
    }
}
