using FluentAssertions;
using Slack.Client.Dtos;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Botje.Mtg.Application.Tests;

public class FoundCardsSlackMessageTests
{
    [Fact]
    public void Test1()
    {
        string expectedTimestamp = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");

        string expectedJson = @"{""text"":""Wulfgar of Icewind Dale"",""channel"":""CHANNEL"",""thread_ts"":""" + expectedTimestamp + @""",""blocks"":[{""type"":""section"",""text"":{""text"":""Found:\n*Wulfgar of Icewind Dale* - 1234123"",""type"":""mrkdwn""},""fields"":[{""text"":""*Set:* Midnight hunt"",""type"":""mrkdwn""},{""text"":""*Legality:* legacy - vintage - commander - duel"",""type"":""mrkdwn""}]},{""type"":""image"",""title"":{""text"":""Wulfgar of Icewind Dale"",""type"":""plain_text""},""image_url"":""www.ebbelink.com/Wulfgar of Icewind Dale"",""alt_text"":""Wulfgar of Icewind Dale - Midnight hunt""}],""reply_broadcast"":false}";

        string expectedChannel = "CHANNEL";
        bool expectedReplyBroadcast = false;

        string cardName = "Wulfgar of Icewind Dale";
        int cardId = 1234123;
        string cardSet = "Midnight hunt";
        string cardImgUrl = $"www.ebbelink.com/{cardName}";
        Dictionary<string, string> legalities = new Dictionary<string, string>();
        legalities.Add("legacy", "legal");
        legalities.Add("vintage", "legal");
        legalities.Add("commander", "legal");
        legalities.Add("duel", "legal");

        var message = new FoundCardsSlackMessage(expectedChannel, expectedTimestamp, expectedReplyBroadcast);

        message.AddCard(cardName, cardId, cardSet, legalities);
        message.AddImage(cardName, cardImgUrl, cardSet, string.Empty);

        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        string json = JsonSerializer.Serialize<FoundCardsSlackMessage>(message, options);

        json.Should().Be(expectedJson);
    }
}
