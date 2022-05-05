using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{   
    public class TeamController : BaseController<TeamController>
    {
        public TeamController(GameChangerService gameChangerService,  ILogger<TeamController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Team>> Get(string id)
        {
            var teamStats = await _gameChangerService.GetTeamAsync(id);
            return Ok(teamStats);
        }
    }
}