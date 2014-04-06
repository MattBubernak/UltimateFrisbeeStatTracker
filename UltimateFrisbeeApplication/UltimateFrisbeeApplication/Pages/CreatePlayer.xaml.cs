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
    public partial class CreatePlayer : PhoneApplicationPage
    {
        public CreatePlayer()
        {
            InitializeComponent();
        }

        private void Save_Player(object sender, EventArgs e)
        {
            //maybe should be handled by viewModel?? 
            Player newPlayer = new Player(FNameBox.Text, LNameBox.Text, PhoneBox.Text, EmailBox.Text); 
            App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].players.Add(newPlayer);
            NavigationService.Navigate(new Uri("/Pages/Season.xaml", UriKind.Relative)); 
        }
    }
}