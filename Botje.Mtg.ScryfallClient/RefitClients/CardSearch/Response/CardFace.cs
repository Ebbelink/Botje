using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class CardFace
{
    [JsonPropertyName("object")]
    public string ObjectType { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("mana_cost")]
    public string ManaCost { get; set; }
    [JsonPropertyName("type_line")]
    public string TypeLine { get; set; }
    [JsonPropertyName("oracle_text")]
    public string OracleText { get; set; }
    public string Power { get; set; }
    public string Toughness { get; set; }
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; }
    public string Artist { get; set; }
    [JsonPropertyName("artist_id")]
    public string ArtistId { get; set; }
    [JsonPropertyName("illustration_id")]
    public string IllustrationId { get; set; }
    [JsonPropertyName("flavor_name")]
    public string FlavorName { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.