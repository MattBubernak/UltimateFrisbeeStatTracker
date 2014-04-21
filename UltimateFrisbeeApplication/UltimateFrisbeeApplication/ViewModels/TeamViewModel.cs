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
           if (App.Manager.teams[App.Manager.currentTeam].seasons.Count > 0)
           { this.currentSeason = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason]; } 
           //this.seasonGames = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games;
           //this.seasonPlayers = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players;
           this.Name = App.Manager.teams[App.Manager.currentTeam].Name; 
       }

       //returns the index of a player in the manager model, given a player instance from a list selector. 
       public int getPlayerIndex(SeasonPlayer player)
       {
           int index = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.IndexOf(player);
           return index; 
       }

        public int getSeasonPlayerIndexID(string playerID)
       {
           Debug.WriteLine("Recieved player ID: " + playerID); 
            foreach (SeasonPlayer player in currentSeason.players)
            {
                Debug.WriteLine("Checking " + player.ID); 

                if (player.ID == playerID)
                {
                    return App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.IndexOf(player);
                }
            }
            throw new Exception("player didn't exist!");
       }

        public int getPlayerIndexID(string playerID)
        {
            Debug.WriteLine("Recieved player ID: " + playerID);
            foreach (Player player in App.Manager.teams[App.Manager.currentTeam].players)
            {
                Debug.WriteLine("Checking " + player.ID);

                if (player.ID == playerID)
                {
                    return App.Manager.teams[App.Manager.currentTeam].players.IndexOf(player);
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

        public void Create_Season(string name)
        {
            //create a season for this team
       

            season_db season = new season_db();
            season.Name = name;
            season.manager_id = App.Manager.ID;
            season.team_id = App.Manager.teams[App.Manager.currentTeam].ID; 
            App.Manager.teams[App.Manager.currentTeam].seasons.Add(new Season(name));
            App.Manager.currentSeason = App.Manager.teams[App.Manager.currentTeam].seasons.Count-1; 
            dbHandler.add_season(season);
            foreach (Player player in App.Manager.teams[App.Manager.currentTeam].players)
            {
                SeasonPlayer_db seasonplayer = new SeasonPlayer_db(player);
                dbHandler.add_seasonPlayer(seasonplayer);
                //db handler adds the player to the game...
            }
            update(); 
        }
       

        
       
    }
}