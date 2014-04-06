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
    public partial class PlayerPage : PhoneApplicationPage
    {
        public PlayerPage()
        {
            InitializeComponent();
            DataContext = App.PlayerViewModel; 
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("playerIndex", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ManagerViewModel.Teams[App.Manager.currentTeam].seasons[App.Manager.currentSeason].players[index];
            }
        }

        private void Edit_Player(object sender, EventArgs e)
        {

        }

        private void Call_Player(object sender, EventArgs e)
        {

        }

        private void Email_Player(object sender, EventArgs e)
        {

        }

    }
}