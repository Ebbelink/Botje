using Botje.Mtg.ScryfallClient.Cache;
using Botje.Mtg.ScryfallClient.RefitClients;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;

namespace Botje.Mtg.ScryfallClient.Decorators;

internal class ScryfallClientCacheDecorator : IScryfallClient
{
    private readonly IScryfallRefitClient _decorated;
    private readonly ICardCache _cardCache;

    public ScryfallClientCacheDecorator(IScryfallClient decorated, ICardCache cardCache)
    {
        _decorated = decorated;
        _cardCache = cardCache;
    }

    public Task<CardsSearchResponse> CardSearch(CardsSearchQueryParameters parameters)
    {
        string QueryableNameAlphabeticalOnly = CardHelper.RemoveNonAlphabeticalCharactersFromString(parameters.Query);
        var result = _cardCache.Cache
            .Where(card => (card.Name != null)
                && card.Name_Queryable.Contains(QueryableNameAlphabeticalOnly, StringComparison.OrdinalIgnoreCase));

        if (result.Any())
        {
            var orderedResult = result.OrderByDescending(card =>
            {
                double.TryParse(card.Prices.Eur, out double eurPrice);
                double.TryParse(card.Prices.EurFoil, out double eurFoilPrice);

                if (eurPrice <= 0)
                    return eurFoilPrice;
                if (eurFoilPrice <= 0)
                    return eurPrice;

                double lowestPrice = eurPrice < eurFoilPrice ? eurPrice : eurFoilPrice;
                return lowestPrice;
            });

            var cardsToReturn = orderedResult.Skip((10 * parameters.Page ?? 1) - 10).Take(10).ToList();

            return Task.FromResult(new CardsSearchResponse() { Data = cardsToReturn.ToList(), TotalCards = cardsToReturn.Count });
        }

        return _decorated.CardSearch(parameters);
    }
}
