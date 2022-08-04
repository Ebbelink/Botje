using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using Xunit;

namespace Logger.AzureTableStorage.Tests;

public class TableStorageLoggerSetupTests
{
    [Fact]
    public void VerifyIfDependenciesAreRegistered()
    {
        //ILogger, TableStorageLogger
        ServiceCollection services = new();
        TableStorageLoggerSetup.AddTableStorageLogger(services);

        var foundServices = services.Where(s => s.ServiceType == typeof(ILogger) && s.ImplementationType == typeof(TableStorageLogger));

        foundServices.Should().HaveCount(1);
    }

    [Fact]
    public void VerifyIfCredentialsAreSetCorrectly()
    {
        string expectedAccountName = "KEY";
        string expectedKey = "SECRET";

        TableStorageLoggerSetup.UseTableStorageLogger(null, expectedAccountName, expectedKey);

        TableStorageLoggerSetup.StorageAccountName.Should().Be(expectedAccountName);
        TableStorageLoggerSetup.StorageAccountKey.Should().Be(expectedKey);
    }
}
