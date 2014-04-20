using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class game_db
    {
        public string ID { get; set; }
        public string season_id { get; set; }
        public string opponent { get; set; }
        public string location { get; set; }
        public string tournament { get; set; }
        public DateTime date { get; set; }
        public int cap { get; set; }
        public int scoreOpp { get; set; }
        public int score { get; set; }
        public game_db(string opponent, string location, string tournament, DateTime date, int cap, int score, int scoreOpp, string season_id ="")
        {
            this.opponent = opponent;
            this.location = location;
            this.tournament = tournament;
            this.date = date;
            this.cap = cap;
            this.score = score;
            this.scoreOpp = scoreOpp;
            this.season_id = season_id; 
        }
    }
}
