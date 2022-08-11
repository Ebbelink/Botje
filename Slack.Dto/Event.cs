using System.Text.Json.Serialization;

namespace Slack.Dto;

public class Event
{
    [JsonConstructor]
    public Event(
        string type,
        string subtype,
        Message message,
        PreviousMessage previousMessage,
        string channel,
        bool hidden,
        string timestamp,
        string eventTimestamp,
        string channelType
    )
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
    public string Type { get; init; }

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
    public string Timestamp { get; init; }

    [JsonPropertyName("event_ts")]
    public string EventTimestamp { get; init; }

    [JsonPropertyName("channel_type")]
    public string ChannelType { get; init; }
}