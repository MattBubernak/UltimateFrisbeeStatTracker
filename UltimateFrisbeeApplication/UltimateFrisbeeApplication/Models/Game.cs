using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFrisbeeApplication.Models; 

namespace UltimateFrisbeeApplication.Models
{
    public class Game
    {
        public string ID { get; set; }
        public string opponent { get; set; }
        public string location { get; set; }
        public string tournament { get; set; }
        public string season_id { get; set; }
        public DateTime date { get; set; }
        public int cap { get; set; }
        public int scoreOpp { get; set; }
        public int score { get; set; }
       
        public ObservableCollection<InGamePlayer> players { get; set; }

        public Game(string opponent, string location, string tournament, int cap, DateTime date, string season_id = "", string ID = "", int score=0, int scoreOpp=0)
        {
            this.opponent = opponent;
            this.location = location;
            this.tournament = tournament;
            this.cap = cap;
            this.score = 0;
            this.scoreOpp = 0;
            this.date = date;
            this.season_id = season_id;
            this.score = score;
            this.scoreOpp = scoreOpp; 
            this.players = new ObservableCollection<InGamePlayer>(); 
        }

        public string gameDescription
        {
            get
            {
                if (score > scoreOpp)
                {
                    return "Win, " + score + " to " + scoreOpp + " , " + date; 
                }
                return "Loss, " + score + " to " + scoreOpp + " , " + date; 
            }
        }
    }
}
