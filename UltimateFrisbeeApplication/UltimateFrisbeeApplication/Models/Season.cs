using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class Season 
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAllowed { get; set; }
        public int GamesPlayed { get; set; }
        public ObservableCollection<Player> players { get; private set; }
        public ObservableCollection<Game> games { get; set;  }
        public Game activeGame { get; set;  }
        public Season()
        {
            this.Name = "Season1"; 
            this.Wins = 0;
            this.Losses = 0;
            this.GoalsScored = 0;
            this.GoalsAllowed = 0;
            this.GamesPlayed = 0; 
            this.players = new ObservableCollection<Player>();
            //for testing purposes....
            this.players.Add(new Player("Matt", "Bubernak", "723444111", "nud@gmail.com"));
            this.players.Add(new Player("Sarah", "Feller", "723444111", "nud@gmail.com"));
            this.players.Add(new Player("Mark", "Cousins", "723444111", "nud@gmail.com"));
            this.players.Add(new Player("Fred", "Flinstone", "723444111", "nud@gmail.com"));

            this.games = new ObservableCollection<Game>(); 
        }




    }
}
