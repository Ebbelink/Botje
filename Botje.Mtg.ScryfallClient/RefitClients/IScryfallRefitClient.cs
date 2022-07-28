using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using Refit;

namespace Botje.Mtg.ScryfallClient.RefitClients;

public interface IScryfallRefitClient
{
    [Get("/cards/search")]
    Task<CardsSearchResponse> CardSearch(CardsSearchQueryParameters parameters);
}
