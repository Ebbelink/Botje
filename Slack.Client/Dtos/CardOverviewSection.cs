namespace Slack.Client.Dtos;

public class CardOverviewSection : Section
{
    public CardOverviewSection(IEnumerable<string> cardNames)
    {
        Type = "context";
        Elements = new List<Field>()
        {
            new Field() { Type = FieldType.mrkdwn, Text = $"Found: {string.Join(" - ", cardNames)}" },
        };
    }

    //public string Type { get; set; } = "context";
    public ICollection<Field> Elements { get; set; }
}
