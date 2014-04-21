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
       public string header { get; set; }
       public string gameinfo { get; set; }

       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public GameViewModel()
       {
           this.game = null;
       }
       //purely for binding 
       public int Score
       {
           get
           {
               return game.score;
           }
       }
       public int ScoreOpp
       {
           get
           {
               return game.scoreOpp;
           }
       }

       public void scorePlus()
       {
           game.score++;
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame] = game;
           NotifyPropertyChanged("Score"); 
       }

        public void scorePlusOpp()
       {
           game.scoreOpp++;
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame] = game;
           NotifyPropertyChanged("ScoreOpp"); 

       }
        public void scoreMinus()
        {
            game.score--;
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame] = game;
            NotifyPropertyChanged("Score"); 

        }
        public void scoreMinusOpp()
        {
            game.scoreOpp--;
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame] = game;
            NotifyPropertyChanged("ScoreOpp"); 

        }
       public void update()
       {
           game = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame];

           header = App.Manager.teams[App.Manager.currentTeam].Name + " vs " + game.opponent;
           gameinfo = "Cap: " + game.cap + " Date: " + game.date;  
       }

       public void createGame(Game newGame)
       {
           //create a new game instance 
           //App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games.Add(newGame);
           Debug.WriteLine("create game....");

           Debug.WriteLine("current team: " + App.Manager.currentTeam + "current season: " + App.Manager.currentSeason);

           Debug.WriteLine("Season ID: " + App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID);
           dbHandler.add_game(new game_db(newGame.opponent,newGame.location, newGame.tournament, newGame.date, 
               newGame.cap, newGame.score, newGame.scoreOpp, 
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID));


           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games.Add(newGame);
          
           //set current game to newly created game 
           App.Manager.currentGame = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games.Count - 1; 
           //for every player on the team, for this season, add him to the specific game instance. 
           Debug.WriteLine("Current Team: " + App.Manager.currentTeam + "Current Season " + App.Manager.currentSeason + "Current game: " + App.Manager.currentGame); 
           foreach (SeasonPlayer player in App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players)
           {
               InGamePlayer newInGamePlayer = new InGamePlayer(player);
               Debug.WriteLine("====== player_id: " + player.ID);
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame].players.Add(newInGamePlayer);
           }

           update(); //sets current game instance to the one we just created 

       }

       public void completeGame()
       {
           //TODO: Create a game instance DB object for this game, for each player.... 
           //update the DB with all the players stats from this game, game is now complete.
           foreach (InGamePlayer player in game.players)
           {
               Debug.WriteLine("Player: " + player.Fname + player.Lname + "ID: " + player.player_id);
               int Playerindex = App.TeamViewModel.getSeasonPlayerIndexID(player.player_id);
               int GlobPlayerIndex = App.TeamViewModel.getPlayerIndexID(App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].BasePlayerID);
               //update season player stats 
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Assists += player.Assists;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Defenses += player.Defenses;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Goals += player.Goals;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Points += player.Points;
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex].Turnovers += player.Turnovers;
               //update global player stats 
               App.Manager.teams[App.Manager.currentTeam].players[GlobPlayerIndex].Assists += player.Assists;
               App.Manager.teams[App.Manager.currentTeam].players[GlobPlayerIndex].Defenses += player.Defenses;
               App.Manager.teams[App.Manager.currentTeam].players[GlobPlayerIndex].Goals += player.Goals;
               App.Manager.teams[App.Manager.currentTeam].players[GlobPlayerIndex].Points += player.Points;
               App.Manager.teams[App.Manager.currentTeam].players[GlobPlayerIndex].Turnovers += player.Turnovers;

               dbHandler.add_inGamePlayer(new InGamePlayer_db(player.player_id,game.ID,player.Fname,player.Lname,player.Assists,player.Defenses,player.Points,player.Goals,player.Turnovers));
               //update this season player in the database
               Debug.WriteLine("about to call update_seasonplayer");
               dbHandler.update_seasonplayer(App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[Playerindex]);
               //update this player in the database
               dbHandler.update_player(App.Manager.teams[App.Manager.currentTeam].players[GlobPlayerIndex]); 

           }

           //update the season stats
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsScored += game.score;
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsAllowed += game.scoreOpp;
           App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GamesPlayed++;
        
           if (game.score > game.scoreOpp)
           {
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].Wins++;
           }
           else
           {
               App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].Losses++;

           }
           Debug.WriteLine("bout to update the season...");
           dbHandler.updateSeason(App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason]); 
           NotifyPropertyChanged("GoalsScored");
           NotifyPropertyChanged("GoalsAllowed");
           NotifyPropertyChanged("GamesPlayed");
           NotifyPropertyChanged("Wins");
           NotifyPropertyChanged("Losses");
           dbHandler.updateGame(game); 

       }

       

       

        
       
    }
}