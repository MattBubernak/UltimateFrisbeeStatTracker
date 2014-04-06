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
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("playerIndex", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                int gameIndex = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games.Count - 1;

                DataContext = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].games[gameIndex].players[index];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Player_Stats(object sender, EventArgs e)
        {

        }

        private void PlusGoal(object sender, RoutedEventArgs e)
        {

        }

        private void MinusGoal(object sender, RoutedEventArgs e)
        {

        }

        private void PlusAssist(object sender, RoutedEventArgs e)
        {

        }

        private void MinusAssist(object sender, RoutedEventArgs e)
        {

        }

        private void PlusD(object sender, RoutedEventArgs e)
        {

        }

        private void MinusD(object sender, RoutedEventArgs e)
        {

        }

        private void PlusTurnover(object sender, RoutedEventArgs e)
        {

        }

        private void MinusTurnover(object sender, RoutedEventArgs e)
        {

        }

        private void PlusPoint(object sender, RoutedEventArgs e)
        {

        }

        private void MinusPoint(object sender, RoutedEventArgs e)
        {

        }
    }
}