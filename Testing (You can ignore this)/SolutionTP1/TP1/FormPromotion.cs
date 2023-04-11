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
    /// Class for FormPromotion
    /// </summary>
    public partial class FormPromotion : Form
    {
        private Piece _selected;
        // Properties
        /// <summary>
        /// Property for Selected piece
        /// </summary>
        public Piece SelectedPiece
        {
            get { return _selected; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormPromotion()
        {
            InitializeComponent();
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            _selected = new Queen();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            _selected = new Rook();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            _selected = new Bishop();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            _selected = new Knight();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
