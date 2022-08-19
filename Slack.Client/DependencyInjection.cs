using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Slack.Client;

public static class DependencyInjection
{
    public const string SLACK_BASE_ADDRESS = "https://slack.com/api";

    public static IServiceCollection AddSlackClient(this IServiceCollection services, string botToken)
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        services.AddRefitClient<ISlackClient>(new RefitSettings()
                {
                    ContentSerializer = new SystemTextJsonContentSerializer(options),
                })
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://slack.com/api");
                    c.DefaultRequestHeaders.Add("Authorization", "Bearer " + botToken);
                });

        return services;
    }
}
