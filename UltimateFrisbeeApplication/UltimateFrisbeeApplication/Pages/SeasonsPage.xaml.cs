﻿using System;
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
    public partial class SeasonsPage : PhoneApplicationPage
    {
        public SeasonsPage()
        {
            InitializeComponent();
            //set data context of this page to the ManagerViewModel
            DataContext = App.ManagerViewModel.Teams[App.Manager.currentTeam];
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.TeamViewModel.update(); 
        }


        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        private void Create_Team(object sender, EventArgs e)
        {
            //If user clicks "+" icon, navigate to the team creation page.             
            NavigationService.Navigate(new Uri("/Pages/CreateSeason.xaml", UriKind.Relative));
        }

        private void TeamSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grab the index from the selector on the page 
            //int index = App.ManagerViewModel.Teams.IndexOf(SeasonSelector.SelectedItem as Season);

            //set currentTeam of manager 
            //App.Manager.currentTeam = index; 
            
            //Navigate to team page 
            //NavigationService.Navigate(new Uri("/Pages/TeamPage.xaml?panoramaIndex=0", UriKind.Relative));
        }

        private void SeasonSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grab the index from the selector on the page 
            int index = App.ManagerViewModel.Teams[App.Manager.currentTeam].seasons.IndexOf(SeasonSelector.SelectedItem as Season);

            //set currentTeam of manager 
            App.Manager.currentSeason = index;
            App.TeamViewModel.update(); 
            //Navigate to team page 
            NavigationService.Navigate(new Uri("/Pages/TeamPage.xaml?panoramaIndex=0", UriKind.Relative));
        }
        
    }
}