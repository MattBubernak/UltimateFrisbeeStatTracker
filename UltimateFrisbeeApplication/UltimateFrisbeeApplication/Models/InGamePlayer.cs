using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class InGamePlayer : Player
    {
        public string player_id; 
        public InGamePlayer(Player player)
        {
            this.Assists = 0;
            this.Defenses = 0;
            this.Points = 0; 
            this.Goals = 0; 
            this.Turnovers=0; 
            this.Fname = player.Fname;
            this.Lname = player.Lname;
            this.player_id = player.ID; 
        }
        public InGamePlayer(string Fname, string Lname, int Assists, int Defenses, int Points, int Goals, int Turnovers)
        {
            this.Assists = Assists;
            this.Defenses = Defenses;
            this.Points = Points;
            this.Goals = Goals;
            this.Turnovers = Turnovers;
            this.Fname = Fname;
            this.Lname = Lname;
            //this.PlayerID = PlayerID;
        }
    }
}
