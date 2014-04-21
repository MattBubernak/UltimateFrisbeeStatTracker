using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace UltimateFrisbeeApplication.Models
{
    public class SeasonPlayer_db : Player 
    {

        
        public string BasePlayerID { get; set; }
        public string Season_ID { get; set; }
       
        
        public SeasonPlayer_db()
        {

        }


        public SeasonPlayer_db(player_db player)
        {
            this.BasePlayerID = player.ID;
            this.Email = player.Email;
            this.Fname = player.Fname;
            this.Lname = player.Lname;
            this.Phone = player.Phone;
        }
        public SeasonPlayer_db(Player player)
        {
            this.BasePlayerID = player.ID;
            this.Email = player.Email;
            this.Fname = player.Fname;
            this.Lname = player.Lname;
            this.Phone = player.Phone;
        }
        

    }
}
