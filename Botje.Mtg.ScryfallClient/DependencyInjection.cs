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
            var cache =  new CardCache();
            cache.InitializeCache(cardCachePath);
            return cache;
        });

        services
            .AddRefitClient<IScryfallRefitClient>()
            .ConfigureHttpClient(c => c.BaseAddress = scryfallUriBaseAddress);
        services.AddScoped<IScryfallClient, ScryfallRefitClientWrapper>()
            .Decorate<IScryfallClient, ScryfallClientCacheDecorator>()
            .Decorate<IScryfallClient, ScryfallClientLogDecorator>();

        return services;
    }

    //private static IServiceCollection AddPwcInvoiceServiceClient(
    //    this IServiceCollection services, string countryCode, Uri baseUri,
    //    string username, string password, string domain)
    //{
    //    services.AddHttpClient($"PwcInvoicingClient-{countryCode}", client =>
    //    {
    //        client.BaseAddress = baseUri;
    //        client.Timeout = TimeSpan.FromSeconds(30);
    //    })
    //    .AddTypedClient(RestService.For<IInvoicingClient>);

    //    return services;
    //}
}
