using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class InGamePlayer_db
    {
        public string ID { get; set; }
        public string player_id { get; set; }
        public string game_id { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public int Assists {get;set;}
        public int Defenses {get;set;}
        public int Points {get;set;}
        public int Goals {get;set;}
        public int Turnovers {get;set;}

        public InGamePlayer_db(string player_id, string game_id, string FName, string LName, int Assists, int Defenses, int Points, int Goals, int Turnovers)
        {
            this.FName = FName;
            this.LName = LName; 
            this.player_id = player_id;
            this.game_id = game_id;
            this.Assists = Assists;
            this.Defenses = Defenses;
            this.Points = Points;
            this.Goals = Goals;
            this.Turnovers = Turnovers; 
        }
      
    }
}
