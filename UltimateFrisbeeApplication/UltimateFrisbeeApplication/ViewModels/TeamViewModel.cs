using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models;
using System.Diagnostics; 

namespace UltimateFrisbeeApplication.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
       //Seasons = list of seasons in manager view model
       //public ObservableCollection<Season> Seasons { get; private set; }

       //Players = list of players from CURRENT season
       //public ObservableCollection<Player> seasonPlayers { get; set; }
       //Games = list of games from CURRENT season
       //public ObservableCollection<Game> seasonGames { get; set; }
       public Season currentSeason { get; set;  }
       public string Name { get; set; }


       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public TeamViewModel()
       {
           //this.Seasons = new ObservableCollection<Season>();
           this.currentSeason = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason]; 
           //this.seasonGames = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games;
           //this.seasonPlayers = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players;
           this.Name = App.Manager.teams[App.Manager.currentTeam].Name; 
       }

       //returns the index of a player in the manager model, given a player instance from a list selector. 
       public int getPlayerIndex(Player player)
       {
           int index = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.IndexOf(player);
           return index; 
       }

        public int getPlayerIndexID(string playerID)
       {
           Debug.WriteLine("Recieved player ID: " + playerID); 
            foreach (Player player in currentSeason.players)
            {
                Debug.WriteLine("Checking " + player.ID); 

                if (player.ID == playerID)
                {
                    return App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.IndexOf(player);
                }
            }
            throw new Exception("player didn't exist!");
       }

       public void update()
       {
           
           Debug.WriteLine("Attempting to switch teams" + App.Manager.currentTeam);
           this.currentSeason = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason];
           this.Name = App.Manager.teams[App.Manager.currentTeam].Name; 

       }

       

        
       
    }
}