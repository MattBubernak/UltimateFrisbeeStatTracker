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

       //constructor for a manager view model. In the future this may query the DB to produce the list of teams
       public ManagerViewModel()
       {
           this.Teams = App.Manager.getTeams();
       }
       
    }
}