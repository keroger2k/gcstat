using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class NotSure
    {
        public string id { get; set; }
        public string code { get; set; }
        public object createdAt { get; set; }
        public Attributes attributes { get; set; }
        public CompactorAttributes compactorAttributes { get; set; }
    }

    public class Something1
    {
        public PlayerStats stats { get; set; }
    }

    public class EventPlayerStats
    {
        public Stats stats { get; set; }

        public Dictionary<string, Something1> players { get; set; }
    }

    public class EventLocation
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class Defender
    {
        public bool error { get; set; }
        public EventLocation location { get; set; }
        public string position { get; set; }
    }

    public class Attributes
    {
        public string playType { get; set; }
        public List<Defender> defenders { get; set; }
        public string playResult { get; set; }
        public string hrLocation { get; set; }
        public string playFlavor { get; set; }
    }

    public class CompactorAttributes
    {
        public string stream { get; set; }
    }

    public class SprayChartData
    {
        public Dictionary<string, List<NotSure>> defense { get; set; }
        public Dictionary<string, List<NotSure>> offense { get; set; }

    }

    public class CumulativePlayerStats
    {
        public Stats stats { get; set; }
        public Dictionary<string, Something1> players { get; set; }
    }

    public class TeamEventStats
    {
        public string event_id { get; set; }
        public string stream_id { get; set; }
        public string derivation_hash { get; set; }
        public EventPlayerStats player_stats { get; set; }
        public string team_id { get; set; }
        public SprayChartData spray_chart_data { get; set; }
        public CumulativePlayerStats cumulative_player_stats { get; set; }
    }
}
