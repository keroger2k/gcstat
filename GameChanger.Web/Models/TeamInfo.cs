using System.Text.Json.Serialization;

namespace GameChanger.Core
{
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
}
