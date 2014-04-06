using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
       //managers have teams. 
       public ObservableCollection<Team> Teams { get; private set; }
       public int numTeams { get; set; }


       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public TeamViewModel()
       {
           this.Teams = new ObservableCollection<Team>();
           this.numTeams = 0; 
       }

         
       //add a team to the collection of teams a manager has. In the future this may add a team to the DB as well. 
       public void addTeam(string name)
       {
           this.Teams.Add(new Team(name));
           this.numTeams++; 
       }
       
    }
}