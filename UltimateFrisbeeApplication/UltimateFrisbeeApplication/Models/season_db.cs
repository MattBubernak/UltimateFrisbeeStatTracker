using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class season_db
    {
        public string ID { get; set; }
        public string manager_id { get; set; }
        public string team_id { get; set; }
        public int Wins { get; set; }
        public int GoalsScored { get; set; }
        public int Losses { get; set; }
        public int GoalsAllowed { get; set; }
        public int GamesPlayed { get; set; }
    }
}
