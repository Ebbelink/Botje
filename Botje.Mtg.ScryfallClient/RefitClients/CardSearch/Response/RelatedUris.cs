using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class RelatedUris
{
    public string Gatherer { get; set; }
    [JsonPropertyName("tcgplayer_infinite_articles")]
    public string TcgplayerInfiniteArticles { get; set; }
    [JsonPropertyName("tcgplayer_infinite_decks")]
    public string TcgplayerInfiniteDecks { get; set; }
    public string EdhRec { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.