﻿using System;
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


        //adds a manager object to the database 
        public async void add_manager(manager_db manager)
        {
            await App.MobileService.GetTable<manager_db>().InsertAsync(manager);
            Debug.WriteLine("Just added a new manager to the DB");
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
            Debug.WriteLine("just updated a game in the DB");
        }

        public async void updateSeason(Season season)
        {
            Debug.WriteLine("ready to update the season in the DB");

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
            Debug.WriteLine("just updated the season in the DB");
        }


        public async void updatePlayer(Player player)
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

            await playerTable.UpdateAsync(players[0]); 
            Debug.WriteLine("just updated a player in the DB");
        }

        public async void add_team(team_db team)
        {
            Debug.WriteLine("Adding the following team");
            Debug.WriteLine("Manager ID:" + team.manager_id);
            Debug.WriteLine("Team Name" + team.name);
            await App.MobileService.GetTable<team_db>().InsertAsync(team);
            Debug.WriteLine("Just added a new team to the DB");


            //add the team to our manager model 
            Debug.WriteLine("Team ID:" + team.ID);
            Team newTeam = new Team(team.name); 
            newTeam.Manager_ID = App.Manager.ID;
            newTeam.ID = team.ID;
            App.Manager.teams.Add(newTeam);
            App.Manager.currentTeam = App.Manager.teams.Count - 1; 
            //create a season for this team
            season_db newSeason = new season_db();
            newSeason.manager_id = App.Manager.ID;
            newSeason.team_id = newTeam.ID; 
            add_season(newSeason);

        }
        public async void add_player(player_db player)
        {
            await App.MobileService.GetTable<player_db>().InsertAsync(player);
            Debug.WriteLine("Just added a new player to the DB");
            //add player to the model 
            Player newPlayer = new Player(player.Fname, player.Lname, player.Phone, player.Email, player.team_id);
            newPlayer.ID = player.ID; 
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players.Add(newPlayer);
           
        }
        public async void add_inGamePlayer(InGamePlayer_db ingameplayer)
        {
            await App.MobileService.GetTable<InGamePlayer_db>().InsertAsync(ingameplayer);
            Debug.WriteLine("Just added a new ingameplayer to the DB");
        }
        public async void add_season(season_db season)
        {
            Debug.WriteLine("add season....");

            await App.MobileService.GetTable<season_db>().InsertAsync(season);
            Debug.WriteLine("Just added a new season to the DB");
            App.Manager.teams[App.Manager.currentTeam].seasons.Add(new Season(App.Manager.teams[App.Manager.currentTeam].ID));
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID = season.ID;
            App.Manager.teams[App.Manager.currentTeam].seasons.Add(new Season(season.ID));

            Debug.WriteLine("New Season ID: " +  App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].ID);
            Debug.WriteLine("current team: " + App.Manager.currentTeam + "current season: " + App.Manager.currentSeason);
        }

        public async void add_game(game_db game)
        {
            await App.MobileService.GetTable<game_db>().InsertAsync(game);
            Debug.WriteLine("Just added a new game to the DB");
            Game newGame = new Game(game.opponent, game.location, game.tournament, game.cap, game.date, game.season_id, game.ID) ;
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame].season_id = game.season_id;
            App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame].ID = game.ID;

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
                    Debug.WriteLine("adding team: " + team.name + " id: " + team.ID + "\n");
                    App.Manager.teams.Add(new Team(team.name,team.ID));
                    //grab each season 
                    seasons = await seasonTable
                    .Where(season_db => season_db.team_id == team.ID)
                    .ToCollectionAsync();
                    App.Manager.currentSeason = 0; 
                    App.Manager.currentPlayer = 0;
                    App.Manager.currentActivePlayer = 0;
                    App.Manager.currentGame = 0;
                    foreach (season_db season in seasons)
                    {
                        Debug.WriteLine("adding season id: " + season.ID + "goalsscored: " + season.GoalsScored + "curent season: " + App.Manager.currentSeason);
                        App.Manager.teams[App.Manager.currentTeam].seasons.Add(new Season(season.ID,season.Wins,season.Losses,season.GoalsScored,season.GoalsAllowed,season.GamesPlayed));
                        Debug.WriteLine("Goals Scored:" + App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].GoalsScored);
                        Debug.WriteLine("number of seasons:" + App.Manager.teams[App.Manager.currentTeam].seasons.Count);
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
                        Debug.WriteLine("grabbing players from this team and putting them in the season....\n");
                        Debug.WriteLine("comparing to team ID: " + team.ID);
                        players = await playerTable
                            .Where(player_db => player_db.team_id == team.ID)
                            .ToCollectionAsync();

                        foreach (player_db player in players)
                        {
                            Debug.WriteLine("Player:" + player.Fname);
                            Debug.WriteLine("current team: " + App.Manager.currentTeam + " current sesason: " + App.Manager.currentSeason);
                            Player newPlayer = new Player(player.Fname, player.Lname, player.Phone, player.Email, player.team_id,player.Goals,player.Assists,player.Turnovers,player.Points,player.Defenses,player.ID);
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
