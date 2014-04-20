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
        public string ID { get; set; }
        public string team_ID { get; set; }
        public Player()
        {
            this.Fname = "fred";
            this.Lname = "button"; 
        }
        public Player(string FName, string LName, string Phone = "None", string Email = "None",string team_ID = "")
        {
            this.Fname = FName;
            this.Lname = LName;
            this.Phone = Phone;
            this.Email = Email;
            this.team_ID = team_ID; 
        }
        public Player(string FName, string LName, string Phone = "None", string Email = "None", string team_ID = "", int Goals = 0, int Assists = 0, int Turnovers = 0, int Points = 0, int Defenses = 0, string ID = "")
        {
            this.Fname = FName;
            this.Lname = LName;
            this.Phone = Phone;
            this.Email = Email;
            this.team_ID = team_ID;
            this.Goals = Goals; 
            this.Assists = Assists; 
            this.Turnovers = Turnovers; 
            this.Points = Points; 
            this.Defenses = Defenses;
            this.ID = ID; 
        }

        //below methods are all for binding purposes, and get/set! 
        

        public string FullName
        {
            get { return Fname +" "+ Lname;  }
        }
        public string Stats
        {
            get { return "G:" + Goals + " A:" + Assists + " D:" + Defenses + " TO:" + Turnovers + " P:" + Points; }
        }

    }
}
