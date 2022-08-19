using ScryfallResponse = Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using Slack.Client;
using Slack.Client.Dtos;
using Slack.Client.Dtos.BaseTypes;
using Slack.Client.Dtos.Enums;
using System.Text;
using System.Text.Json.Serialization;

namespace Botje.Mtg.Application;

public class FoundCardsSlackMessage : PostMessage
{
    private const string cardmarketSearchBaseAddress = "https://www.cardmarket.com/en/Magic/Products/Search?searchString=";

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

    public void AddCard(string name, int multiverseId, string setName, Dictionary<string, string> legalities)
    {
        CardSection cardSection = new(name, multiverseId, setName, legalities);
        Blocks!.Add(cardSection);
    }

    public void AddImage(string name, string? imgUrl, string setName, string linkToCard)
    {
        if (!string.IsNullOrWhiteSpace(imgUrl))
        {
            ImageSection imageSection = new(name, imgUrl, name + " - " + setName);
            Blocks.Add(imageSection);
        }
        else
        {
            LinkButtonSection linkSection = new("Er lijkt geen plaatje te zijn. Gelukkig zijn er alternatieven:", "Scryfall", linkToCard);
            Blocks.Add(linkSection);
        }
    }

    public void AddCard(ScryfallResponse.Card card)
    {
        var onlyLegalLegalities = card.Legalities.Where(kvp => kvp.Value == "legal").ToDictionary(s => s.Key, e => e.Value);
        AddCard(card.Name, card.MultiverseIds.FirstOrDefault(), card.SetName, onlyLegalLegalities);

        AddImage(card.Name, card.ImageUris?.Normal, card.SetName, card.ScryfallUri);

        var resourceButtons = new MultiButtonSection();
        if (!string.IsNullOrWhiteSpace(card.ScryfallUri))
        {
            resourceButtons.AddButton("Scryfall", card.ScryfallUri);
        }
        if (!string.IsNullOrWhiteSpace(card.PurchaseUris?.Cardmarket))
        {
            resourceButtons.AddButton($"Cardmarket", card.PurchaseUris.Cardmarket);
        }
        else
        {
            string urlEncodedName = System.Net.WebUtility.UrlEncode(card.Name);
            resourceButtons.AddButton($"Cardmarket", cardmarketSearchBaseAddress + urlEncodedName);
        }
        if (!string.IsNullOrWhiteSpace(card.RelatedUris?.EdhRec))
        {
            resourceButtons.AddButton($"EdhRec", card.RelatedUris.EdhRec);
        }
        if (!string.IsNullOrWhiteSpace(card.ScryfallSetUri))
        {
            resourceButtons.AddButton($"Set", card.ScryfallSetUri);
        }
        Blocks!.Add(resourceButtons);
    }
}
