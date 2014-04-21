using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models;
using System.Diagnostics;
using Microsoft.Phone.Tasks; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
       //player we are looking at 
       public Player player { get; set; }
       public SeasonPlayer seasonplayer { get; set; }

       public PlayerViewModel()
       {
           this.player = null;
           this.seasonplayer = null;

       }
       public virtual void update()
       {
           seasonplayer = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[App.Manager.currentPlayer];
           player = App.Manager.teams[App.Manager.currentTeam].players[App.TeamViewModel.getPlayerIndexID(seasonplayer.BasePlayerID)];

       }
       public void createPlayer(string Fname, string Lname, string Phone, string Email)
       {
           //add player to database
           player_db newPlayerDB = new player_db(App.Manager.ID, App.Manager.teams[App.Manager.currentTeam].ID, Fname, Lname, Phone, Email);
           dbHandler.add_player(newPlayerDB);
           //create player without player ID, db handler will add the ID
           //Player newPlayer = new Player(Fname, Lname, Phone, Email,App.Manager.teams[App.Manager.currentTeam].ID,0,0,0,0,0);
           //App.Manager.teams[App.Manager.currentTeam].players.Add(newPlayer);
           //App.Manager.currentPlayer = App.Manager
           
           //create a season player instance of this player in the current season 
           //SeasonPlayer player = new SeasonPlayer(new Player(Fname, Lname, Phone, Email,App.Manager.teams[App.Manager.currentTeam].ID));
          
       }

        public void CallPLayer()
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = player.Phone;
            phoneCallTask.DisplayName = player.FullName;
            phoneCallTask.Show();
        }
        public void EmailPLayer()
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = player.Email;
            emailComposeTask.Show();
        }

        public void updatePlayerInfo(string FName, string LName, string Email, string Phone)
        {
            player.Fname = FName;
            player.Lname = LName;
            player.Email = Email;
            player.Phone = Phone; 
            dbHandler.update_player(player);
        }
       
    }
}