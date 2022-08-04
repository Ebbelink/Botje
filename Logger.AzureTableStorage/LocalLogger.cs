using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Logger.AzureTableStorage;

/// <summary>
/// A Azure Table Storage Logger
/// </summary>
public class LocalLogger : ILogger
{
    /// <summary>
    /// Start a logging scope
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <param name="state"></param>
    /// <returns></returns>
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    /// <summary>
    /// Check if a certain logging level is enabled
    /// </summary>
    /// <param name="logLevel"></param>
    /// <returns></returns>
    public bool IsEnabled(LogLevel logLevel)
    {
        // TODO: Really check if it is enabled
        return true;
    }

    /// <summary>
    /// Log a thing
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <param name="logLevel">The <see cref="LogLevel"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="state">The state that </param>
    /// <param name="exception"></param>
    /// <param name="formatter"></param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        Console.WriteLine(Format(state, exception));
    }

    private string Format<TState>(TState state, Exception ex)
    {
        string stateJson = JsonConvert.SerializeObject(state);
        string exJson = JsonConvert.SerializeObject(ex);
        string message = $"{(state != null ? stateJson : string.Empty)}{(ex != null ? $" | {exJson}" : string.Empty)}";

        return message;
    }
}
