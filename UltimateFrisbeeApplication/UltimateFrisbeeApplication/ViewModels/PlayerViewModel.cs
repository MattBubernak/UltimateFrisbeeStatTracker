using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
       //player we are looking at 
       public Player player { get; set; }

       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public PlayerViewModel()
       {
           this.player = null;
       }
       public void update()
       {
           player = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[App.Manager.currentPlayer]; 
       
       }
       public void createPlayer(Player newPlayer)
       {
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.Add(newPlayer);
       }
      

       

        
       
    }
}