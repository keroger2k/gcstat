using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{
    public class TeamStatsController : BaseController<TeamStatsController>
    {
        public TeamStatsController(GameChangerService gameChangerService,  ILogger<TeamStatsController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<PlayerInfoResults>>> Get(string id)
        {
            var listOfPlayers = await _gameChangerService.GetTeamPlayersAsync(id);
            var teamStats = await _gameChangerService.GetTeamStatsAsync(id);
            
            foreach(var player in teamStats.stats_data.players.Keys)
            {
                var p = listOfPlayers.First(c => c.Id == player);
                var s = teamStats.stats_data.players[player].stats;

                s.FirstName = p.FirstName;
                s.LastName = p.LastName;
                s.Number = p.Number;
            }

            return Ok(teamStats);
        }
    }
}