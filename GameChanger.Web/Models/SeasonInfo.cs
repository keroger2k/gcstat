using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class SeasonInfo
    {
        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }

}