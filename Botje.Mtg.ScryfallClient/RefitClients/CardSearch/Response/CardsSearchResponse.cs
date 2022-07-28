using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class CardsSearchResponse
{
    [JsonPropertyName("object")]
    public string ObjectType { get; set; }
    [JsonPropertyName("total_cards")]
    public int TotalCards { get; set; }
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
    public List<Card> Data { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.