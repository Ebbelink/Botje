using Slack.Client.Dtos.Enums;
using System.Text.Json.Serialization;

namespace Slack.Client.Dtos.BaseTypes;

public class Accessory
{
    [JsonPropertyName("type")]
    public FieldType Type { get; internal set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; internal set; }

    [JsonPropertyName("alt_text")]
    public string? AltText { get; internal set; }

    [JsonPropertyName("text")]
    public Field? Text { get; internal set; }

    [JsonPropertyName("url")]
    public string? Url { get; internal set; }

    [JsonPropertyName("value")]
    public string? Value { get; internal set; }

    [JsonPropertyName("action_id")]
    public string? ActionId{get; internal set;}
}
