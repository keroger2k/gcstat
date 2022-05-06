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

        [HttpGet]
        [Route("{id}/schedule/events/{eid}/player-stats")]
        public async Task<ActionResult<Team>> GetTeamEventPlayerStats(string id, string eid)
        {
            var teamStats = await _gameChangerService.GetTeamEventStatsAsync(id, eid);
            return Ok(teamStats);
        }

        [HttpGet]
        [Route("{id}/avatar")]
        public async Task<ActionResult<TeamAvatar>> GetTeamAvatar(string id)
        {
            var teamStats = await _gameChangerService.GetTeamAvatarAsync(id);
            return Ok(teamStats);
        }

        [HttpGet]
        [Route("{id}/season-stats")]
        public async Task<ActionResult<IEnumerable<PlayerInfoResults>>> GetTeamSeasonStats(string id)
        {
            var listOfPlayers = await _gameChangerService.GetTeamPlayersAsync(id);
            var teamStats = await _gameChangerService.GetTeamStatsAsync(id);

            foreach (var player in teamStats.stats_data.players.Keys)
            {
                var p = listOfPlayers.First(c => c.Id == player);
                var s = teamStats.stats_data.players[player].stats;

                s.FirstName = p.FirstName;
                s.LastName = p.LastName;
                s.Number = p.Number;
            }

            return Ok(teamStats);
        }

        [HttpGet]
        [Route("{id}/players")]
        public async Task<ActionResult<IEnumerable<PlayerInfoResults>>> GetTeamPlayers(string id)
        {
            var teamPlayers = await _gameChangerService.GetTeamPlayersAsync(id);
            return Ok(teamPlayers);
        }

        [HttpGet]
        [Route("{id}/gamedata")]
        public async Task<ActionResult<IEnumerable<Game>>> GetTeamGameDat(string id)
        {
            var listOfScheduledEvents = await _gameChangerService.GetTeamGameDataAsync(id);
            return Ok(listOfScheduledEvents);
        }
        [HttpGet]
        [Route("{id}/schedule")]
        public async Task<ActionResult<IEnumerable<TeamScheduledEvent>>> GetTeamSchedule(string id)
        {
            var listOfScheduledEvents = await _gameChangerService.GetTeamScheduledEventsAsync(id);
            return Ok(listOfScheduledEvents);
        }
    }
}