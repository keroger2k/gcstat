namespace GameChanger.Core
{
    public class TeamStatsRoot
    {
        public string id { get; set; }
        public StatsData stats_data { get; set; }
        public string team_id { get; set; }
        public string meta_seq { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
