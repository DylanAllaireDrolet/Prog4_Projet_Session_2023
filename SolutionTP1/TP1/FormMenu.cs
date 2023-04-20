using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP1
{
    /// <summary>
    /// FormMenu class
    /// </summary>
    public partial class FormMenu : Form
    {
        // Members
        private List<Player> _players; // List of all players
        private Chess _chess; // Chess Controller

        // Properties
        /// <summary>
        /// Indexer for Players
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Players at i index</returns>
        public Player this[int i]
        {
            get { return _players[i]; }
        }

        /// <summary>
        /// Chess property
        /// </summary>
        public Chess chess
        {
            get { return _chess; }
            set { _chess = value; }
        }
        // Constructor

        /// <summary>
        /// Default FormMenu constructor
        /// </summary>
        /// <param name="chess"></param>
        public FormMenu(Chess chess)
        {
            _chess = chess;
            _players = new List<Player>();
            InitializeComponent();
            initFile();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~FormMenu()
        {
            updateFile();
        }

        // Methods

        /// <summary>
        /// Initialize file
        /// </summary>
        public void initFile()
        {
            if (File.Exists("./players.txt"))
            {
                StreamReader sr = new StreamReader("./players.txt");
                string line = "";
                string[] player;

                while ((line = sr.ReadLine()) != null)
                {
                    lsbPlayers.Items.Insert(0, line);
                    player = line.Split(' ');
                    _players.Add(new Player(player[0], int.Parse(player[1]), int.Parse(player[2]), int.Parse(player[3])));
                }
                sr.Close();
            }
            else
            {
                File.Create("./players.txt");
            }
        }

        /// <summary>
        /// Updates the file
        /// </summary>
        public void updateFile()
        {
            StreamWriter sw = new StreamWriter("./players.txt");
            foreach (Player p in _players)
            {
                sw.WriteLine(p.ToString());
            }
            sw.Close();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                StreamWriter sw = new StreamWriter("./players.txt", true);
                sw.WriteLine(tbName.Text + " 0" + " 0" + " 0");
                sw.Close();
                lsbPlayers.Items.Insert(0, tbName.Text + " 0" + " 0" + " 0");
                _players.Add(new Player(tbName.Text));
            }
            else
            {
                MessageBox.Show("Error - You need to fill the username box!", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            if (pnlPlayers.Visible)
                pnlPlayers.Visible = false;
            else
                pnlPlayers.Visible = true;
        }

        private void StripMenuPlayers_Click(object sender, EventArgs e)
        {
            btnPlayers_Click(sender, e);
        }

        private void lsbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Visible = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string[] player = lsbPlayers.Text.Split(' ');

            DialogResult result = MessageBox.Show("You're about to delete a user. Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Player toRmv = new Player(player[0], int.Parse(player[1]), int.Parse(player[2]), int.Parse(player[3]));
                _players.Remove(toRmv);
                updateFile();
                lsbPlayers.Items.Remove(lsbPlayers.SelectedItem);
            }

            lsbPlayers.ClearSelected();
            btnRemove.Visible = false;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            pnlPlayers.Visible = true;
            if (lsbPlayers.SelectedItems.Count == 2)
            {
                string[] player1 = lsbPlayers.SelectedItems[0].ToString().Split(' ');
                string[] player2 = lsbPlayers.SelectedItems[1].ToString().Split(' ');

                Player white = new Player(player1[0], int.Parse(player1[1]), int.Parse(player1[2]), int.Parse(player1[3]));
                Player black = new Player(player2[0], int.Parse(player2[1]), int.Parse(player2[2]), int.Parse(player2[3]));
                int pw = _players.FindIndex(x => x == white);
                int pb = _players.FindIndex(x => x == black);

                // Random to make it so it's random who starts
                Random rand = new Random();
                int randInt = rand.Next(0, 2);
                if (randInt > 0) 
                    _chess.newGame(_players[pw], _players[pb]);
                else
                    _chess.newGame(_players[pb], _players[pw]);
            }
            else
                MessageBox.Show("Please choose 2 players (CTRL + CLICK TO CHOOSE 2)", "Instructions");

        }

        private void StripMenuNewGame_Click(object sender, EventArgs e)
        {
            btnNewGame_Click(sender, e);
        }

        private void StripMenuItemSpecialGame_Click(object sender, EventArgs e)
        {
            pnlPlayers.Visible = true;
            if (lsbPlayers.SelectedItems.Count == 2)
            {
                string[] player1 = lsbPlayers.SelectedItems[0].ToString().Split(' ');
                string[] player2 = lsbPlayers.SelectedItems[1].ToString().Split(' ');

                Player white = new Player(player1[0], int.Parse(player1[1]), int.Parse(player1[2]), int.Parse(player1[3]));
                Player black = new Player(player2[0], int.Parse(player2[1]), int.Parse(player2[2]), int.Parse(player2[3]));
                int pw = _players.FindIndex(x => x == white);
                int pb = _players.FindIndex(x => x == black);

                // Random to make it so it's random who starts
                Random rand = new Random();
                int randInt = rand.Next(0, 2);
                if (randInt > 0)
                    _chess.newGame(_players[pw], _players[pb], Chess.CAPYBARA_PRINCE);
                else
                    _chess.newGame(_players[pb], _players[pw]);
            }
            else
                MessageBox.Show("Please choose 2 players (CTRL + CLICK TO CHOOSE 2)", "Instructions");
        }
    }
}
