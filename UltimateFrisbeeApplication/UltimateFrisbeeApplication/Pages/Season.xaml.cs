using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using UltimateFrisbeeApplication.Models; 

namespace UltimateFrisbeeApplication.Pages
{
    public partial class Season : PhoneApplicationPage
    {
        public Season()
        {
            InitializeComponent();
            //set a data context to the current season 
            DataContext = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason]; 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //when this page is navigated to, it is passed the integer of the panorama item to default to. Change default value to it. 
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("panoramaIndex", out selectedIndex))
            {
                Debug.WriteLine("Recieved:" + selectedIndex);
                int index = int.Parse(selectedIndex);
                PanoramaControl.DefaultItem = PanoramaControl.Items[index];
                UpdatePanoramaAppBar(index); 
            }

        }

        private void Add_Player(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/CreatePlayer.xaml", UriKind.Relative)); 
        }

        private void New_Game(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/NewGame.xaml", UriKind.Relative)); 
        }
   

        private void PanoramaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentPanoramaIndex = PanoramaControl.SelectedIndex;
            UpdatePanoramaAppBar(currentPanoramaIndex); 
        }


        void UpdatePanoramaAppBar(int index)
        {
            switch (index)
            {
                case 0:
                    ApplicationBar.IsVisible = true;

                    //clear the application bar, maybe not the best way to do it? 
                    ApplicationBar = new ApplicationBar();
                    //hide the application bar 
                    //ApplicationBar.IsVisible = false; 
                    ApplicationBarIconButton add = new ApplicationBarIconButton();
                    add.Text = "New Game";
                    add.IconUri = new Uri("/Images/add.png", UriKind.Relative);
                    add.Click += new EventHandler(New_Game);
                    ApplicationBar.Buttons.Add(add);
                    break;
                case 1:
                    ApplicationBar.IsVisible = true;
                    //clear the application bar, maybe not the best way to do it? 
                    ApplicationBar = new ApplicationBar();

                    //create a plus button
                    ApplicationBarIconButton newGame = new ApplicationBarIconButton();
                    newGame.Text = "Add Player";
                    newGame.IconUri = new Uri("/Images/add.png", UriKind.Relative);
                    newGame.Click += new EventHandler(Add_Player);
                    ApplicationBar.Buttons.Add(newGame);
                    break;
                case 2:

                    //clear the application bar, maybe not the best way to do it? 
                    ApplicationBar = new ApplicationBar();
                    //hide the application bar 
                    //ApplicationBar.IsVisible = false; 
                    break;
            }
        }

        private void PlayerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grab the index from the selector on the page 
            int index = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons[App.ManagerViewModel.currentSeason].players.IndexOf(PlayerSelector.SelectedItem as Player);
            String selectedTeam = index.ToString();
            //TODO: Change this implementation from global somehow? 
            App.ManagerViewModel.currentPlayer = index;
            //Pass the index of the curren team to the team page 
            NavigationService.Navigate(new Uri("/Pages/PlayerPage.xaml?playerIndex=" + selectedTeam, UriKind.Relative));
        }

        private void GameSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}