using System.Text.Json.Serialization;

namespace Slack.Dto.Events;

public class Event : Message
{
    [JsonConstructor]
    public Event(string clientMessageId,
            string type,
            string subtype,
            Message message,
            PreviousMessage previousMessage,
            string channel,
            bool hidden,
            string timestamp,
            string eventTimestamp,
            string channelType,

            string text,
            string user,
            string team,
            //List<Attachment> attachments, 
            List<Block> blocks)
        : base(clientMessageId, type, text, user, team, new List<Attachment>(), blocks, timestamp)
    {
        Type = type;
        Subtype = subtype;
        Message = message;
        PreviousMessage = previousMessage;
        Channel = channel;
        Hidden = hidden;
        Timestamp = timestamp;
        EventTimestamp = eventTimestamp;
        ChannelType = channelType;
    }

    [JsonPropertyName("type")]
    public new string Type { get; init; }

    [JsonPropertyName("subtype")]
    public string Subtype { get; init; }

    [JsonPropertyName("message")]
    public Message Message { get; init; }

    [JsonPropertyName("previous_message")]
    public PreviousMessage PreviousMessage { get; init; }

    [JsonPropertyName("channel")]
    public string Channel { get; init; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; init; }

    [JsonPropertyName("ts")]
    public new string Timestamp { get; init; }

    [JsonPropertyName("event_ts")]
    public string EventTimestamp { get; init; }

    [JsonPropertyName("channel_type")]
    public string ChannelType { get; init; }
}