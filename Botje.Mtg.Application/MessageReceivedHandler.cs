using System.Linq;
using Botje.Mtg.ScryfallClient;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using Microsoft.Extensions.Logging;
using Slack.Client;
using Slack.Dto.Events;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botje.Mtg.Application;

public class MessageReceivedHandler
{
    private readonly IScryfallClient _scryfallClient;
    private readonly ISlackClient _slackClient;

    private readonly static JsonSerializerOptions _jsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
    };

    public MessageReceivedHandler(IScryfallClient scryfallClient, ISlackClient slackClient)
    {
        _scryfallClient = scryfallClient;
        _slackClient = slackClient;
    }

    public async Task Handle(Event messageContents)
    {
        IEnumerable<string>? matchedCardNameQueries = GetCardNamesWithinSquareBrackets(messageContents.Text);

        IEnumerable<Task<CardsSearchResponse>>? queryTasks = matchedCardNameQueries
                .Select(name => _scryfallClient
                    .CardSearch(new CardsSearchQueryParameters(name)));

        CardsSearchResponse[]? foundCards = await Task.WhenAll(queryTasks);

        IEnumerable<Card>? uniqueCards = foundCards
                .SelectMany(card => card.Data)
                .DistinctBy(card => card.Name);

        // TIME TO RESPOND!
        var responseMessage = new FoundCardsSlackMessage(messageContents.Channel, messageContents.Timestamp);
        foreach (var card in uniqueCards)
        {
            responseMessage.AddCard(card);
        }

        Console.WriteLine($"request message: {JsonSerializer.Serialize(responseMessage, _jsonSerializerOptions)}");

        var result = await _slackClient.PostMessage(responseMessage);
        Console.WriteLine($"response content: {result.Content}");
    }

    public static IEnumerable<string> GetCardNamesWithinSquareBrackets(string input)
    {
        Regex bracketNameMatcher = new Regex(@"\[\[(.*?)\]\]");

        MatchCollection matchedNames = bracketNameMatcher.Matches(input);
        return matchedNames.Select(m => m.Groups[1].Value) ?? new List<string>();
    }

}