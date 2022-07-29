using Botje.Mtg.Api.Controllers;
using Botje.Mtg.Api.Dtos.Slack.Events;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Botje.Mtg.Api.Tests.ServiceComponentTests
{
    public class SlackControllerTests
    {
        private readonly WebApplicationFactory<SlackController> _webAppFactory;

        public SlackControllerTests()
        {
            _webAppFactory = new WebApplicationFactory<Controllers.SlackController>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {

                    });
                });
        }

        [Fact]
        public async Task UrlVerificationTest()
        {
            // Assign 
            UrlVerification payload = new UrlVerification
            {
                Token = "Jhj5dZrVaK7ZwHHjRyZWjbDl",
                Challenge = "3eZbrw1aBm2rZgRNFdxV2595E9CY3gmdALWMmHkvFXO7tYXAYM8P",
                Type = "url_verification"
            };

            var client = _webAppFactory.CreateClient();

            var response = await client.PostAsync("/api/Slack/events", new StringContent(JsonSerializer.Serialize(payload)));
            var responseContent = await response.Content.ReadAsStringAsync();

            responseContent.Should().Be(payload.Challenge);
        }
    }
}