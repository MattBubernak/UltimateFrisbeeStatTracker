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
    public partial class GameViewPage : PhoneApplicationPage
    {
        public GameViewPage()
        {
            InitializeComponent();
            DataContext = App.GameViewModel; 
        }

        private void ActivePlayerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //nothing in here for now...
        }
        public void Edit_Game()
        {

        }
    }
}