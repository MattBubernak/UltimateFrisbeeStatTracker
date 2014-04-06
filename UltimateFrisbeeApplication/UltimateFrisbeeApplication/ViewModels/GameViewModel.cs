using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
       //player we are looking at 
       public Game game { get; set; }
       public ObservableCollection<Player> players { get; set; }
       public string header { get; set; }
       public int score { get; set; }
       public int scoreOpp { get; set; }

       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public GameViewModel()
       {
           this.game = null;
       }
       public void update()
       {
           game = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame];
           players = game.players;
           header = App.Manager.teams[App.Manager.currentTeam].Name + " vs " + game.opponent;
           score = game.score;
           scoreOpp = game.scoreOpp;    
       }

       public void createGame(Game newGame)
       {
           //create a new game instance 
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games.Add(newGame);
           //set current game to newly created game 
           App.Manager.currentGame = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games.Count - 1; 
           //for every player on the team, for this season, add him to the specific game instance. 
           foreach (Player player in App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players)
           {
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame].players.Add(player);
           }

           update(); //sets current game instance to the one we just created 

       }
      

       

        
       
    }
}