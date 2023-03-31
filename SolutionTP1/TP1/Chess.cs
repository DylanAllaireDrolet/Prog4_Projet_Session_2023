using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public class Chess
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Chess echec = new Chess();
        }

        // Members
        private FormMenu _menu; // <- App menu
        private List<Game> _games; // <- List of all the games
        public const int WHITE = 1;
        public const int BLACK = 2;

        // Properties
        public FormMenu Menu
        {
            get { return _menu; }
        }
        public Game this[int i]
        {
            get { return _games[i]; }
            set { _games[i] = value; }
        }

        // Constructor
        public Chess()
        {
            _games = new List<Game>();
            FormMenu _menu = new FormMenu(this);
            Application.Run(_menu);
        }

        public void newGame(Player white, Player Black)
        {
            _games.Add(new Game(white, Black));
        }
        public void newGame()
        {
            _games.Add(new Game());
        }
    }
}