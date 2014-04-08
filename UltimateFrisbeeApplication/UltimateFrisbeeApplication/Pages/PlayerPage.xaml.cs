using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks; 

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
                App.Manager.currentPlayer = index;
                App.PlayerViewModel.update(); //false indicates we are not viewing a player who is in-game 
                DataContext = App.PlayerViewModel;
            }
        }

        private void Edit_Player(object sender, EventArgs e)
        {

        }

        private void Call_Player(object sender, EventArgs e)
        {
            App.PlayerViewModel.CallPLayer(); 
        }

        private void Email_Player(object sender, EventArgs e)
        {
            App.PlayerViewModel.EmailPLayer(); 
        }

    }
}