using Microsoft.Extensions.DependencyInjection;
using Slack.Client;

namespace Botje.Mtg.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services, string botToken)
    {
        return services
            .AddScoped<MessageReceivedHandler>()
            .AddSlackClient(botToken);
    }
}
