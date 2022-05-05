using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{
    public class PlayersController : BaseController<PlayersController>
    {
        public PlayersController(GameChangerService gameChangerService,  ILogger<PlayersController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<PlayerInfoResults>>> Get(string id)
        {
            var teamPlayers = await _gameChangerService.GetTeamPlayersAsync(id);
            return Ok(teamPlayers);
        }
    }
}