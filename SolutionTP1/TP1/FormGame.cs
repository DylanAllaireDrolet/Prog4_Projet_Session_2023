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
    public partial class FormGame : Form
    {
        // Members
        private Game _game;
        private int SourceX, SourceY;

        public FormGame(Game game)
        {
            _game = game;
            this.SourceX = this.SourceY = -1;
            InitializeComponent();
        }

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
                    MessageBox.Show("Illegal move! Please try again!", "Error", MessageBoxButtons.OK);
                }
                pnlBoard.Refresh();
                this.SourceX = this.SourceY = -1; 
            }
        }
    }
}
