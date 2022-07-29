using Botje.Mtg.Api.Dtos.Slack.Events;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Botje.Mtg.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlackController : ControllerBase
{
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    [HttpPost("events")]
    public async Task<IActionResult> Events()
    {
        string rawJson = "";
        using (var sr = new StreamReader(Request.Body))
        {
            rawJson = await sr.ReadToEndAsync();
        }

        Console.WriteLine($"Raw request: \n{rawJson}");

        UrlVerification? urlVerification = JsonSerializer.Deserialize<UrlVerification>(rawJson, _serializerOptions);

        if (urlVerification != null
            && urlVerification.Type == "url_verification")
        {
            return Ok(urlVerification.Challenge);
        }

        return Ok();
    }
}
