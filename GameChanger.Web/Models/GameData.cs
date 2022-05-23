namespace GameChanger.Core
{
    public class GameData
    {
        public string game_id { get; set; }
        public object scorekeeping_config_id { get; set; }
        public string game_state { get; set; }
        public int team_score { get; set; }
        public int opponent_score { get; set; }
        public DateTime last_time_to_score_ts { get; set; }
    }
}
