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

        string expectedJson = @"{""text"":""Wulfgar of Icewind Dale"",""channel"":""CHANNEL"",""thread_ts"":""" + expectedTimestamp + @""",""blocks"":[{""Type"":""section"",""Accessory"":{""Type"":""image"",""image_url"":""www.ebbelink.com/Wulfgar of Icewind Dale"",""alt_text"":""Wulfgar of Icewind Dale""},""Fields"":[{""Text"":""*Legality:*\n\n standard-not_legal\nfuture-not_legal\nhistoric-not_legal\ngladiator-not_legal\npioneer-not_legal\nexplorer-not_legal\nmodern-not_legal\nlegacy-legal\npauper-not_legal\nvintage-legal\npenny-not_legal\ncommander-legal\nbrawl-not_legal\nhistoricbrawl-not_legal\nalchemy-not_legal\npaupercommander-not_legal\nduel-legal\noldschool-not_legal\npremodern-not_legal"",""Type"":""mrkdwn""},{""Text"":""*Set:*\n\nMidnight hunt"",""Type"":""mrkdwn""}]},{""Type"":""image"",""Title"":{""Text"":""Wulfgar of Icewind Dale"",""Type"":""plain_text""},""image_url"":""www.ebbelink.com/Wulfgar of Icewind Dale"",""alt_text"":""Wulfgar of Icewind Dale - Midnight hunt""}],""reply_broadcast"":false}";

        string expectedChannel = "CHANNEL";
        bool expectedReplyBroadcast = false;

        string cardName = "Wulfgar of Icewind Dale";
        int cardId = 1234123;
        string cardSet = "Midnight hunt";
        string cardImgUrl = $"www.ebbelink.com/{cardName}";
        Dictionary<string, string> legalities = new Dictionary<string, string>();
        legalities.Add("standard", "not_legal");
        legalities.Add("future", "not_legal");
        legalities.Add("historic", "not_legal");
        legalities.Add("gladiator", "not_legal");
        legalities.Add("pioneer", "not_legal");
        legalities.Add("explorer", "not_legal");
        legalities.Add("modern", "not_legal");
        legalities.Add("legacy", "legal");
        legalities.Add("pauper", "not_legal");
        legalities.Add("vintage", "legal");
        legalities.Add("penny", "not_legal");
        legalities.Add("commander", "legal");
        legalities.Add("brawl", "not_legal");
        legalities.Add("historicbrawl", "not_legal");
        legalities.Add("alchemy", "not_legal");
        legalities.Add("paupercommander", "not_legal");
        legalities.Add("duel", "legal");
        legalities.Add("oldschool", "not_legal");
        legalities.Add("premodern", "not_legal");

        var message = new FoundCardsSlackMessage(expectedChannel, expectedTimestamp, expectedReplyBroadcast);

        message.AddCard(cardName, cardId, cardImgUrl, cardSet, legalities);

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
