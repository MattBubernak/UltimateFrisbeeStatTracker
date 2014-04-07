using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace UltimateFrisbeeApplication.Pages
{
    public partial class ActivePlayerGamePage : PhoneApplicationPage
    {
        public ActivePlayerGamePage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //string is being passed, but we aren't really using it at the moment.... because we also update the Manager model that has a current player field. 
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("playerIndex", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
            }
            DataContext = App.ActivePlayerViewModel; 

        }


        private void Update_Player_Stats(object sender, EventArgs e)
        {
            //push all the player stats from this page to the player in the game.... 

            NavigationService.Navigate(new Uri("/Pages/ActivegamePage.xaml", UriKind.Relative)); 
        }

        private void PlusGoal(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Goals", 1);
            App.GameViewModel.game.score++; 
        }

        private void MinusGoal(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Goals", -1);

        }

        private void PlusAssist(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Assists", 1);

        }

        private void MinusAssist(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Assists", -1);

        }

        private void PlusD(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Defenses", 1);

        }

        private void MinusD(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Defenses", -1);

        }

        private void PlusTurnover(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Turnovers", 1);

        }

        private void MinusTurnover(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Turnovers", -1);

        }

        private void PlusPoint(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Points", 1);

        }

        private void MinusPoint(object sender, RoutedEventArgs e)
        {
            App.ActivePlayerViewModel.changeStat("Points", -1);

        }
    }
}