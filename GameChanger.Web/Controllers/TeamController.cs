using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{
    public class TeamController : BaseController<TeamController>
    {
        public TeamController(GameChangerService gameChangerService, ILogger<TeamController> logger) :
            base(gameChangerService, logger)
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
        [Route("{id}/player/{pid}/spray-chart")]
        public async Task<ActionResult<List<NotSure>>> GetTeamPlayerSprayChart(string id, string pid)
        {
            //Get list of events for team
            var listOfScheduledEvents = await _gameChangerService.GetTeamGameDataAsync(id);

            var filteredListOfGameEvents = listOfScheduledEvents.Where(e => e.game_data != null).Select(e => e.event_id);

            List<NotSure> offensiveSprayChart = new List<NotSure>();
            //foreach event find player offensive spray chart info
            foreach (var gameEvent in filteredListOfGameEvents)
            {
                var teamStats = await _gameChangerService.GetTeamEventStatsAsync(id, gameEvent);
                var playerSpary = teamStats.spray_chart_data.offense.Where(c => c.Key == pid).Select(c => c.Value);
                if (playerSpary.Any())
                {
                    foreach (var item in playerSpary)
                    {
                        foreach (var item1 in item)
                        {
                            offensiveSprayChart.Add(item1);
                        }
                    }
                }
            }
            return Ok(offensiveSprayChart);
        }


        [HttpGet]
        [Route("{id}/spray-chart")]
        public async Task<ActionResult<PlayerSprayChart>> GetTeamSprayChart(string id)
        {
            //get list of team players
            var listOfPlayers = await _gameChangerService.GetTeamPlayersAsync(id);

            var seasonStats = await _gameChangerService.GetTeamStatsAsync(id);

            //convert objects to include spray info
            var listOfPlayerWithSpray = listOfPlayers.Select(c => new PlayerSprayChart(c));

            //Get list of events for team
            var listOfScheduledEvents = await _gameChangerService.GetTeamGameDataAsync(id);

            //Get just the games played and their EventId
            var filteredListOfGameEvents = listOfScheduledEvents.Where(e => e.game_data != null).Select(e => e.event_id);

            Dictionary<string, List<NotSure>> testing = new Dictionary<string, List<NotSure>>();
            //foreach Event find players offensive spray chart info
            foreach (var gameEvent in filteredListOfGameEvents)
            {
                try
                {
                    //get the event spray chart details
                    var teamStats = await _gameChangerService.GetTeamEventStatsAsync(id, gameEvent);

                    foreach (var player in listOfPlayerWithSpray)
                    {
                        var playerSpray = teamStats.spray_chart_data.offense.Where(c => c.Key == player.Id).Select(c => c.Value);
                        foreach (var item in playerSpray)
                        {
                            foreach (var item1 in item)
                            {
                                if (testing.ContainsKey(player.Id))
                                {
                                    testing[player.Id].Add(item1);
                                }
                                else
                                {
                                    testing.Add(player.Id, new List<NotSure>() { item1 });
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            var newlistOfPlayer = new List<PlayerSprayChart>();

            foreach (var item in testing)
            {
                var p = listOfPlayerWithSpray.First(p => p.Id == item.Key);
                p.SprayChart.AddRange(item.Value);
                p.OffenseInfo = seasonStats.stats_data.players[p.Id].stats.offense;
                newlistOfPlayer.Add(p); 
            }


            return Ok(newlistOfPlayer);
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