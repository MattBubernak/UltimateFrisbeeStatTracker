using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UltimateFrisbeeApplication.Models; 


namespace UltimateFrisbeeApplication.Pages
{
    public partial class NewGame : PhoneApplicationPage
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void Save_Game(object sender, EventArgs e)
        {
            //add game to games list 
            Game newGame = new Game(OpponentBox.Text,LocationBox.Text,TournamentBox.Text, Convert.ToInt32(CapBox.Text));
            App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games.Add(newGame); 
            //determine number of games 
            int gameIndex = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games.Count - 1; 

            //for every player on the team, for this season, add him to the specific game instance. 
            foreach (Player player in  App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].players)
            {
                App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games[gameIndex].players.Add(player); 
            }
            //navigate to active game page 
            NavigationService.Navigate(new Uri("/Pages/ActiveGamePage.xaml", UriKind.Relative));

        }
    }
}