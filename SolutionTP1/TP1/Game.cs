using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public class Game
    {
        // Members
        private Board _board;
        private Player _pw;
        private Player _pb;
        private FormGame _myForm;

        // Properties
        public Board Board
        {
            get { return _board; }
        }
        public Player WhitePlayer
        {
            get { return _pw; }
        }
        public Player BlackPlayer
        {
            get { return _pb; }
        }
        public FormGame MyForm
        {
            get { return _myForm; }
        }

        // Consctructor
        public Game(Player white, Player black)
        {
            _pw = white;
            _pb = black;
            _board = new Board();
            _myForm = new FormGame();
            Application.Run(_myForm);
        }
    }
}
