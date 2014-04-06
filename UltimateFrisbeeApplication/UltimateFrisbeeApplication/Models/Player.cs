using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFrisbeeApplication.Models
{
    public class Player
    {
        private string _Fname; 
        private string _Lname; 
        private string _Phone; 
        private string _Email; 
        private int _goals;
        private int _assists;
        private int _turnovers;
        private int _points; 
        private int _defenses; 

        public Player()
        {
            this._Fname = "John";
            this._Lname = "Doe";
            this._Phone = "7203631281";
            this._Email = "test@gmail.com";
            this._goals = 0;
            this._assists = 0;
            this._turnovers = 0;
            this._defenses = 0; 
            this._points = 0; 
        }
        public Player(string FName, string LName, string Phone = "None", string Email = "None")
        {
            this._Fname = FName;
            this._Lname = LName;
            this._Phone = Phone;
            this._Email = Email; 
        }

        //below methods are all for binding purposes, and get/set! 

        public string FName
        {
            get { return _Fname; }
            set { _Fname = value; }
        }
        public string LName
        {
            get { return _Lname; }
            set { _Lname = value; }
        }

        public string FullName
        {
            get { return _Fname +" "+ _Lname;  }
        }
        public string SeasonStats
        {
            get { return _goals + " goals, " + _assists + " assists, " + _turnovers + " turnovers"; }
        }

        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
            }
        }
        public int Goals
        {
            get { return _goals; }
            set
            {
                _goals = value;
            }
        }

        public int Defenses
        {
            get { return _defenses; }
            set
            {
                _defenses = value;
            }
        }
        public int Assists
        {
            get { return _assists; }
            set
            {
                _assists = value;
            }
        }
        public int Turnovers
        {
            get { return _turnovers; }
            set
            {
                _turnovers = value;
            }
        }
        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
            }
        }

    }
}
