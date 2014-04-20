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
            App.PlayerViewModel.createPlayer(FNameBox.Text, LNameBox.Text, PhoneBox.Text, EmailBox.Text);
            NavigationService.Navigate(new Uri("/Pages/TeamPage.xaml?panoramaIndex=1", UriKind.Relative)); 
        }
    }
}