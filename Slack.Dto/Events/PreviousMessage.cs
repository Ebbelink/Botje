using System.Text.Json.Serialization;

namespace Slack.Dto.Events;

public class PreviousMessage
{
    [JsonConstructor]
    public PreviousMessage(
        string clientMsgId,
        string type,
        string text,
        string user,
        string timestamp,
        string team,
        List<Block> blocks
    )
    {
        ClientMsgId = clientMsgId;
        Type = type;
        Text = text;
        User = user;
        Timestamp = timestamp;
        Team = team;
        Blocks = blocks;
    }

    [JsonPropertyName("client_msg_id")]
    public string ClientMsgId { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("text")]
    public string Text { get; init; }

    [JsonPropertyName("user")]
    public string User { get; init; }

    [JsonPropertyName("ts")]
    public string Timestamp { get; init; }

    [JsonPropertyName("team")]
    public string Team { get; init; }

    [JsonPropertyName("blocks")]
    public List<Block> Blocks { get; init; }
}