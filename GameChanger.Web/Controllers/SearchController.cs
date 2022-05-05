using Microsoft.AspNetCore.Mvc;
using GameChanger.Core;
using System.Text.Json;

namespace GameChanger.Web.Controllers
{
    public class SearchController : BaseController<SearchController>
    {
        
        public SearchController(GameChangerService gameChangerService,  ILogger<SearchController> logger) : 
            base(gameChangerService ,logger)
        {
        }

        [HttpGet(Name = "Teams")]
        public async Task<ActionResult<SearchResults>> Get(string query)
        {
            var teams = await _gameChangerService.SearchTeamsAsync(query);
            return Ok(teams.Hits);
        }
    }
}