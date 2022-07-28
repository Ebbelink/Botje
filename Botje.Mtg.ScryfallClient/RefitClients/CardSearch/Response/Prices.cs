using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Prices
{
    public string Usd { get; set; }
    [JsonPropertyName("usd_foil")]
    public string UsdFoil { get; set; }
    [JsonPropertyName("usd_etched")]
    public object UsdEtched { get; set; }
    public string Eur { get; set; }
    [JsonPropertyName("eur_foil")]
    public string EurFoil { get; set; }
    public string Tix { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.