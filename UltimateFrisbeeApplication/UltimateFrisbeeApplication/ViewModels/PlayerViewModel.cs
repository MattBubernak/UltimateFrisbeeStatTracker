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
       public void createPlayer(Player newPlayer)
       {
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.Add(newPlayer);
       }

        public void CallPLayer()
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = player.Phone;
            phoneCallTask.DisplayName = player.FullName;
            phoneCallTask.Show();
        }

       
    }
}