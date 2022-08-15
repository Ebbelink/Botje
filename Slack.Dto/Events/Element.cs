using System.Text.Json.Serialization;

namespace Slack.Dto.Events;

public class Element
{
    [JsonConstructor]
    public Element(
        string type,
        List<Element> elements,
        string url,
        string text
    )
    {
        Type = type;
        Elements = elements;
        Url = url;
        Text = text;
    }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("elements")]
    public List<Element> Elements { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }

    [JsonPropertyName("text")]
    public string Text { get; init; }
}