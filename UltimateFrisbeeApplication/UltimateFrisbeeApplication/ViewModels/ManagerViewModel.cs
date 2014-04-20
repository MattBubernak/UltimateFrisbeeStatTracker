using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;


namespace UltimateFrisbeeApplication.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {
       //managers have teams. 
       public ObservableCollection<Team> Teams { get; private set; }
       public string ID { get; set; }
       public Visibility loading { get; set; }
       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public ManagerViewModel()
       {
           this.Teams = App.Manager.getTeams();
           this.loading = Visibility.Visible; 
       }
       public void addTeam(Team team)
       {
           //add the team to the database 
           team_db newTeam = new team_db();
           newTeam.manager_id = App.Manager.ID;
           newTeam.name = team.Name;
           dbHandler.add_team(newTeam);

           

           

       }
        //refersh list of teams 
        public void update()
       {
           //dbHandler.get_teams(App.Manager.ID);
       }

        public void removeLoadingBar()
        {
            this.loading = Visibility.Collapsed;
            NotifyPropertyChanged("loading");
        }
       
    }
}