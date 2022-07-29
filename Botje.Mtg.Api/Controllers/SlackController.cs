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
    public IActionResult Events([FromBody] string contents)
    {
        UrlVerification? urlVerification = JsonSerializer.Deserialize<UrlVerification>(contents, _serializerOptions);

        if (urlVerification != null
            && urlVerification.Type == "url_verification")
        {
            return Ok(urlVerification.Challenge);
        }

        Console.WriteLine(contents);

        return Ok();
    }
}
