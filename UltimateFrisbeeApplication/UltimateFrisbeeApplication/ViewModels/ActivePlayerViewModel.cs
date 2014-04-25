using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models;
using System.Diagnostics; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class ActivePlayerViewModel : PlayerViewModel
    {

       public override void update()
       {
               player = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].activeGame.players[App.Manager.currentActivePlayer]; 

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