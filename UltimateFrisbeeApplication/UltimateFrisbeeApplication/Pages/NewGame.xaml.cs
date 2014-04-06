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
            //check if we can convert the cap to int, to avoid error 
            int cap;
            if (Int32.TryParse(CapBox.Text,out cap))
            {

            }
            else
            {
                cap = 13; 
            }
            Game newGame = new Game(OpponentBox.Text,LocationBox.Text,TournamentBox.Text, cap);
            App.GameViewModel.createGame(newGame); 

            //navigate to active game page 
            NavigationService.Navigate(new Uri("/Pages/ActiveGamePage.xaml", UriKind.Relative));

        }
    }
}