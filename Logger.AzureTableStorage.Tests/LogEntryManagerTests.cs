using FluentAssertions;
using Logger.AzureTableStorage.Models;
using Logger.AzureTableStorage.TableManagers;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Logger.AzureTableStorage.Tests;

public class LogEntryManagerTests
{
    private LogEntryManager _sut;

    public LogEntryManagerTests()
    {
        var tableClientSub = Substitute.For<Microsoft.WindowsAzure.Storage.Table.CloudTableClient>();

        _sut = new(tableClientSub);
    }

    [Fact]
    public async Task AddTest()
    {
        _sut.Add(new LogEntry());
    }

    [Fact]
    public async Task DeleteTest()
    {
        var action = () => _sut.Delete(1);

        await action.Should().ThrowAsync<NotImplementedException>();
    }

    [Fact]
    public async Task GetTest()
    {
        _sut.Get();
    }

    [Fact]
    public async Task GetPredicateTest()
    {
        var action = () => _sut.Get(entry => true);

        await action.Should().ThrowAsync<NotImplementedException>()
            .WithMessage("This method is not yet implemented because the .NET API is not there yet.");

    }

    [Fact]
    public async Task GetByIdTest()
    {
        _sut.Get(1);
    }

    [Fact]
    public async Task UpdateTest()
    {
        var action = () => _sut.Update(new LogEntry());

        await action.Should().ThrowAsync<NotImplementedException>();
    }
}
