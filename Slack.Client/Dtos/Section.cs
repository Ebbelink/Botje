using System.Text.Json.Serialization;

namespace Slack.Client.Dtos;

public class Section
{
    public string Type { get; protected set; }
    public Field? Text { get; protected set; }
    public Accessory? Accessory { get; protected set; }
    public ICollection<Field>? Fields { get; protected set; }
    public Field? Title { get; protected set; }
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; protected set; }
    [JsonPropertyName("alt_text")]
    public string? AlternativeText { get; protected set; }
}
