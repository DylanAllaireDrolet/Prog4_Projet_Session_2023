using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Pawn : MovedPiece
    {
        // Members
        private bool enPassant;
        // Properties
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("pawnW.bmp") : new Bitmap("pawnB.bmp");
                else
                    return null;
            }
        }
        public bool EnPassant
        {
            get { return enPassant; }
            set { enPassant = value; }
        }
        // Constructors
        public Pawn() : base(1)
        {
            enPassant = false;
        }
        public Pawn(Square square, int color) : base(square, color, 1)
        {

        }
    }
}
