using Botje.Mtg.ScryfallClient.RefitClients;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;

namespace Botje.Mtg.ScryfallClient;

internal class ScryfallRefitClientWrapper : IScryfallClient
{
    private readonly IScryfallRefitClient _scryfallRefitClient;

    public ScryfallRefitClientWrapper(IScryfallRefitClient scryfallRefitClient)
    {
        _scryfallRefitClient = scryfallRefitClient;
    }

    public Task<CardsSearchResponse> CardSearch(CardsSearchQueryParameters parameters)
    {
        return _scryfallRefitClient.CardSearch(parameters);
    }
}
