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
    public partial class FormMenu : Form
    {
        // Members
        private List<Player> _players;
        private Chess _chess;

        // Properties
        public Player this[int i]
        {
            get { return _players[i]; }
        }
        public Chess chess
        {
            get { return _chess; }
            set { _chess = value; }
        }
        // Constructor
        public FormMenu(Chess chess)
        {
            _chess = chess;
            _players= new List<Player>();
            InitializeComponent();
            initFile();
        }

        // Methods
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

        private void updateFile()
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
            _chess.newGame();
        }
    }
}
