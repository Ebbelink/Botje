using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using System.Text.Json;

namespace Botje.Mtg.ScryfallClient.Cache;

internal class CardCache : ICardCache
{
    public List<Card> Cache { get; private set; } = new List<Card>();

    public IEnumerable<Card> GetCards()
    {
        return Cache;
    }

    public void InitializeCache(List<Card> cards)
    {
        if (cards != null)
            Cache.RemoveAll(_ => true);
        Cache.AddRange(cards);
    }

    public void InitializeCache(string pathToFile)
    {
        var cards = ParseFromFile(pathToFile);

        InitializeCache(cards);
    }

    public static List<Card>? ParseFromFile(string pathToFile)
    {
        return ParseFromJson(File.ReadAllText(pathToFile));
    }

    public static List<Card>? ParseFromJson(string json)
    {
        return JsonSerializer.Deserialize<List<Card>>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));
    }
}
