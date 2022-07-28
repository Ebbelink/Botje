using System.Text.Json.Serialization;

namespace Botje.Mtg.Api.Dtos.Slack.Events.Messages
{
    public abstract class MessageBase
    {
        public string Type { get; set; }
        public string Channel { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        [JsonPropertyName("ts")]
        public string Timestamp { get; set; }
    }
}
