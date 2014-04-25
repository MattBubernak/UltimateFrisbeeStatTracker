using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.ViewModels;
using UltimateFrisbeeApplication.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.IO.IsolatedStorage;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace UltimateFrisbeeApplication.Models
{
    public class DBHandler
    {
        //initialize the mobile service 
        public static MobileServiceClient MobileService = new MobileServiceClient(
           "https://ultimatestatswindowsphone.azure-mobile.net/",
           "gSqrDAevsJmkuAanFLEHbYKPOnQYiM80"
           );
        //grab team table 
        private IMobileServiceTable<team_db> teamTable = App.MobileService.GetTable<team_db>();
        private IMobileServiceTable<season_db> seasonTable = App.MobileService.GetTable<season_db>();
        private IMobileServiceTable<player_db> playerTable = App.MobileService.GetTable<player_db>();
        private IMobileServiceTable<game_db> gameTable = App.MobileService.GetTable<game_db>();
        private IMobileServiceTable<InGamePlayer_db> ingameTable = App.MobileService.GetTable<InGamePlayer_db>();
        private IMobileServiceTable<SeasonPlayer_db> seasonplayerTable = App.MobileService.GetTable<SeasonPlayer_db>();


        //adds a manager object to the database 
        public async void add_manager(manager_db manager)
        {
            await App.MobileService.GetTable<manager_db>().InsertAsync(manager);
        }

        public async void updateGame(Game game)
        {
            MobileServiceCollection<game_db, game_db> games;
            games = await gameTable
                    .Where(game_db => game_db.ID == game.ID)
                    .ToCollectionAsync();
            games[0].score = game.score;
            games[0].scoreOpp = game.scoreOpp; 
            await gameTable.UpdateAsync(games[0]); 
        }

        public async void updateSeason(Season season)
        {

            MobileServiceCollection<season_db, season_db> seasons;
            seasons = await seasonTable
                    .Where(season_db => season_db.ID == season.ID)
                    .ToCollectionAsync();
            seasons[0].GoalsAllowed = season.GoalsAllowed;
            seasons[0].GoalsScored = season.GoalsScored;
            seasons[0].Losses = season.Losses;
            seasons[0].Wins = season.Wins;
            seasons[0].GamesPlayed = season.GamesPlayed;
            await seasonTable.UpdateAsync(seasons[0]);
        }


        public async void update_player(Player player)
        {
            MobileServiceCollection<player_db, player_db> players;
            players = await playerTable
                    .Where(player_db => player_db.ID == player.ID)
                    .ToCollectionAsync();
            players[0].Assists = player.Assists;
            players[0].Goals = player.Goals;
            players[0].Turnovers = player.Turnovers;
            players[0].Points = player.Points;
            players[0].Defenses = player.Defenses;
            players[0].Fname = player.Fname;
            players[0].Lname = player.Lname;
            players[0].Email = player.Email;
            players[0].Phone = player.Phone; 
            await playerTable.UpdateAsync(players[0]); 
        }

        public async void update_seasonplayer(SeasonPlayer player)
        {
            MobileServiceCollection<SeasonPlayer_db, SeasonPlayer_db> seasonplayers;

            //this is breaking it!
            seasonplayers = await seasonplayerTable
                    .Where(seasonplayer_db => seasonplayer_db.ID == player.ID)
                    .ToCollectionAsync();
            seasonplayers[0].Assists = player.Assists;
            seasonplayers[0].Goals = player.Goals;
            seasonplayers[0].Turnovers = player.Turnovers;
            seasonplayers[0].Points = player.Points;
            seasonplayers[0].Defenses = player.Defenses;
            seasonplayers[0].Fname = player.Fname;
            seasonplayers[0].Lname = player.Lname;
            seasonplayers[0].Email = player.Email;
            seasonplayers[0].Phone = player.Phone;
            seasonplayers[0].Season_ID = player.Season_ID; 
            await seasonplayerTable.UpdateAsync(seasonplayers[0]);
        }

        public async void add_team(team_db team)
        {
      
            await App.MobileService.GetTable<team_db>().InsertAsync(team);


            //add the team to our manager model 
            Team newTeam = new Team(team.name); 
            newTeam.Manager_ID = App.Manager.ID;
            newTeam.ID = team.ID;
            App.Manager.teams.Add(newTeam);
            App.Manager.currentTeam = App.Manager.teams.Count - 1; 
           

        }
        public async void add_player(player_db player)
        {
            //add the player to the database 
            await App.MobileService.GetTable<player_db>().InsertAsync(player);
            //add player to the model, using player ID from the database 

            Player newPlayer = new Player(player.Fname, player.Lname, player.Phone, player.Email, player.team_id);
            newPlayer.ID = player.ID; 
            App.Manager.teams[App.Manager.currentTeam].players.Add(newPlayer);

            //create a season db instance of the player in the current season, need player ID to do this. 

            SeasonPlayer_db seasonplayer = new SeasonPlayer_db(player);
            seasonplayer.Season_ID = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID;

            add_seasonPlayer(seasonplayer);
 

        }
        public async void add_inGamePlayer(InGamePlayer_db ingameplayer)
        {
            await App.MobileService.GetTable<InGamePlayer_db>().InsertAsync(ingameplayer);

        }

        public async void add_seasonPlayer(SeasonPlayer_db seasonplayer)
        {
           // await App.MobileService.GetTable<SeasonPlayer_db>().InsertAsync(new SeasonPlayer_db(new Player()));

            await App.MobileService.GetTable<SeasonPlayer_db>().InsertAsync(seasonplayer);
            SeasonPlayer newSeasonPlayer = new SeasonPlayer(seasonplayer);
            seasonplayer.Season_ID = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID;
            //add season player to the team 

            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.Add(new SeasonPlayer(seasonplayer.ID, seasonplayer.BasePlayerID, seasonplayer.Season_ID, seasonplayer.Fname, seasonplayer.Lname, seasonplayer.Email, seasonplayer.Phone));
            Debug.WriteLine("just added a season player with season_ID: " + seasonplayer.Season_ID); 
        }


        public async void add_season(season_db season)
        {

            await App.MobileService.GetTable<season_db>().InsertAsync(season);
            //add season to the team once we have an ID 
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID = season.ID;
            Debug.WriteLine("current season id(inside add_season): " + App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID);

            foreach (SeasonPlayer player in App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players)
            {
                Debug.WriteLine("giving player:" + player.FullName + " season id: " + season.ID);
                player.Season_ID = season.ID;
                update_seasonplayer(player); 
            }

        }

        public async void add_game(game_db game)
        {
            await App.MobileService.GetTable<game_db>().InsertAsync(game);
            Game newGame = new Game(game.opponent, game.location, game.tournament, game.cap, game.date, game.season_id, game.ID) ;
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].activeGame.season_id = game.season_id;
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].activeGame.ID = game.ID;

        }

        public async void populate_model(string man_id)
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems
            MobileServiceCollection<team_db, team_db> teams;
            MobileServiceCollection<season_db, season_db> seasons;
            MobileServiceCollection<game_db, game_db> games;
            MobileServiceCollection<player_db, player_db> players;
            MobileServiceCollection<InGamePlayer_db, InGamePlayer_db> inGamePlayers;


            try
            {
                teams = await teamTable
                    .Where(team_db => team_db.manager_id == man_id)
                    .ToCollectionAsync();

                //for each team, place it in our team model 
                foreach (team_db team in teams)
                {
                    App.Manager.teams.Add(new Team(team.name,team.ID));
                    //grab each season 
                    seasons = await seasonTable
                    .Where(season_db => season_db.team_id == team.ID)
                    .ToCollectionAsync();
                    App.Manager.currentSeason = 0; 
                    App.Manager.currentPlayer = 0;
                    App.Manager.currentActivePlayer = 0;
                    App.Manager.currentGame = 0;

                    players = await playerTable
                            .Where(player_db => player_db.team_id == team.ID)
                            .ToCollectionAsync();
                    foreach (player_db player in players)
                    {
                        Player newPlayer = new Player(player.Fname, player.Lname, player.Phone, player.Email, player.team_id, player.Goals, player.Assists, player.Turnovers, player.Points, player.Defenses, player.ID);
                        App.Manager.teams[App.Manager.currentTeam].players.Add(newPlayer);
                    }


                    foreach (season_db season in seasons)
                    {
                        App.Manager.teams[App.Manager.currentTeam].seasons.Add(new Season(season.Name, season.ID, season.Wins, season.Losses, season.GoalsScored, season.GoalsAllowed, season.GamesPlayed));
                        games = await gameTable
                            .Where(game_db => game_db.season_id == season.ID)
                            .ToCollectionAsync();

                        foreach (game_db game in games)
                        {
                            Game newGame = new Game(game.opponent,game.location,game.tournament,game.cap,game.date,season.ID,game.ID,game.score,game.scoreOpp);

                            inGamePlayers = await ingameTable
                                 .Where(InGamePlayer_db => InGamePlayer_db.game_id == game.ID)
                                 .ToCollectionAsync();
                            foreach (InGamePlayer_db player in inGamePlayers)
                            {
                                newGame.players.Add(new InGamePlayer(player.FName, player.LName, player.Assists, player.Defenses, player.Points, player.Goals, player.Turnovers));
                            }

                            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games.Add(newGame);

                            App.Manager.currentGame++;                         
                        }
                        MobileServiceCollection<SeasonPlayer_db, SeasonPlayer_db> seasonPlayers;

                        //await App.MobileService.GetTable<SeasonPlayer_db>().InsertAsync(new SeasonPlayer_db());


                        seasonPlayers = await seasonplayerTable
                            .Where(SeasonPlayer_db => SeasonPlayer_db.Season_ID == season.ID).ToCollectionAsync();

                        foreach (SeasonPlayer_db player in seasonPlayers)
                        {
                            SeasonPlayer newPlayer = new SeasonPlayer(player.ID, player.BasePlayerID, player.Season_ID, player.Fname, player.Lname, player.Email, player.Phone, player.Goals, player.Assists, player.Defenses, player.Points, player.Turnovers);
                            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.Add(newPlayer);
                        }
                        

                        //incrament season index 
                        App.Manager.currentSeason++; 

                    }

                    //incrament team index 
                    App.Manager.currentTeam++; 

                    //App.ManagerViewModel.Teams.Add(new Team(team.name)); 
                }

                App.ManagerViewModel.removeLoadingBar(); 
            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading teams", MessageBoxButton.OK);
            }

            App.Manager.currentSeason = 0;
            App.Manager.currentTeam = 0;
            App.Manager.currentPlayer = 0;
            App.Manager.currentGame = 0; 


        }

        public async void get_teams(string man_id)
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems
            MobileServiceCollection<team_db, team_db> teams;

            try
            {
                teams = await teamTable
                    .Where(team_db => team_db.manager_id == man_id)
                    .ToCollectionAsync();

                //for each team, place it in our team model 
                App.Manager.teams.Clear(); 

                foreach (team_db team in teams)
                {
                    App.Manager.teams.Add(new Team(team.name));
                    //App.ManagerViewModel.Teams.Add(new Team(team.name)); 
                }

            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading teams", MessageBoxButton.OK);
            }

           

           
        }


    }
}
