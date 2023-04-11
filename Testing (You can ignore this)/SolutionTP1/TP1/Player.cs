using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Player Class
    /// </summary>
    public class Player
    {
        // Members
        private string _name; // Name of player
        private int _gameWon; // Games won
        private int _gameLost; // Games lost
        private int _gameNull; // Games drew

        // Properties
        /// <summary>
        /// Name of player
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        // Overloading
        /// <summary>
        /// Overloading ++ operator
        /// </summary>
        /// <param name="p">Player to ++</param>
        /// <returns></returns>
        public static Player operator ++ (Player p)
        {
            p.Wins = p.Wins + 1;
            return p;
        }

        /// <summary>
        /// Overloading -- operator
        /// </summary>
        /// <param name="p">Player to --</param>
        /// <returns></returns>
        public static Player operator -- (Player p)
        {
            p.GamesLost = p.GamesLost + 1;
            return p;
        }

        /// <summary>
        /// Overloading == operator
        /// </summary>
        /// <param name="p1">First player to compare</param>
        /// <param name="p2">Second player to compare</param>
        /// <returns></returns>
        public static bool operator == (Player p1, Player p2)
        {
            if (p1.Name == p2.Name && p1.Wins == p2.Wins && p1.GamesLost == p2.GamesLost && p1.GameDraw == p2.GameDraw)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Overload != operator
        /// </summary>
        /// <param name="p1">First player to compare</param>
        /// <param name="p2">Second player to compare</param>
        /// <returns></returns>
        public static bool operator != (Player p1, Player p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Player wins
        /// </summary>
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

        /// <summary>
        /// Games lost
        /// </summary>
        public int GamesLost
        {
            get { return _gameLost; }
            set
            {
                if (value >= 0)
                    _gameLost = value; 
                
            }
        }

        /// <summary>
        /// Game drew
        /// </summary>
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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Player()
        {
            _name = "";
            _gameWon = 0;
            _gameLost = 0;
            _gameNull = 0;
        }

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="name">name of player</param>
        public Player(string name)
        {
            _name = name;
            _gameWon = 0;
            _gameLost = 0;
            _gameNull = 0;
        }

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="name">name of player</param>
        /// <param name="wins">wins of player</param>
        /// <param name="lost">lost's of player</param>
        /// <param name="nullGame">Games drew</param>
        public Player(string name, int wins, int lost, int nullGame)
        {
            _name = name;
            _gameWon = wins;
            _gameLost = lost;
            _gameNull = nullGame;
        }

        // Methods
        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj">Objet to compare</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (Player)obj == this ? true : false;
        }

        /// <summary>
        /// ToString function
        /// </summary>
        /// <returns>String version of player</returns>
        public override string ToString()
        {
            return _name + ' ' + _gameWon + ' ' + _gameLost + ' ' + _gameNull;
        }
    }
}
