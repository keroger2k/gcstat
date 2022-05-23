using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameChanger.Core
{
    public class AdminTeam
    {
        public string root_team_id { get; set; }
        public string age_group { get; set; }
        public string city { get; set; }
        public string competition_level { get; set; }
        public string country { get; set; }
        public string ngb { get; set; }
        public object paid_access_level { get; set; }
        public object rolled_over_from_team_id { get; set; }
        public object scorekeeping_access_level { get; set; }
        public string season_name { get; set; }
        public int season_year { get; set; }
        public string sport { get; set; }
        public object stat_access_level { get; set; }
        public string state { get; set; }
        public string streaming_access_level { get; set; }
        public string meta_seq { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}