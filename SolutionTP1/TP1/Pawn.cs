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
        // Constructors
        public Pawn() : base(1)
        {

        }
        public Pawn(Square square, int color) : base(square, color, 1)
        {

        }
    }
}
