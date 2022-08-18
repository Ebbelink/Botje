using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Slack.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddSlackClient(this IServiceCollection services, string botToken)
    {
        services.AddRefitClient<ISlackClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://slack.com/api");
                    c.DefaultRequestHeaders.Add("Authorization", "Bearer " + botToken);
                });

        return services;
    }
}
