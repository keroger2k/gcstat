using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChanger.Core
{
    public class Start
    {
        public DateTime datetime { get; set; }
    }

    public class End
    {
        public DateTime datetime { get; set; }
    }

    public class Arrive
    {
        public DateTime datetime { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
    }

    public class Event
    {
        public string id { get; set; }
        public string event_type { get; set; }
        public List<object> sub_type { get; set; }
        public string status { get; set; }
        public bool full_day { get; set; }
        public string team_id { get; set; }
        public Start start { get; set; }
        public End end { get; set; }
        public Arrive arrive { get; set; }
        public Location location { get; set; }
        public object timezone { get; set; }
        public string notes { get; set; }
        public string title { get; set; }
        public object series_id { get; set; }
    }

    public class RootTeam
    {
        public string id { get; set; }
        public string name { get; set; }
        public string team_type { get; set; }
        public int meta_seq { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Opponent
    {
        public string root_team_id { get; set; }
        public string owning_team_id { get; set; }
        public object progenitor_team_id { get; set; }
        public string meta_seq { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public RootTeam rootTeam { get; set; }
    }

    public class PregameData
    {
        public string id { get; set; }
        public string game_id { get; set; }
        public string home_away { get; set; }
        public object lineup_id { get; set; }
        public string opponent_id { get; set; }
        public string opponent_name { get; set; }
        public string meta_seq { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Opponent opponent { get; set; }
    }

    public class TeamScheduledEvent
    {
        public Event @event { get; set; }
        public PregameData pregame_data { get; set; }
    }


}
