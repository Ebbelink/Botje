using Botje.Mtg.Api.Dtos.Slack.Events;
using Botje.Mtg.Application;
using Microsoft.AspNetCore.Mvc;
using Slack.Dto.Events;
using System.Text.Json;

namespace Botje.Mtg.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlackController : ControllerBase
{
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    private readonly MessageReceivedHandler _handler;

    public SlackController(MessageReceivedHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("events")]
    public async Task<IActionResult> Events()
    {
        string rawJson = await ReadRawJsonFromBody();

        EventWrapper message = JsonSerializer.Deserialize<EventWrapper>(rawJson, _serializerOptions)!;

        // TODO: place in middleware
        // Handle url verification flow
        if (message.Type == "url_verification")
        {
            UrlVerification urlVerification = JsonSerializer.Deserialize<UrlVerification>(rawJson, _serializerOptions)!;
            return Ok(urlVerification.Challenge);
        }

        // Handle card search inquiry 
        if (message.Event != null && message.Event.Type == "message" && !string.IsNullOrWhiteSpace(message.Event.Text))
        {
            await _handler.Handle(message.Event);
        }

        return Ok();
    }

    private async Task<string> ReadRawJsonFromBody()
    {
        string rawJson = "";
        using (var sr = new StreamReader(Request.Body))
        {
            rawJson = await sr.ReadToEndAsync();
        }

        Console.WriteLine($"Raw request: \n{rawJson}");
        return rawJson;
    }
}
