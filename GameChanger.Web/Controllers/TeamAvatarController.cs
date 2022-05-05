using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{   
    public class TeamAvatarController : BaseController<TeamAvatarController>
    {
        public TeamAvatarController(GameChangerService gameChangerService,  ILogger<TeamAvatarController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TeamAvatar>> Get(string id)
        {
            var teamStats = await _gameChangerService.GetTeamAvatarAsync(id);
            return Ok(teamStats);
        }
    }
}