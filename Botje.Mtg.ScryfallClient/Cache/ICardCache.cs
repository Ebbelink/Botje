using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;

namespace Botje.Mtg.ScryfallClient.Cache;

internal interface ICardCache
{
    List<Card> Cache { get; }

    void InitializeCache(List<Card> cards);

    void InitializeCache(string pathToFile);

    IEnumerable<Card> GetCards();
}
