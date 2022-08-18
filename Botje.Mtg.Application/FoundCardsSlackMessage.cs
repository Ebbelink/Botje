using Slack.Client;
using Slack.Client.Dtos;
using System.Text;
using System.Text.Json.Serialization;

namespace Botje.Mtg.Application;

public class FoundCardsSlackMessage : PostMessage
{
    public FoundCardsSlackMessage(string channel,
                       string? threadTimestamp = null,
                       bool? replyBroadcast = null)
        : base(channel, threadTimestamp, new List<Section>(), null, replyBroadcast)
    {
    }

    //REQUIRED
    [JsonPropertyName("text")]
    public new string? Text
    {
        get
        {
            return string.Join(", ", Blocks?.Where(b => b.GetType() == typeof(CardSection)).Select(b => (b as CardSection).CardName));
        }
    }

    public void AddCard(string name, int multiverseId, string imgUrl, string setName, Dictionary<string, string> legalities)
    {
        CardSection cardSection = new(name, multiverseId, imgUrl, setName, legalities);
        ImageSection imageSection = new(name, imgUrl, name + " - " + setName);

        Blocks.Add(cardSection);
        Blocks.Add(imageSection);
    }
}
