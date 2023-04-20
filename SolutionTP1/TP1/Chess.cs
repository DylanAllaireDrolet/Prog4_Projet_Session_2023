using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    /// <summary>
    /// Chess class
    /// </summary>
    public class Chess
    {
        public const int CAPYBARA_PRINCE = 1;
        /// <summary>
        /// Entry point of program
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Chess echec = new Chess();
        }

        // Members

        /// <summary>
        /// Form menu
        /// </summary>
        private FormMenu _menu; // <- App menu

        /// <summary>
        /// List of all games
        /// </summary>
        private List<Game> _games; // <- List of all the games

        /// <summary>
        /// Constant for White = 1
        /// </summary>
        public const int WHITE = 1; // White color

        /// <summary>
        ///  Const for black = 2
        /// </summary>
        public const int BLACK = 2; // Black color

        // Properties

        /// <summary>
        /// Menu property
        /// </summary>
        public FormMenu Menu
        {
            get { return _menu; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">Games at i index</param>
        /// <returns>Games at i index</returns>
        public Game this[int i]
        {
            get { return _games[i]; }
            set { _games[i] = value; }
        }

        // Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Chess()
        {
            _games = new List<Game>();
            FormMenu _menu = new FormMenu(this);
            Application.Run(_menu);
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="white">White Player</param>
        /// <param name="Black">Black Player</param>
        public void newGame(Player white, Player black)
        {
            _games.Add(new Game(white, black, this));
        }
        public void newGame(Player white, Player black, int gameMode)
        {
            _games.Add(new Game(white, black, this, gameMode));
        }
        /// <summary>
        /// New game for testing (without players)
        /// </summary>
        public void newGame()
        {
            _games.Add(new Game(this));
        }
    }
}