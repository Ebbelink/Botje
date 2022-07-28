using Microsoft.AspNetCore.Mvc;

namespace Botje.Mtg.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlackController : ControllerBase
{
    [HttpPost("events")]
    public string Events([FromBody] object contents)
    {
        Console.WriteLine(contents);

        return "coolio, thanks";
    }
}
