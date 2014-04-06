using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UltimateFrisbeeApplication.Resources;
using UltimateFrisbeeApplication.Models; 


namespace UltimateFrisbeeApplication.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {
       //managers have teams. 
       public ObservableCollection<Team> Teams { get; private set; }
       public int numTeams { get; set; }
       public int currentTeam { get; set; }
       public int currentSeason { get; set; }
       public int currentPlayer { get; set; }
       public int currentGame { get; set; }

       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public ManagerViewModel()
       {
           this.Teams = new ObservableCollection<Team>();
           this.numTeams = 0;
           this.currentTeam = 0;
           this.currentSeason = 0;
           this.currentPlayer = 0;
           this.currentGame = 0; 
       }


       //add a team to the collection of teams a manager has. In the future this may add a team to the DB as well. 
       public void addTeam(string name)
       {
           this.Teams.Add(new Team(name));
           this.numTeams++; 
       }
       
    }
}