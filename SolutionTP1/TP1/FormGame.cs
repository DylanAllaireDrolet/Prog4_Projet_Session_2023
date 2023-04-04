using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    /// <summary>
    /// FormGame Class
    /// </summary>
    public partial class FormGame : Form
    {
        // Members
        private Game _game; // Curent game
        private int SourceX, SourceY; // Source of click

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">Current game</param>
        public FormGame(Game game)
        {
            _game = game;
            this.SourceX = this.SourceY = -1;
            InitializeComponent();
            lbl_pb.Text = _game.BlackPlayer.Name;
            lbl_pw.Text = _game.WhitePlayer.Name;
            WhiteTurn();
        }

        /// <summary>
        /// Paints the board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = pnlBoard.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Chocolate);

            myGraph.DrawRectangle(new Pen(Color.Chocolate), 0, 0, 240, 240);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (_game.Board[i, j].Color == Board.BLACK)
                        myGraph.FillRectangle(myBrush, j * 30, i * 30, 30, 30);

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (_game.Board[i, j].Me is Piece)
                    {
                        Bitmap img = _game.Board[i, j].Me.IMG;
                        if (img != null)
                        {
                            img.MakeTransparent(img.GetPixel(1, 1));
                            myGraph.DrawImage(img, j * 30, i * 30);
                        }
                    }
                }
        }

        /// <summary>
        /// Ends the game
        /// </summary>
        public void End()
        {
            Close();
        }

        /// <summary>
        /// Changes turn to White in the view
        /// </summary>
        public void WhiteTurn()
        {
            lbl_pb.ForeColor = Color.Red;
            lbl_pw.ForeColor = Color.Green;

            btnResign_pw.Enabled = true;
            btnNull_pw.Enabled = true;

            btnNull_pb.Enabled = false;
            btnResign_pb.Enabled = false;
        }

        /// <summary>
        /// Changes turn to Black in the view
        /// </summary>
        public void BlackTurn()
        {
            lbl_pb.ForeColor = Color.Green;
            lbl_pw.ForeColor = Color.Red;

            btnResign_pw.Enabled = false;
            btnNull_pw.Enabled = false;

            btnNull_pb.Enabled = true;
            btnResign_pb.Enabled = true;
        }

        /// <summary>
        /// White player ask's a draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNull_pw_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Black player ask's for draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNull_pb_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(_game.WhitePlayer.Name + " do you accept the draw ?", "Draw ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _game.GameEnd(_game.BlackPlayer, _game.WhitePlayer, true);
            }
        }
        
        /// <summary>
        /// White player resign's
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResign_pw_Click(object sender, EventArgs e)
        {
            _game.GameEnd(_game.BlackPlayer, _game.WhitePlayer);
        }

        /// <summary>
        /// Black Player ask's for draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResign_pb_Click(object sender, EventArgs e)
        {
            _game.GameEnd(_game.WhitePlayer, _game.BlackPlayer);
        }

        /// <summary>
        /// Click on board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlBoard_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics myGraph = pnlBoard.CreateGraphics();
            // Same square / Cancel movement
            if ((this.SourceX == e.X / 30) && (this.SourceY == e.Y / 30))
            {
                myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), this.SourceX * 30, this.SourceY * 30, 30, 30);
                this.SourceX = this.SourceY = -1;
            }
            // If there's no start square
            else if ((this.SourceX == -1) && (this.SourceY == -1))
            {
                this.SourceX = e.X / 30;
                this.SourceY = e.Y / 30;
                myGraph.DrawRectangle(new Pen(Color.DarkGreen, 2), this.SourceX * 30, this.SourceY * 30, 30, 30);
            }
            // If it's the destination
            else
            {
                myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), this.SourceX * 30, this.SourceY * 30, 30, 30);
                if (!_game.Play(SourceX, SourceY, e.X / 30, e.Y / 30))
                {

                }
                pnlBoard.Refresh();
                this.SourceX = this.SourceY = -1;
                if (_game.Turn == Chess.WHITE)
                    WhiteTurn();
                else
                    BlackTurn();
            }
        }
    }
}
