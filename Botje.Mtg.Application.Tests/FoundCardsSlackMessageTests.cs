using System.Linq;
using AutoFixture;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
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
    private readonly Fixture _fixture = new();

    [Fact]
    public void CheckIfMultiFacedCardsHaveImagesAdded()
    {
        Card fix = _fixture.Build<Card>()
                .With(c => c.CardFaces, _fixture.Build<CardFace>().CreateMany(2).ToList())
                .Create();

        var requestMessage = new FoundCardsSlackMessage("");
        requestMessage.AddCard(fix);

        foreach (var item in fix.CardFaces)
        {
            var currentblock = requestMessage.Blocks.Single(b => b.Title?.Text == item.Name);

            currentblock.Type.Should().Be("image");
            currentblock.ImageUrl.Should().Be(item.ImageUris.Normal);
            currentblock.AlternativeText.Should().Be(item.Name + " - " + fix.SetName);
        }
    }

    [Fact]
    public void CheckIfCardImageIsAddedIfNotDoubleFaced()
    {
        Card fix = _fixture.Build<Card>()
            .Without(c => c.CardFaces)
            .Create();

        var requestMessage = new FoundCardsSlackMessage("");
        requestMessage.AddCard(fix);

        var currentblock = requestMessage.Blocks.Single(b => b.Title?.Text == fix.Name);

        currentblock.Type.Should().Be("image");
        currentblock.ImageUrl.Should().Be(fix.ImageUris.Normal);
        currentblock.AlternativeText.Should().Be(fix.Name + " - " + fix.SetName);
    }

    //[Fact]
    //public void RequestToScryfallIsAsExpected()
    //{
    //    // Assign
    //    string expectedTimestamp = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");

    //    string expectedJson = @"{""text"":""Wulfgar of Icewind Dale"",""channel"":""CHANNEL"",""thread_ts"":""" + expectedTimestamp + @""",""blocks"":[{""type"":""section"",""text"":{""text"":""Found:\n*Wulfgar of Icewind Dale* - 1234123"",""type"":""mrkdwn""},""fields"":[{""text"":""*Set:* Midnight hunt"",""type"":""mrkdwn""},{""text"":""*Legality:* legacy - vintage - commander - duel"",""type"":""mrkdwn""}]},{""type"":""image"",""title"":{""text"":""Wulfgar of Icewind Dale"",""type"":""plain_text""},""image_url"":""www.ebbelink.com/Wulfgar of Icewind Dale"",""alt_text"":""Wulfgar of Icewind Dale - Midnight hunt""}],""reply_broadcast"":false}";

    //    string expectedChannel = "CHANNEL";
    //    bool expectedReplyBroadcast = false;

    //    string cardName = "Wulfgar of Icewind Dale";
    //    int cardId = 1234123;
    //    string cardSet = "Midnight hunt";
    //    string cardImgUrl = $"www.ebbelink.com/{cardName}";
    //    Dictionary<string, string> legalities = new Dictionary<string, string>();
    //    legalities.Add("legacy", "legal");
    //    legalities.Add("vintage", "legal");
    //    legalities.Add("commander", "legal");
    //    legalities.Add("duel", "legal");

    //    var message = new FoundCardsSlackMessage(expectedChannel, expectedTimestamp, expectedReplyBroadcast);

    //    var card = new Card() { Name = cardName, MultiverseIds = new List<int> { cardId }, SetName = cardSet, Legalities = legalities };

    //    message.AddCard(card);
    //    message.AddCardImage(card);

    //    // Act
    //    JsonSerializerOptions options = new()
    //    {
    //        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    //        Converters = {
    //            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
    //        }
    //    };

    //    string json = JsonSerializer.Serialize<FoundCardsSlackMessage>(message, options);

    //    // Assert
    //    json.Should().Be(expectedJson);
    //}
}
