using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{
    public class TeamScheduledEventController : BaseController<TeamScheduledEventController>
    {
        public TeamScheduledEventController(GameChangerService gameChangerService,  ILogger<TeamScheduledEventController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<TeamScheduledEvent>>> Get(string id)
        {
            var listOfScheduledEvents = await _gameChangerService.GetTeamScheduledEventsAsync(id);
            return Ok(listOfScheduledEvents);
        }
    }
}