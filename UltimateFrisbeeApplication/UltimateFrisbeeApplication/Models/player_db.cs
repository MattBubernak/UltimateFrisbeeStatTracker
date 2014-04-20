using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class player_db
    {
        public string ID { get; set; }
        public string manager_id { get; set; }
        public string team_id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Turnovers { get; set; }
        public int Points { get; set; }
        public int Defenses { get; set; }
        
        public player_db(string manager_id, string team_id, string FName, string LName, string Phone, string Email)
        {
            this.manager_id = manager_id;
            this.team_id = team_id;
            this.Fname = FName;
            this.Lname = LName;
            this.Phone = Phone;
            this.Email = Email;
            this.Goals = 0;
            this.Assists = 0;
            this.Turnovers = 0;
            this.Points = 0;
            this.Defenses = 0; 
        }
    }
}
