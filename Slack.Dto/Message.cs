using System.Text.Json.Serialization;

namespace Slack.Dto;

public class Message
{
    [JsonConstructor]
    public Message(
        string clientMessageId,
        string type,
        string text,
        string user,
        string team,
        List<Attachment> attachments,
        List<Block> blocks,
        string timestamp
    )
    {
        ClientMessageId = clientMessageId;
        Type = type;
        Text = text;
        User = user;
        Team = team;
        Attachments = attachments;
        Blocks = blocks;
        Timestamp = timestamp;
    }

    [JsonPropertyName("client_msg_id")]
    public string ClientMessageId { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("text")]
    public string Text { get; init; }

    [JsonPropertyName("user")]
    public string User { get; init; }

    [JsonPropertyName("team")]
    public string Team { get; init; }

    [JsonPropertyName("attachments")]
    public List<Attachment> Attachments { get; init; }

    [JsonPropertyName("blocks")]
    public List<Block> Blocks { get; init; }

    [JsonPropertyName("ts")]
    public string Timestamp { get; init; }
}