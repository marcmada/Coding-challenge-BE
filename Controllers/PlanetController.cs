using CoddingChallenge.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CoddingChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanets()
        {
            return Ok(await _planetService.GetPlanets());
        }


        [HttpGet("{planetId:int}")]
        public async Task<IActionResult> GetPlanetById([FromRoute] int planetId)
        {
            return Ok(await _planetService.GetPlanetById(planetId));
        }
        //[HttpGet]
        //public async Task<ActionResult<List<Planet>>> GetPlanets()
        //{
        //    return await _dataContext.Planets.ToListAsync();
        //}
    }
}
