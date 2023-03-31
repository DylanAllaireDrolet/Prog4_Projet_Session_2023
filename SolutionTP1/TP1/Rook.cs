using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Rook : MovedPiece
    {
        // Members

        // Properties
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("rookW.bmp") : new Bitmap("rookB.bmp");
                else
                    return null;
            }
        }

        // Constructors
        public Rook() : base (5)
        {

        }
        public Rook(Square square, int color) : base(square, color, 5)
        {

        }
    }
}
