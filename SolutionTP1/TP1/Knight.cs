using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Knight : Piece
    {
        // Members

        // Properties
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("knightW.bmp") : new Bitmap("knightB.bmp");
                else
                    return null;
            }
        }

        // Constructors
        public Knight() : base(3)
        {

        }
        public Knight(Square square, int color) : base(square, color, 3)
        {

        }
    }
}
