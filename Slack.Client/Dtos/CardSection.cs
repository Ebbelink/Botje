using Slack.Client.Dtos.BaseTypes;
using Slack.Client.Dtos.Enums;
using System.Text.Json.Serialization;

namespace Slack.Client.Dtos;

public class CardSection : Section
{
    public CardSection(string name, int multiverseId, string setName, Dictionary<string, string> legalities)
    {
        CardName = name;
        Type = "section";
        Text = new() { Type = FieldType.mrkdwn, Text = $"Found:\n*{name}* - {multiverseId}" };
        Fields = new List<Field>()
        {
            new Field() { Type = FieldType.mrkdwn, Text = $"*Set:* {setName}" },
            new Field() { Type = FieldType.mrkdwn, Text = $"*Legality:* {string.Join(" - ", legalities.Select(l => $"{l.Key}"))}" },
        };
    }

    [JsonIgnore]
    public string CardName { get; set; }
}
