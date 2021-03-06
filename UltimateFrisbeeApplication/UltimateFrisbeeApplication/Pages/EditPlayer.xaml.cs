﻿using System;
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
    public partial class EditPlayer : PhoneApplicationPage
    {
        public EditPlayer()
        {
            InitializeComponent();
            DataContext = App.PlayerViewModel; 

        }

        private void Save_Player(object sender, EventArgs e)
        {
            App.PlayerViewModel.updatePlayerInfo(FNameBox.Text, LNameBox.Text, EmailBox.Text, PhoneBox.Text);
            NavigationService.Navigate(new Uri("/Pages/TeamPage.xaml", UriKind.Relative));

        }
    }
}