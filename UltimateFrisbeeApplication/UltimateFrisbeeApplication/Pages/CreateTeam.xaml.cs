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
    public partial class CreateTeam : PhoneApplicationPage
    {
        public CreateTeam()
        {
            InitializeComponent();
        }

        private void Save_Team(object sender, EventArgs e)
        {
            //TODO: Add team to Database
   
            if (TeamNameBox.Text == "")
            {
                //throw some sort of error? 
            }
            else
            {
                string name = TeamNameBox.Text;
                App.ManagerViewModel.addTeam(name); 
                NavigationService.Navigate(new Uri("/Pages/TeamsPage.xaml", UriKind.Relative));
            }
        }
    }
}