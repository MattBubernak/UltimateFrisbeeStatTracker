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
        public string opponent { get; set; }
        public string location { get; set; }
        public string tournament { get; set; }
        public int cap { get; set; }
        public int scoreOpp { get; set; }
        public int score { get; set; }
        public ObservableCollection<InGamePlayer> players { get; set; }

        public Game(string opponent, string location, string tournament, int cap)
        {
            this.opponent = opponent;
            this.location = location;
            this.tournament = tournament;
            this.cap = cap;
            this.score = 0;
            this.scoreOpp = 0;
            this.players = new ObservableCollection<InGamePlayer>(); 
        }

        public string gameDescription
        {
            get
            {
                if (score > scoreOpp)
                {
                    return "Win, " + score + " to " + scoreOpp; 
                }
                return "Loss, " + score + " to " + scoreOpp; 
            }
        }
    }
}
