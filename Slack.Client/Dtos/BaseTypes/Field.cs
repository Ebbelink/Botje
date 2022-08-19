using Slack.Client.Dtos.Enums;
using System.Text.Json.Serialization;

namespace Slack.Client.Dtos.BaseTypes;

public class Field
{
    [JsonPropertyName("text")]
    public string Text { get; internal set; }
    [JsonPropertyName("type")]
    public FieldType Type { get; internal set; }
    [JsonPropertyName("emoji")]
    public bool? Emoji { get; internal set; }
}