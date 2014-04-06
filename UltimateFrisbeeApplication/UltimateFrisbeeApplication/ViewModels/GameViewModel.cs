using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models;
using System.Diagnostics; 


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

       public void scorePlus()
       {
           game.score++;
           Debug.WriteLine(game.score);
           score++; 
           NotifyPropertyChanged("score"); 
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame] = game; 
       }

        public void scorePlusOpp()
       {
           game.scoreOpp++;
           scoreOpp++; 
       }
        public void scoreMinus()
        {
            game.score--;
            score--; 
        }
        public void scoreMinusOpp()
        {
            game.scoreOpp--;
            scoreOpp--; 
            
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

       public void completeGame()
       {
           //update the DB with all the players stats from this game, game is now complete.
           foreach (Player player in players)
           {
               int Playerindex = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.IndexOf(player);
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Assists += player.Assists;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Defenses += player.Defenses;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Goals += player.Goals;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Points += player.Points;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Turnovers += player.Turnovers; 
           }

           //update the season stats
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsScored += score;
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsAllowed += scoreOpp;
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GamesPlayed++;

           if (score > scoreOpp)
           {
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].Wins++;
           }
           else
           {
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].Losses++;

           }
           NotifyPropertyChanged("GoalsScored");
           NotifyPropertyChanged("GoalsAllowed");
           NotifyPropertyChanged("GamesPlayed");
           NotifyPropertyChanged("Wins");
           NotifyPropertyChanged("Losses");

       }

       public int Score
       {
           get
           {
               return score;
           }
           set
           {
               if (value != score)
               {
                   score = value;
                   Debug.WriteLine("should be notifying console..."); 
                   NotifyPropertyChanged("Score");
               }
           }
       }

       public int ScoreOpp
       {
           get
           {
               return scoreOpp;
           }
           set
           {
               if (value != scoreOpp)
               {
                   scoreOpp = value;
                   NotifyPropertyChanged("scoreOpp");
               }
           }
       }

       

        
       
    }
}