using Botje.Mtg.ScryfallClient;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch;
using Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;
using Microsoft.AspNetCore.Mvc;

namespace Botje.Mtg.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ScryfallController : ControllerBase
{
    private IScryfallClient _scryfallClient;

    public ScryfallController(IScryfallClient scryfallClient)
    {
        _scryfallClient = scryfallClient;
    }

    [HttpGet("search/{searchQuery}")]
    public Task<CardsSearchResponse> Search([FromRoute] string searchQuery)
    {
        var req = new CardsSearchQueryParameters(searchQuery);

        return _scryfallClient.CardSearch(req);
    }
}
