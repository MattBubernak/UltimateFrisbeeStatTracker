using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class Player
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Turnovers { get; set; }
        public int Points { get; set; }
        public int Defenses { get; set; }
        public int PlayerID { get; set; }
        public Player()
        {
            this.Fname = "fred";
            this.Lname = "button"; 
        }
        public Player(string FName, string LName, string Phone = "None", string Email = "None")
        {
            this.Fname = FName;
            this.Lname = LName;
            this.Phone = Phone;
            this.Email = Email;
            
            this.PlayerID = App.random.Next(0, 1000000); // give him a random player ID
        }

        //below methods are all for binding purposes, and get/set! 
        

        public string FullName
        {
            get { return Fname +" "+ Lname;  }
        }
        public string SeasonStats
        {
            get { return Goals + " goals, " + Assists + " assists, " + Turnovers + " turnovers"; }
        }

    }
}
