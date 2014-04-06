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
            DataContext = App.GameViewModel; 
        }

        private void ActivePlayerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = App.Manager.teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].games[App.Manager.currentGame].players.IndexOf(ActivePlayerSelector.SelectedItem as Player);
            String selectedTeam = index.ToString();
            //TODO: Change this implementation from global somehow? 
            App.Manager.currentPlayer = index;
            //Pass the index of the curren team to the team page 
            NavigationService.Navigate(new Uri("/Pages/ActivePlayerGamePage.xaml?playerIndex="+index, UriKind.Relative));

        }

        private void PlusScore(object sender, RoutedEventArgs e)
        {
            App.GameViewModel.scorePlus(); 
        }

        private void MinusScore(object sender, RoutedEventArgs e)
        {
            App.GameViewModel.scoreMinus(); 
        }

        private void PlusScore_Opp(object sender, RoutedEventArgs e)
        {
            App.GameViewModel.scorePlusOpp(); 
        }

        private void MinusScore_Opp(object sender, RoutedEventArgs e)
        {
            App.GameViewModel.scoreMinusOpp(); 
        }

        private void Finish_Game(object sender, RoutedEventArgs e)
        {
            App.GameViewModel.completeGame();
            NavigationService.Navigate(new Uri("/Pages/TeamPage.xaml?panoramaIndex=0", UriKind.Relative));

        }
    }
}