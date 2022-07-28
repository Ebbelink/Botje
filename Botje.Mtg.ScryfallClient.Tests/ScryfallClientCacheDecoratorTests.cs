using AutoFixture;
using Botje.Mtg.ScryfallClient.Cache;
using Botje.Mtg.ScryfallClient.Decorators;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Botje.Mtg.ScryfallClient.Tests
{
    public class ScryfallClientCacheDecoratorTests
    {
        private readonly Fixture _fixture = new();

        [Theory()]
        [InlineData("Scion of the Ur-Dragon", "ScionoftheUrDragon")]
        [InlineData("Surrak Dragonclaw", "SurrakDragonclaw")]
        [InlineData("The Ur-Dragon", "TheUrDragon")]
        [InlineData("Mindscour Dragon", "MindscourDragon")]
        [InlineData("Furnace Dragon", "FurnaceDragon")]
        public async Task CacheShouldRemoveAllWeirdCharactersFromNameInQueryableName(string originalName, string expectedQueryableName)
        {
            // Assign
            var cacheSub = Substitute.For<ICardCache>();

            var cards = new List<Card>()
            {
                _fixture.Build<Card>()
                    .With(c => c.Name, originalName)
                    .Create()
            };

            cacheSub.Cache.Returns(cards);

            // Act
            var card = cacheSub.Cache.Single(c => c.Name == originalName);
            // Assert
            card.Name.Should().Be(originalName);
            card.Name_Queryable.Should().Be(expectedQueryableName);
        }

        [Fact]
        public async Task CardCacheSortsCardsByEurPriceDescendingAlways_Success()
        {
            // Assign
            string searchTerm = "dragon";

            var clientSub = Substitute.For<IScryfallClient>();
            var cacheSub = Substitute.For<ICardCache>();

            List<Tuple<string, string?, string?>> cardResponse = new()
            {
                new("2 Scion of the Ur-Dragon", "60", "80.0"),
                new("1 Surrak Dragonclaw", null, "100.50"),
                new("4 The Ur-Dragon", "50", "40"),
                new("5 Mindscour Dragon", "20", "30"),
                new("3 Furnace Dragon", "70", "0"),
            };

            var cards = cardResponse.Select(currentCardValues =>
                _fixture.Build<Card>()
                    .With(c => c.Name, currentCardValues.Item1)
                    .With(c => c.Prices, new Prices { Eur = currentCardValues.Item2, EurFoil = currentCardValues.Item3 })
                    .Create())
                .ToList();

            cacheSub.Cache.Returns(cards);

            var cacheDecorator = new ScryfallClientCacheDecorator(clientSub, cacheSub);

            // Act
            CardsSearchResponse result = await cacheDecorator.CardSearch(new CardsSearchQueryParameters(searchTerm));

            // Assert
            result.Data.Count().Should().Be(5);
            result.Data[0].Name.Should().Be("1 Surrak Dragonclaw");
            result.Data[0].Prices.Eur.Should().BeNull();
            result.Data[0].Prices.EurFoil.Should().Be("100.50");

            result.Data[1].Name.Should().Be("3 Furnace Dragon");
            result.Data[1].Prices.Eur.Should().Be("70");
            result.Data[1].Prices.EurFoil.Should().Be("0");

            result.Data[2].Name.Should().Be("2 Scion of the Ur-Dragon");
            result.Data[2].Prices.Eur.Should().Be("60");
            result.Data[2].Prices.EurFoil.Should().Be("80.0");

            result.Data[3].Name.Should().Be("4 The Ur-Dragon");
            result.Data[3].Prices.Eur.Should().Be("50");
            result.Data[3].Prices.EurFoil.Should().Be("40");

            result.Data[4].Name.Should().Be("5 Mindscour Dragon");
            result.Data[4].Prices.Eur.Should().Be("20");
            result.Data[4].Prices.EurFoil.Should().Be("30");

            await clientSub.Received(0).CardSearch(Arg.Any<CardsSearchQueryParameters>());
        }

        [Fact]
        public async Task CardCacheFiltersOutUnwantedCards()
        {
            // Assign
            string searchTerm = "Ur dragon";

            var clientSub = Substitute.For<IScryfallClient>();
            var cacheSub = Substitute.For<ICardCache>();

            List<Tuple<string, string?, string?>> cardResponse = new()
            {
                new("2 Scion of the Ur-Dragon", "60", "80.0"),
                new("1 Surrak Dragonclaw", null, "100.50"),
                new("4 The Ur-Dragon", "50", "40"),
                new("7 Nicol-Bolas", "20", "30"),
                new("6 Metalworker", "70", "0"),
                new("5 Mindscour Dragon", "20", "30"),
                new("3 Furnace Dragon", "70", "0"),
            };

            var cards = cardResponse.Select(currentCardValues =>
                _fixture.Build<Card>()
                    .With(c => c.Name, currentCardValues.Item1)
                    .With(c => c.Prices, new Prices { Eur = currentCardValues.Item2, EurFoil = currentCardValues.Item3 })
                    .Create())
                .ToList();

            cacheSub.Cache.Returns(cards);

            var cacheDecorator = new ScryfallClientCacheDecorator(clientSub, cacheSub);

            // Act
            CardsSearchResponse result = await cacheDecorator.CardSearch(new CardsSearchQueryParameters(searchTerm));

            // Assert
            result.Data.Count().Should().Be(3);
            result.Data.Single(c => c.Name == "2 Scion of the Ur-Dragon").Should().NotBeNull();
            result.Data.Single(c => c.Name == "4 The Ur-Dragon").Should().NotBeNull();
            result.Data.Single(c => c.Name == "5 Mindscour Dragon").Should().NotBeNull();

            await clientSub.Received(0).CardSearch(Arg.Any<CardsSearchQueryParameters>());
        }

        [Fact]
        public async Task CacheFallsBackToCallingScryfallApiWhenNoCardIsFoundLocally()
        {
            // Assign
            string searchTerm = "CARD_NOT_FOUND";

            var clientSub = Substitute.For<IScryfallClient>();
            var cacheSub = Substitute.For<ICardCache>();

            clientSub.CardSearch(new CardsSearchQueryParameters(searchTerm))
                .ReturnsForAnyArgs(Task.FromResult(_fixture.Create<CardsSearchResponse>()));

            List<Tuple<string, string?, string?>> cardResponse = new()
            {
                new("2 Scion of the Ur-Dragon", "60", "80.0"),
            };

            var cards = cardResponse.Select(currentCardValues =>
                _fixture.Build<Card>()
                    .With(c => c.Name, currentCardValues.Item1)
                    .With(c => c.Prices, new Prices { Eur = currentCardValues.Item2, EurFoil = currentCardValues.Item3 })
                    .Create())
                .ToList();

            cacheSub.Cache.Returns(cards);

            var cacheDecorator = new ScryfallClientCacheDecorator(clientSub, cacheSub);

            // Act
            CardsSearchResponse result = await cacheDecorator.CardSearch(new CardsSearchQueryParameters(searchTerm));

            // Assert
            await clientSub.Received().CardSearch(Arg.Any<CardsSearchQueryParameters>());
        }
    }
}