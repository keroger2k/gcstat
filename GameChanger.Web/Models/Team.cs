namespace GameChanger.Core
{
    public class Team
    {
        public string id { get; set; }
        public string name { get; set; }
        public string team_type { get; set; }
        public int meta_seq { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object teamExternalAssociation { get; set; }
        public object maxPrepsSyncState { get; set; }
        public List<object> organizations { get; set; }
        public Settings settings { get; set; }
        public AdminTeam adminTeam { get; set; }
        public string sport { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string age_group { get; set; }
        public string season_name { get; set; }
        public int season_year { get; set; }
        public string competition_level { get; set; }
        public string stat_access_level { get; set; }
        public object paid_access_level { get; set; }
        public string scorekeeping_access_level { get; set; }
        public string streaming_access_level { get; set; }
        public string ngb { get; set; }
        public List<object> user_team_associations { get; set; }
        public object team_avatar_image { get; set; }
        public object team_player_count { get; set; }
    }

}
