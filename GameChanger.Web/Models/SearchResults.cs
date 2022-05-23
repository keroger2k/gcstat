using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class SearchResults
    {
        [JsonPropertyName("hits")]

        public List<TeamInfo> Hits { get; set; }
    }
}
