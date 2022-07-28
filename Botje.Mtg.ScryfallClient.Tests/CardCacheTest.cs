using Botje.Mtg.ScryfallClient.Cache;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Botje.Mtg.ScryfallClient.Tests
{
    public class CardCacheTest
    {
        [Fact]
        public void VerifyCacheInit()
        {
            // Assign
            var sut = new CardCache();

            // Act
            sut.InitializeCache("./scryfall-test-exrept.json");


            // Assert
            sut.Cache.Count.Should().Be(10);
            sut.Cache[0].Id.Should().Be("ff954f7c-3778-4650-9d4f-48beb6e4fda0");
            sut.Cache[0].CardmarketId.Should().Be(282034);
            sut.Cache[0].Name.Should().Be("Arashin Sovereign");
            sut.Cache[0].ManaCost.Should().Be("{5}{G}{W}");
            sut.Cache[0].SetName.Should().Be("Dragons of Tarkir Promos");
            sut.Cache[0].Rarity.Should().Be("rare");
            sut.Cache[0].FlavorText.Should().Be("Dromoka dragons foster trust among their subjects, while the other clans must spend their time quelling rebellion.");

            sut.Cache[1].Id.Should().Be("ff971ba7-68b8-482a-9cb1-741f6893550c");
            sut.Cache[1].Name.Should().Be("Jadar, Ghoulcaller of Nephalia");
            sut.Cache[1].ReleasedAt.Should().Be("2021-09-24");
            sut.Cache[1].Uri.Should().Be("https://api.scryfall.com/cards/ff971ba7-68b8-482a-9cb1-741f6893550c");
            sut.Cache[1].ScryfallUri.Should().Be("https://scryfall.com/card/mid/108/jadar-ghoulcaller-of-nephalia?utm_source=api");
            sut.Cache[1].ImageUris.Small.Should().Be("https://c1.scryfall.com/file/scryfall-cards/small/front/f/f/ff971ba7-68b8-482a-9cb1-741f6893550c.jpg?1634349933");
            sut.Cache[1].ImageUris.Normal.Should().Be("https://c1.scryfall.com/file/scryfall-cards/normal/front/f/f/ff971ba7-68b8-482a-9cb1-741f6893550c.jpg?1634349933");
            sut.Cache[1].ImageUris.Large.Should().Be("https://c1.scryfall.com/file/scryfall-cards/large/front/f/f/ff971ba7-68b8-482a-9cb1-741f6893550c.jpg?1634349933");
            sut.Cache[1].ImageUris.Png.Should().Be("https://c1.scryfall.com/file/scryfall-cards/png/front/f/f/ff971ba7-68b8-482a-9cb1-741f6893550c.png?1634349933");
            sut.Cache[1].ImageUris.ArtCrop.Should().Be("https://c1.scryfall.com/file/scryfall-cards/art_crop/front/f/f/ff971ba7-68b8-482a-9cb1-741f6893550c.jpg?1634349933");
            sut.Cache[1].ImageUris.BorderCrop.Should().Be("https://c1.scryfall.com/file/scryfall-cards/border_crop/front/f/f/ff971ba7-68b8-482a-9cb1-741f6893550c.jpg?1634349933");
            sut.Cache[1].ManaCost.Should().Be("{1}{B}");
            sut.Cache[1].Cmc.Should().Be(2.0);
            sut.Cache[1].TypeLine.Should().Be("Legendary Creature — Human Wizard");
            sut.Cache[1].OracleText.Should().Be("At the beginning of your end step, if you control no creatures with decayed, create a 2/2 black Zombie creature token with decayed. (It can't block. When it attacks, sacrifice it at end of combat.)");
            sut.Cache[1].Power.Should().Be("1");
            sut.Cache[1].Toughness.Should().Be("1");
            sut.Cache[1].Colors.Should().Contain("B");
            sut.Cache[1].ColorIdentity.Should().Contain("B");
            sut.Cache[1].Legalities.Standard.Should().Be("legal");
            sut.Cache[1].Legalities.Future.Should().Be("legal");
            sut.Cache[1].Legalities.Historic.Should().Be("legal");
            sut.Cache[1].Legalities.Gladiator.Should().Be("legal");
            sut.Cache[1].Legalities.Pioneer.Should().Be("legal");
            sut.Cache[1].Legalities.Explorer.Should().Be("legal");
            sut.Cache[1].Legalities.Modern.Should().Be("legal");
            sut.Cache[1].Legalities.Legacy.Should().Be("legal");
            sut.Cache[1].Legalities.Pauper.Should().Be("not_legal");
            sut.Cache[1].Legalities.Vintage.Should().Be("legal");
            sut.Cache[1].Legalities.Penny.Should().Be("not_legal");
            sut.Cache[1].Legalities.Commander.Should().Be("legal");
            sut.Cache[1].Legalities.Brawl.Should().Be("legal");
            sut.Cache[1].Legalities.HistoricBrawl.Should().Be("legal");
            sut.Cache[1].Legalities.Alchemy.Should().Be("legal");
            sut.Cache[1].Legalities.PauperCommander.Should().Be("not_legal");
            sut.Cache[1].Legalities.Duel.Should().Be("legal");
            sut.Cache[1].Legalities.Oldschool.Should().Be("not_legal");
            sut.Cache[1].Legalities.Premodern.Should().Be("not_legal");
            sut.Cache[1].SetName.Should().Be("Innistrad: Midnight Hunt");
            sut.Cache[1].SetUri.Should().Be("https://api.scryfall.com/sets/44b8eb8f-fa23-401a-98b5-1fbb9871128e");
            sut.Cache[1].SetSearchUri.Should().Be("https://api.scryfall.com/cards/search?order=set\u0026q=e%3Amid\u0026unique=prints");
            sut.Cache[1].ScryfallSetUri.Should().Be("https://scryfall.com/sets/mid?utm_source=api");
            sut.Cache[1].RulingsUri.Should().Be("https://api.scryfall.com/cards/ff971ba7-68b8-482a-9cb1-741f6893550c/rulings");
            sut.Cache[1].PrintsSearchUri.Should().Be("https://api.scryfall.com/cards/search?order=released\u0026q=oracleid%3Afb3defc0-c93a-4423-9ff9-c399f8a8ef1f\u0026unique=prints");
            sut.Cache[1].Digital.Should().Be(false);
            sut.Cache[1].Rarity.Should().Be("rare");
            sut.Cache[1].FlavorText.Should().Be("\"Rise, my pretty thing. Why rot in the river when you can serve at my bidding?\"");
            sut.Cache[1].Artist.Should().Be("Yongjae Choi");
            sut.Cache[1].FrameEffects.Should().Contain("legendary");
            sut.Cache[1].Prices.Usd.Should().Be("1.91");
            sut.Cache[1].Prices.UsdFoil.Should().Be("1.66");
            sut.Cache[1].Prices.UsdEtched.Should().Be(null);
            sut.Cache[1].Prices.Eur.Should().Be("1.33");
            sut.Cache[1].Prices.EurFoil.Should().Be("2.00");
            sut.Cache[1].Prices.Tix.Should().Be("0.02");
        }

        [Fact]
        public void VerifyCacheReInit()
        {
            // Assign
            var sut = new CardCache();

            // Act
            sut.InitializeCache("./scryfall-test-exrept.json");
            sut.InitializeCache(new List<Card>());

            // Assert
            sut.Cache.Count.Should().Be(0);
        }
    }
}
