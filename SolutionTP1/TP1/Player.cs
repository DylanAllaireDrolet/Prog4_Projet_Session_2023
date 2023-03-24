using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Player
    {
        // Members
        private string _name;
        private int _gameWon;
        private int _gameLost;
        private int _gameNull;

        // Properties
        public string Name { get { return _name; } set { _name = value; } }

        // Overloading
        public static Player operator ++ (Player p)
        {
            p.Wins = p.Wins + 1;
            return p;
        }
        public static Player operator -- (Player p)
        {
            p.GamesLost = p.GamesLost + 1;
            return p;
        }

        public int Wins
        {
            get
            {
                return _gameWon;
            }
            set
            {
                if(value >= 0)
                    _gameWon = value;
            }
        }
        public int GamesLost
        {
            get { return _gameLost; }
            set
            {
                if (value >= 0)
                    _gameLost = value; 
                
            }
        }
        public int GameDraw
        {
            get { return _gameNull; }
            set
            {
                if (value >= 0)
                    _gameNull = value;
            }
        }

        // Constructor
        public Player()
        {
            _name = "";
            _gameWon = 0;
            _gameLost = 0;
            _gameNull = 0;
        }
        public Player(string name)
        {
            _name = name;
            _gameWon = 0;
            _gameLost = 0;
            _gameNull = 0;
        }
        public Player(string name, int wins, int lost, int nullGame)
        {
            _name = name;
            _gameWon = wins;
            _gameLost = lost;
            _gameNull = nullGame;
        }
    }
}
