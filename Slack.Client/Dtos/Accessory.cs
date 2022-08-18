using System.Text.Json.Serialization;

namespace Slack.Client.Dtos;

public class Accessory
{
    public FieldType Type { get; set; }
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }
    [JsonPropertyName("alt_text")]
    public string? AltText { get; set; }

}
