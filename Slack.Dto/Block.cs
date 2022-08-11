using System.Text.Json.Serialization;

namespace Slack.Dto;

public class Block
{
    [JsonConstructor]
    public Block(
        string type,
        string blockId,
        List<Element> elements
    )
    {
        Type = type;
        BlockId = blockId;
        Elements = elements;
    }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("block_id")]
    public string BlockId { get; init; }

    [JsonPropertyName("elements")]
    public List<Element> Elements { get; init; }
}