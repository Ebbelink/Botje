using Botje.Mtg.ScryfallClient.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Botje.Mtg.ScryfallClient.Cache;
using Botje.Mtg.ScryfallClient.RefitClients;

namespace Botje.Mtg.ScryfallClient;

public static class DependencyInjection
{
    public static IServiceCollection RegisterScryfallClient(
        this IServiceCollection services,
        Uri scryfallUriBaseAddress,
        string cardCachePath)
    {
        services.AddSingleton<ICardCache>(_ =>
        {
            var cache = new CardCache();
            cache.InitializeCache(cardCachePath);
            return cache;
        });

        RegisterScryfallBase(services, scryfallUriBaseAddress);

        return services;
    }

    public static IServiceCollection RegisterScryfallClient(
        this IServiceCollection services,
        Uri scryfallUriBaseAddress,
        string[] cardCachePaths)
    {
        string completeOfflineCardCache = "";
        foreach (var path in cardCachePaths)
        {
            completeOfflineCardCache += File.ReadAllText(path);
        }

        services.AddSingleton<ICardCache>(_ =>
        {
            var cache = new CardCache();
            var cards = CardCache.ParseFromJson(completeOfflineCardCache);
            cache.InitializeCache(cards);
            return cache;
        });

        RegisterScryfallBase(services, scryfallUriBaseAddress);

        return services;
    }

    private static void RegisterScryfallBase(IServiceCollection services, Uri scryfallUriBaseAddress)
    {
        services
            .AddRefitClient<IScryfallRefitClient>()
            .ConfigureHttpClient(c => c.BaseAddress = scryfallUriBaseAddress);
        services.AddScoped<IScryfallClient, ScryfallRefitClientWrapper>()
            .Decorate<IScryfallClient, ScryfallClientCacheDecorator>()
            .Decorate<IScryfallClient, ScryfallClientLogDecorator>();
    }
}
