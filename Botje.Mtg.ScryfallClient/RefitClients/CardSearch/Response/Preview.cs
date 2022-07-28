using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Preview
{
    public string source { get; set; }
    [JsonPropertyName("source_uri")]
    public string SourceUri { get; set; }
    [JsonPropertyName("previewed_at")]
    public string PreviewedAt { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.