using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace UltimateFrisbeeApplication.Models
{
    public class Manager
    {
        public ObservableCollection<Team> teams;
        public int currentTeam;
        public int currentSeason;
        public int currentPlayer;
        public int currentGame;
        public int numTeams; 

        public Manager()
        {
            teams = new ObservableCollection<Team>();
            currentTeam = 0;
            currentSeason = 0;
            currentPlayer = 0;
            currentGame = 0;
            numTeams = 0; 
        }

        //add a team to the collection of teams a manager has. In the future this may add a team to the DB as well. 
        public void addTeam(string name)
        {
            this.teams.Add(new Team(name));
            this.numTeams++;
        }

        public ObservableCollection<Team> getTeams()
        {
            return teams; 
        }
    }
}
