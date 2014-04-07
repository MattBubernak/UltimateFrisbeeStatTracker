using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class InGamePlayer : Player
    {
        public InGamePlayer(Player player)
        {
            this.Assists = 0;
            this.Defenses = 0;
            this.Points = 0; 
            this.Goals = 0; 
            this.Turnovers=0; 
            this.Fname = player.Fname;
            this.Lname = player.Lname;
            this.PlayerID = player.PlayerID; 
        }
    }
}
