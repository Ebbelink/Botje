using System.Text.Json.Serialization;

namespace Botje.Mtg.Api.Dtos.Slack.Events;

public class AppMention
{
    public string Type { get; set; }
    public string User { get; set; }
    public string Text { get; set; }
    [JsonPropertyName("ts")]
    public string Timestamp { get; set; }
    public string Channel { get; set; }
    [JsonPropertyName("event_ts")]
    public string EventTimestamp { get; set; }
}
