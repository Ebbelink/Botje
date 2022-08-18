using System.Linq;
using Botje.Mtg.ScryfallClient;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using Microsoft.Extensions.Logging;
using Slack.Client;
using Slack.Dto.Events;
using System.Text.RegularExpressions;

namespace Botje.Mtg.Application;

public class MessageReceivedHandler
{
    private readonly IScryfallClient _scryfallClient;
    private readonly ILogger _logger;
    private readonly ISlackClient _slackClient;

    public MessageReceivedHandler(IScryfallClient scryfallClient, ILogger logger, ISlackClient slackClient)
    {
        _scryfallClient = scryfallClient;
        _logger = logger;
        _slackClient = slackClient;
    }

    public async Task Handle(Event messageContents)
    {
        IEnumerable<string>? matchedCardNameQueries = GetCardNamesWithinSquareBrackets(messageContents.Text);
        _logger.LogInformation($"Matched card name queries: \n{string.Join(" | ", matchedCardNameQueries)}");

        IEnumerable<Task<CardsSearchResponse>>? queryTasks = matchedCardNameQueries
                .Select(name => _scryfallClient
                    .CardSearch(new CardsSearchQueryParameters(name)));

        CardsSearchResponse[]? foundCards = await Task.WhenAll(queryTasks);

        IEnumerable<Card>? uniqueCards = foundCards
                .SelectMany(card => card.Data)
                .DistinctBy(card => card.Name);

        _logger.LogInformation($"Found {uniqueCards.Count()} unique cards, \n{string.Join(" | ", uniqueCards.Select(card => card.Name))}");

        // TIME TO RESPOND!
        var responseMessage = new FoundCardsSlackMessage(messageContents.Channel, messageContents.Timestamp);
        foreach (var card in uniqueCards)
        {
            responseMessage.AddCard(card.Name, card.MultiverseIds.First(), card.ImageUris.Normal, card.SetName, new Dictionary<string, string>());
        }

        await _slackClient.PostMessage(new FoundCardsSlackMessage(messageContents.Channel, messageContents.Timestamp));

        //// Set the channel and timestamp to respond to a message in a thread
        //Message fullMessage = new Message { Channel = message.Channel, Thread_ts = message.Timestamp }.SetText("Cards found:");
        //foreach (Card distinctCard in distinctCards)
        //{
        //    // Always add the found card name, multiverse id and set name to the message to give feedback on the found cards
        //    fullMessage.Text += $"{distinctCard.Name} - {distinctCard.MultiverseId} - {distinctCard.SetName} \r\n";

        //    try
        //    {
        //        Card cardWithImage = flattenedRawCardList.Where(c => c.Name == distinctCard.Name).GetMostRecentCardWithImage();

        //        fullMessage.AddAttachment(new Attachment("")
        //        {
        //            Title = cardWithImage.Name,
        //            Image_url = cardWithImage.ImageUrl.ToString()
        //        }.AddField(new AttachmentField("Legality",
        //                string.Join(",\n", cardWithImage.Legalities.Select(l => $"*{l.Format}*: {l.LegalityName}")),
        //                true))
        //            .AddField(new AttachmentField("Set",
        //                string.Join(", ", cardWithImage.SetName),
        //                true)));
        //    }
        //    catch (CardWithoutImageException e)
        //    {
        //        _logger.LogError($"{nameof(SlackEventHandler)} | {nameof(EventHandler)} | EXCEPTION {e.Message}");

        //        // Add an attachment to the full message. This attachment is the card info in text format
        //        fullMessage.AddAttachment(new Attachment($"{distinctCard.Name} | {distinctCard.ManaCost}") { }
        //            .AddField(new AttachmentField("Ruletext", distinctCard.Text))
        //            .AddField(new AttachmentField("Type", distinctCard.Type) { Short = true })
        //            .AddField(new AttachmentField("Power", $"{(!string.IsNullOrEmpty(distinctCard.Power) ? $"{distinctCard.Power}/{distinctCard.Toughness}" : distinctCard.Loyalty)}") { Short = true }));
        //    }
        //}
    }

    public static IEnumerable<string> GetCardNamesWithinSquareBrackets(string input)
    {
        Regex bracketNameMatcher = new Regex(@"\[\[(.*?)\]\]");

        MatchCollection matchedNames = bracketNameMatcher.Matches(input);
        return matchedNames.Select(m => m.Groups[1].Value) ?? new List<string>();
    }

}