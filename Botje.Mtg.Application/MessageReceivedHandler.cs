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
            responseMessage.AddCard(card);
        }

        //JsonSerializerOptions options = new()
        //{
        //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        //    Converters = {
        //        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        //    }
        //};
        //string json = JsonSerializer.Serialize(responseMessage, options);


        var result = await _slackClient.PostMessage(responseMessage);
        Console.WriteLine(result.Content);
    }

    public static IEnumerable<string> GetCardNamesWithinSquareBrackets(string input)
    {
        Regex bracketNameMatcher = new Regex(@"\[\[(.*?)\]\]");

        MatchCollection matchedNames = bracketNameMatcher.Matches(input);
        return matchedNames.Select(m => m.Groups[1].Value) ?? new List<string>();
    }

}