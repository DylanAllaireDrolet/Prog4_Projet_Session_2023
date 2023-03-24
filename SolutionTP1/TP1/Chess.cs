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
            Chess echec = new Chess();
           /* Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);*/
        }

        // Members
        private FormMenu _menu; // <- App menu
        private List<Game> _games; // <- List of all the games

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
            FormMenu _menu = new FormMenu();
            Application.Run(_menu);
        }

        public void newGame(Player white, Player Black)
        {
            _games.Add(new Game(white, Black));
        }
    }
}