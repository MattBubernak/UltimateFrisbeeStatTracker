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

namespace UltimateFrisbeeApplication.Pages
{
    public partial class Season : PhoneApplicationPage
    {
        public Season()
        {
            InitializeComponent();    
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("teamIndex", out selectedIndex))
            {
                Debug.WriteLine("Recieved:"+selectedIndex); 
                int index = int.Parse(selectedIndex);
                DataContext = App.ManagerViewModel.Teams[index];
            }
        }

       

        private void Games_Click(object sender, RoutedEventArgs e)
        {
            //get current season index, aka the most recent season, because game click was pressed 
            App.ManagerViewModel.currentSeason = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons.Count - 1;
            //navigate to season page, pass it parameter for panorama page to default to. 
            NavigationService.Navigate(new Uri("/Pages/Season.xaml?panoramaIndex=" + 0, UriKind.Relative)); 
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            //get current season index, aka the most recent season, because game click was pressed 
            App.ManagerViewModel.currentSeason = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons.Count - 1;
            //navigate to season page, pass it parameter for panorama page to default to. 
            NavigationService.Navigate(new Uri("/Pages/Season.xaml?panoramaIndex=" + 2, UriKind.Relative)); 
        }

        private void Players_Click(object sender, RoutedEventArgs e)
        {
 
            //get current season index, aka the most recent season, because game click was pressed 
            App.ManagerViewModel.currentSeason = App.ManagerViewModel.Teams[App.ManagerViewModel.currentTeam].seasons.Count - 1;
            //navigate to season page, pass it parameter for panorama page to default to. 
            NavigationService.Navigate(new Uri("/Pages/Season.xaml?panoramaIndex=" + 1, UriKind.Relative)); 
        }

        private void Active_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {

        }

        private void New_Game(object sender, RoutedEventArgs e)
        {

        }

        private void Seasons_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}