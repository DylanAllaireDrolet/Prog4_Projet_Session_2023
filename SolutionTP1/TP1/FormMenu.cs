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

        // Properties
        public Player this[int i]
        {
            get { return _players[i]; }
        }

        // Constructor
        public FormMenu()
        {
            _players= new List<Player>();
            InitializeComponent();
            initFile();
        }

        // Functions
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
                    _players.Add(new Player(player[0]));
                }
                sr.Close();
            }
            else
            {
                File.Create("./players.txt");
            }
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
    }
}
