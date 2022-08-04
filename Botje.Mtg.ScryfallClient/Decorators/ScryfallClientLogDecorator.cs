using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using Microsoft.Extensions.Logging;

namespace Botje.Mtg.ScryfallClient.Decorators;

internal class ScryfallClientLogDecorator : IScryfallClient
{
    private readonly IScryfallClient _decorated;
    private readonly ILogger _logger;

    public ScryfallClientLogDecorator(IScryfallClient decorated, ILogger logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public async Task<CardsSearchResponse> CardSearch(CardsSearchQueryParameters parameters)
    {
        _logger.LogInformation($"Searching for: {parameters.Query}");

        var result = await _decorated.CardSearch(parameters);

        _logger.LogInformation($"Found {result.TotalCards} cards for {parameters.Query}");

        return result;
    }
}
