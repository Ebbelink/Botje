using Botje.Mtg.Api.Controllers;
using Botje.Mtg.Api.Dtos.Slack.Events;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
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

        public static IEnumerable<object[]> RawSlackMessages => 
            new List<object[]>
            {
                new object[]{@"{""token"":""2i0ZbAtijqMzDmJKbXAyo0SZ"",""team_id"":""TEGGX065N"",""api_app_id"":""A01FA261L57"",""event"":{""type"":""message"",""subtype"":""message_changed"",""message"":{""client_msg_id"":""b8a2a026-effc-45df-bdea-598055aa3b08"",""type"":""message"",""text"":""<https:\/\/youtu.be\/--9kqhzQ-8Q|https:\/\/youtu.be\/--9kqhzQ-8Q>"",""user"":""UEJM432GN"",""team"":""TEGGX065N"",""attachments"":[{""from_url"":""https:\/\/youtu.be\/--9kqhzQ-8Q"",""thumb_url"":""https:\/\/i.ytimg.com\/vi\/--9kqhzQ-8Q\/hqdefault.jpg"",""thumb_width"":480,""thumb_height"":360,""video_html"":""<iframe width=\""400\"" height=\""225\"" src=\""https:\/\/www.youtube.com\/embed\/--9kqhzQ-8Q?feature=oembed&autoplay=1&iv_load_policy=3\"" frameborder=\""0\"" allow=\""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\"" allowfullscreen title=\""H.Y.C.Y.BH? (Official Video)\""><\/iframe>"",""video_html_width"":400,""video_html_height"":225,""service_icon"":""https:\/\/a.slack-edge.com\/80588\/img\/unfurl_icons\/youtube.png"",""id"":1,""original_url"":""https:\/\/youtu.be\/--9kqhzQ-8Q"",""fallback"":""YouTube Video: H.Y.C.Y.BH? (Official Video)"",""title"":""H.Y.C.Y.BH? (Official Video)"",""title_link"":""https:\/\/youtu.be\/--9kqhzQ-8Q"",""author_name"":""tom cardy"",""author_link"":""https:\/\/www.youtube.com\/c\/tomcardy1"",""service_name"":""YouTube"",""service_url"":""https:\/\/www.youtube.com\/""}],""blocks"":[{""type"":""rich_text"",""block_id"":""FDHGn"",""elements"":[{""type"":""rich_text_section"",""elements"":[{""type"":""link"",""url"":""https:\/\/youtu.be\/--9kqhzQ-8Q"",""text"":""https:\/\/youtu.be\/--9kqhzQ-8Q""}]}]}],""ts"":""1660036717.688699""},""previous_message"":{ ""client_msg_id"":""b8a2a026-effc-45df-bdea-598055aa3b08"",""type"":""message"",""text"":""<https:\/\/youtu.be\/--9kqhzQ-8Q|https:\/\/youtu.be\/--9kqhzQ-8Q>"",""user"":""UEJM432GN"",""ts"":""1660036717.688699"",""team"":""TEGGX065N"",""blocks"":[{ ""type"":""rich_text"",""block_id"":""FDHGn"",""elements"":[{ ""type"":""rich_text_section"",""elements"":[{ ""type"":""link"",""url"":""https:\/\/youtu.be\/--9kqhzQ-8Q"",""text"":""https:\/\/youtu.be\/--9kqhzQ-8Q""}]}]}]},""channel"":""GEUGMMDAS"",""hidden"":true,""ts"":""1660036718.000100"",""event_ts"":""1660036718.000100"",""channel_type"":""group""},""type"":""event_callback"",""event_id"":""Ev03SQ6TQCSJ"",""event_time"":1660036718,""authorizations"":[{""enterprise_id"":null,""team_id"":""TEGGX065N"",""user_id"":""UEGLULXB3"",""is_bot"":false,""is_enterprise_install"":false}],""is_ext_shared_channel"":false,""event_context"":""4-eyJldCI6Im1lc3NhZ2UiLCJ0aWQiOiJURUdHWDA2NU4iLCJhaWQiOiJBMDFGQTI2MUw1NyIsImNpZCI6IkdFVUdNTURBUyJ9""}" },
                new object[]{@"{""token"":""2i0ZbAtijqMzDmJKbXAyo0SZ"",""team_id"":""TEGGX065N"",""api_app_id"":""A01FA261L57"",""event"":{""client_msg_id"":""b8a2a026-effc-45df-bdea-598055aa3b08"",""type"":""message"",""text"":""<https:\/\/youtu.be\/--9kqhzQ-8Q|https:\/\/youtu.be\/--9kqhzQ-8Q>"",""user"":""UEJM432GN"",""ts"":""1660036717.688699"",""team"":""TEGGX065N"",""blocks"":[{""type"":""rich_text"",""block_id"":""FDHGn"",""elements"":[{""type"":""rich_text_section"",""elements"":[{""type"":""link"",""url"":""https:\/\/youtu.be\/--9kqhzQ-8Q"",""text"":""https:\/\/youtu.be\/--9kqhzQ-8Q""}]}]}],""channel"":""GEUGMMDAS"",""event_ts"":""1660036717.688699"",""channel_type"":""group""},""type"":""event_callback"",""event_id"":""Ev03SWN2G4R1"",""event_time"":1660036717,""authorizations"":[{""enterprise_id"":null,""team_id"":""TEGGX065N"",""user_id"":""UEGLULXB3"",""is_bot"":false,""is_enterprise_install"":false}],""is_ext_shared_channel"":false,""event_context"":""4-eyJldCI6Im1lc3NhZ2UiLCJ0aWQiOiJURUdHWDA2NU4iLCJhaWQiOiJBMDFGQTI2MUw1NyIsImNpZCI6IkdFVUdNTURBUyJ9""}" },
                new object[]{@"{""token"":""2i0ZbAtijqMzDmJKbXAyo0SZ"",""team_id"":""TEGGX065N"",""api_app_id"":""A01FA261L57"",""event"":{""client_msg_id"":""99965306-5797-4a6f-be3e-8a035c2d45f2"",""type"":""message"",""text"":""Deze fucking dude, hilarisch"",""user"":""UEJM432GN"",""ts"":""1660036730.122149"",""team"":""TEGGX065N"",""blocks"":[{""type"":""rich_text"",""block_id"":""gvZB"",""elements"":[{""type"":""rich_text_section"",""elements"":[{""type"":""text"",""text"":""Deze fucking dude, hilarisch""}]}]}],""channel"":""GEUGMMDAS"",""event_ts"":""1660036730.122149"",""channel_type"":""group""},""type"":""event_callback"",""event_id"":""Ev03SZ8J2E04"",""event_time"":1660036730,""authorizations"":[{""enterprise_id"":null,""team_id"":""TEGGX065N"",""user_id"":""UEGLULXB3"",""is_bot"":false,""is_enterprise_install"":false}],""is_ext_shared_channel"":false,""event_context"":""4-eyJldCI6Im1lc3NhZ2UiLCJ0aWQiOiJURUdHWDA2NU4iLCJhaWQiOiJBMDFGQTI2MUw1NyIsImNpZCI6IkdFVUdNTURBUyJ9""}"},
                new object[]{@"{""token"":""2i0ZbAtijqMzDmJKbXAyo0SZ"",""team_id"":""TEGGX065N"",""api_app_id"":""A01FA261L57"",""event"":{""client_msg_id"":""bfd51df8-12b3-4b70-8e7f-36156d98a8d8"",""type"":""message"",""text"":""Ja dat Ayara deck was best proper, werkte goed. Hij is ook wel gewoon een goede speler dus dat helpt"",""user"":""UEJM432GN"",""ts"":""1660036749.114379"",""team"":""TEGGX065N"",""blocks"":[{""type"":""rich_text"",""block_id"":""dj6FR"",""elements"":[{""type"":""rich_text_section"",""elements"":[{""type"":""text"",""text"":""Ja dat Ayara deck was best proper, werkte goed. Hij is ook wel gewoon een goede speler dus dat helpt""}]}]}],""channel"":""GEUGMMDAS"",""event_ts"":""1660036749.114379"",""channel_type"":""group""},""type"":""event_callback"",""event_id"":""Ev03STS95XK7"",""event_time"":1660036749,""authorizations"":[{""enterprise_id"":null,""team_id"":""TEGGX065N"",""user_id"":""UEGLULXB3"",""is_bot"":false,""is_enterprise_install"":false}],""is_ext_shared_channel"":false,""event_context"":""4-eyJldCI6Im1lc3NhZ2UiLCJ0aWQiOiJURUdHWDA2NU4iLCJhaWQiOiJBMDFGQTI2MUw1NyIsImNpZCI6IkdFVUdNTURBUyJ9""}"},
                new object[]{@"{""token"":""2i0ZbAtijqMzDmJKbXAyo0SZ"",""team_id"":""TEGGX065N"",""api_app_id"":""A01FA261L57"",""event"":{""client_msg_id"":""75bcdd6f-5ac5-4e20-ab07-3b63db19b6bf"",""type"":""message"",""text"":""ayara heb ik altijd erg dope gevonden maar altijd erg lastig om een voorstelling te maken van een goed werkend deck"",""user"":""UEGLULXB3"",""ts"":""1660123454.730799"",""team"":""TEGGX065N"",""blocks"":[{""type"":""rich_text"",""block_id"":""2OJ3H"",""elements"":[{""type"":""rich_text_section"",""elements"":[{""type"":""text"",""text"":""ayara heb ik altijd erg dope gevonden maar altijd erg lastig om een voorstelling te maken van een goed werkend deck""}]}]}],""channel"":""GEUGMMDAS"",""event_ts"":""1660123454.730799"",""channel_type"":""group""},""type"":""event_callback"",""event_id"":""Ev03T2T6G2CB"",""event_time"":1660123454,""authorizations"":[{""enterprise_id"":null,""team_id"":""TEGGX065N"",""user_id"":""UEGLULXB3"",""is_bot"":false,""is_enterprise_install"":false}],""is_ext_shared_channel"":false,""event_context"":""4-eyJldCI6Im1lc3NhZ2UiLCJ0aWQiOiJURUdHWDA2NU4iLCJhaWQiOiJBMDFGQTI2MUw1NyIsImNpZCI6IkdFVUdNTURBUyJ9""}"},
            };

        [Theory]
        [MemberData(nameof(RawSlackMessages))]
        public async Task VerifyCanProcessMessages(string rawJson)
        {
            var client = _webAppFactory.CreateClient();

            var response = await client.PostAsync("/api/Slack/events", new StringContent(rawJson));
            var responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}