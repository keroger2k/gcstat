using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class Place
    {
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}