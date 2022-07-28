using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class ImageUris
{
    public string Small { get; set; }
    public string Normal { get; set; }
    public string Large { get; set; }
    public string Png { get; set; }
    [JsonPropertyName("art_crop")]
    public string ArtCrop { get; set; }
    [JsonPropertyName("border_crop")]
    public string BorderCrop { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.