using System.Text.Json.Serialization;

namespace Slack.Client.Dtos;

public class CardSection : Section
{
    public CardSection(string name, int multiverseId, string imgUrl, string setName, Dictionary<string, string> legalities)
    {
        CardName = name;
        Type = "section";
        //Text = new() { Type = FieldType.mrkdwn, Text = $"Found:\n*{name}* - {multiverseId}" };
        Accessory = new() { Type = FieldType.image, ImageUrl = imgUrl, AltText = name };
        Fields = new List<Field>()
        {
            new Field() { Type = FieldType.mrkdwn, Text = $"*Legality:*\n\n {string.Join("\n", legalities.Select(l => $"{l.Key}-{l.Value}"))}" },
            new Field() { Type = FieldType.mrkdwn, Text = $"*Set:*\n\n{setName}" }
        };
    }

    [JsonIgnore]
    public string CardName { get; set; }
}
