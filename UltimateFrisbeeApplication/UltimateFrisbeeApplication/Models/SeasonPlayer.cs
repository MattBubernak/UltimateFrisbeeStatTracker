using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class SeasonPlayer : Player 
    {
        public string BasePlayerID { get; set; }
        public string Season_ID { get; set; }
        public SeasonPlayer(Player player)
        {
            this.BasePlayerID = player.ID;
            this.Assists = player.Assists;
            this.Defenses = player.Defenses;
            this.Email = player.Email;
            this.Fname = player.Fname;
            this.Goals = player.Goals;
            this.Phone = player.Phone;
            this.Points = player.Points;
            this.Turnovers = player.Turnovers; 
        }
        public SeasonPlayer(SeasonPlayer_db player)
        {
            this.BasePlayerID = player.ID;
            this.Assists = player.Assists;
            this.Defenses = player.Defenses;
            this.Email = player.Email;
            this.Fname = player.Fname;
            this.Goals = player.Goals;
            this.Phone = player.Phone;
            this.Points = player.Points;
            this.Turnovers = player.Turnovers;
        }
        //used when we are importing from the DB 
        public SeasonPlayer(string ID, string BasePlayerID, string Season_ID, string Fname, string Lname, string Email, string Phone, int Goals, int Assists, int Defenses, int Points, int Turnovers)
        {
            this.Season_ID = Season_ID;
            this.BasePlayerID = BasePlayerID;
            this.Assists = Assists;
            this.Defenses = Defenses;
            this.ID = ID;
            this.Fname = Fname;
            this.Lname = Lname;
            this.Email = Email;
            this.Phone = Phone;
            this.Goals = Goals;
            this.Points = Points;
            this.Turnovers = Turnovers; 
        }

        //creating a blank season player
        public SeasonPlayer(string ID, string BasePlayerID, string Season_ID, string Fname, string Lname, string Email, string Phone)
        {
            this.Season_ID = Season_ID;
            this.BasePlayerID = BasePlayerID;
            this.Assists = Assists;
            this.Defenses = Defenses;
            this.ID = ID;
            this.Fname = Fname;
            this.Lname = Lname;
            this.Email = Email;
            this.Phone = Phone;
            this.Goals = Goals;
            this.Points = Points;
            this.Turnovers = Turnovers;
        }

    }
}
