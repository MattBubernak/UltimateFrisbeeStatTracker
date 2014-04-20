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

       public PlayerViewModel()
       {
           this.player = null;
       }
       public virtual void update()
       {
           player = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[App.Manager.currentPlayer]; 
       }
       public void createPlayer(string Fname, string Lname, string Phone, string Email)
       {
           //add player to database
           Debug.WriteLine("First Name Providee:" + Fname);
           Debug.WriteLine("Current Team Name: " + App.Manager.teams[App.Manager.currentTeam].Name);
           Debug.WriteLine("Current team index: " + App.Manager.currentTeam);
           Debug.WriteLine("Current Team ID: " + App.Manager.teams[App.Manager.currentTeam].ID);
           player_db newPlayerDB = new player_db(App.Manager.ID, App.Manager.teams[App.Manager.currentTeam].ID, Fname, Lname, Phone, Email);
           dbHandler.add_player(newPlayerDB);

          
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
            dbHandler.updatePlayer(player);
        }
       
    }
}