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
    public partial class CreateSeason : PhoneApplicationPage
    {
        public CreateSeason()
        {
            InitializeComponent();
        }

        private void Save_Season(object sender, EventArgs e)
        {
            App.TeamViewModel.Create_Season(seasonBox.Text); 
            NavigationService.Navigate(new Uri("/Pages/TeamPage.xaml?panoramaIndex=1", UriKind.Relative)); 
        }
    }
}