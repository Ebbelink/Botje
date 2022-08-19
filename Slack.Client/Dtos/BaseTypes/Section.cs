using System.Text.Json.Serialization;

namespace Slack.Client.Dtos.BaseTypes;

public class Section
{
    public Section() { }
    public Section(string type,
                   Field? text = null,
                   Accessory? accessory = null,
                   ICollection<Field>? fields = null,
                   Field? title = null,
                   string? imageUrl = null,
                   string? alternativeText = null)
    {
        Type = type;
        Text = text;
        Accessory = accessory;
        Fields = fields;
        Title = title;
        ImageUrl = imageUrl;
        AlternativeText = alternativeText;
    }

    [JsonPropertyName("type")]
    public string Type { get; internal set; }
    [JsonPropertyName("text")]
    public Field? Text { get; internal set; }
    [JsonPropertyName("accessory")]
    public Accessory? Accessory { get; internal set; }
    [JsonPropertyName("fields")]
    public ICollection<Field>? Fields { get; internal set; }
    [JsonPropertyName("title")]
    public Field? Title { get; internal set; }
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; internal set; }
    [JsonPropertyName("alt_text")]
    public string? AlternativeText { get; internal set; }

    // Multi buttons
    [JsonPropertyName("elements")]
    public ICollection<Button>? Elements { get; set; }
}
