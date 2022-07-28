using Botje.Mtg.ScryfallClient.Cache;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace Botje.Mtg.ScryfallClient.Tests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void CheckRegistrations()
        {
            // Assign
            var services = new ServiceCollection();

            // Act
            DependencyInjection.RegisterScryfallClient(services, new Uri("https://www.ebbelink.com"), "path");

            var scryfallClientWrapper = services.SingleOrDefault(s => s.ImplementationType == typeof(ScryfallRefitClientWrapper));
            var cardCache = services.SingleOrDefault(s => s.ServiceType == typeof(ICardCache));

            // Assert
            scryfallClientWrapper.Should().NotBeNull();
            scryfallClientWrapper.Lifetime.Should().Be(ServiceLifetime.Scoped);
            cardCache.Should().NotBeNull();
            cardCache.Lifetime.Should().Be(ServiceLifetime.Singleton);
        }
    }
}
