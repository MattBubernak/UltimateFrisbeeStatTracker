using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models;
using System.Diagnostics; 


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

        //Stat = string of property being changed
        public void changeStat(string Stat, int value)
       {
           if (Stat == "Goals")
           {
               Debug.WriteLine("updaing gaols....");
               player.Goals += value; 
           }
           if (Stat == "Assists")
           {
               player.Assists += value; 
           }
           if (Stat == "Turnovers")
           {
               player.Turnovers += value;
           }
           if (Stat == "Defenses")
           {
               player.Defenses += value; 
           }
           if (Stat == "Points")
           {
               player.Points += value; 
           }
           //notify that this property has changed 
           NotifyPropertyChanged(Stat); 
       }

        public int Goals
        {
            get
            {
                return player.Goals;
            }
        }
        public int Assists
        {
            get
            {
                return player.Assists;
            }
        }
        public int Turnovers
        {
            get
            {
                return player.Turnovers;
            }
        }
        public int Defenses
        {
            get
            {
                return player.Defenses;
            }
        }
        public int Points
        {
            get
            {
                return player.Points;
            }
        }
      

       

        
       
    }
}