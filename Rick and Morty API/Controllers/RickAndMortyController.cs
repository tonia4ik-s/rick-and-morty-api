using Microsoft.AspNetCore.Mvc;
using Rick_and_Morty_API.DTO;
using Rick_and_Morty_API.Services;

namespace Rick_and_Morty_API.Controllers;

[ApiController]
[Route("api/v1")]
public class RickAndMortyController : Controller
{
    private readonly ILogger<RickAndMortyController> _logger;
    private readonly IRickAndMortyService _rickAndMortyService;

    public RickAndMortyController(ILogger<RickAndMortyController> logger, IRickAndMortyService rickAndMortyService)
    {
        _logger = logger;
        _rickAndMortyService = rickAndMortyService;
    }

    [HttpPost("check-person")]
    public async Task<ActionResult> CheckPerson([FromBody] CheckPersonDTO checkPersonDTO)
    {
        try
        {
            var response = await _rickAndMortyService
                .CheckPerson(checkPersonDTO.PersonName, checkPersonDTO.EpisodeName);
            return Ok(response);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpGet("person")]
    public async Task<ActionResult> GetPerson(string personName)
    {
        try
        {
            var response = await _rickAndMortyService.GetCharacters(personName);
            return Ok(response);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}

