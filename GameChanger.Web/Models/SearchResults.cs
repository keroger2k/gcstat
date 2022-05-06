using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameChanger.Core
{
    public class SearchResults
    {
        [JsonPropertyName("hits")]

        public List<TeamInfo> Hits { get; set; }
    }

    public class TeamInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("sport")]
        public string Sport { get; set; }
        [JsonPropertyName("team_season")]
        public SeasonInfo TeamSeason { get; set; }
        [JsonPropertyName("is_orphan")]
        public bool IsOrphan { get; set; }
        [JsonPropertyName("competition_level")]
        public string CompetitionLevel { get; set; }
        [JsonPropertyName("age_group")]
        public string AgeGroup { get; set; }
        [JsonPropertyName("number_of_players")]
        public int NumberOfPlayers { get; set; }
        [JsonPropertyName("staff")]
        public string[] Staff { get; set; }
        [JsonPropertyName("location")]
        public Place Location { get; set; }
    }


    public class Place
    {
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
    public class SeasonInfo
    {
        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
