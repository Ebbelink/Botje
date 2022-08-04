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
    //private LogEntryManager _sut;

    //public LogEntryManagerTests()
    //{
    //    var tableClientSub = Substitute.For<Microsoft.WindowsAzure.Storage.Table.CloudTableClient>();

    //    _sut = new(tableClientSub);
    //}

    //[Fact]
    //public async Task AddTest()
    //{
    //    _sut.Add(new LogEntry());
    //}
}
