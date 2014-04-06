using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
       //Seasons = list of seasons in manager view model
       public ObservableCollection<Season> Seasons { get; private set; }
       //Players = list of players from CURRENT season
       public ObservableCollection<Player> seasonPlayers { get; set; }
       //Games = list of games from CURRENT season
       public ObservableCollection<Game> seasonGames { get; set; }

       public string Name { get; set; }
       public int Wins {get;set;}
       public int Losses {get; set; }
       public int GoalsScored {get;set;}
       public int GoalsAllowed {get;set;}

       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public TeamViewModel()
       {
           this.Seasons = new ObservableCollection<Season>();
           this.seasonGames = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games;
           this.seasonPlayers = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players;
           this.Name = App.Manager.teams[App.Manager.currentTeam].Name; 
       }

       //returns the index of a player in the manager model, given a player instance from a list selector. 
       public int getPlayerIndex(Player player)
       {
           int index = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.IndexOf(player);
           return index; 
       }

       public void update()
       {
           this.seasonGames = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games;
           this.seasonPlayers = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players;
           this.Name = App.Manager.teams[App.Manager.currentTeam].Name;
           this.Wins = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].Wins;
           this.Losses = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].Losses;
           this.GoalsScored = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsScored;
           this.GoalsAllowed = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsAllowed;

       }

       

        
       
    }
}