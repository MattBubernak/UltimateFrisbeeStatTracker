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
    public partial class ActiveGamePage : PhoneApplicationPage
    {
        public ActiveGamePage()
        {
            InitializeComponent();
            int gameIndex = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games.Count-1;
            DataContext = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games[gameIndex]; 
        }

        private void ActivePlayerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grab the index from the selector on the page 
            int gameIndex = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games.Count-1;

            int index = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games[gameIndex].players.IndexOf(ActivePlayerSelector.SelectedItem as Player);
            String selectedTeam = index.ToString();
            //TODO: Change this implementation from global somehow? 
            App.ManagerViewModel.currentPlayer = index;
            //Pass the index of the curren team to the team page 
            //Pass the index of the curren team to the team page 
            NavigationService.Navigate(new Uri("/Pages/ActivePlayerGamePage.xaml?playerIndex="+index, UriKind.Relative));

        }

        private void PlusScore(object sender, RoutedEventArgs e)
        {

        }

        private void MinusScore(object sender, RoutedEventArgs e)
        {

        }

        private void PlusScore_Opp(object sender, RoutedEventArgs e)
        {

        }

        private void MinusScore_Opp(object sender, RoutedEventArgs e)
        {

        }
    }
}