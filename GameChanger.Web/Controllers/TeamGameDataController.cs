using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{
    public class TeamGameDataController : BaseController<TeamGameDataController>
    {
        public TeamGameDataController(GameChangerService gameChangerService,  ILogger<TeamGameDataController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> Get(string id)
        {
            var listOfScheduledEvents = await _gameChangerService.GetTeamGameDataAsync(id);
            return Ok(listOfScheduledEvents);
        }
    }
}