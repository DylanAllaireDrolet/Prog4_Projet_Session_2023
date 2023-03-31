using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Bishop : Piece
    {
        // Members

        // Properties
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("bishopW.bmp") : new Bitmap("bishopB.bmp");
                else
                    return null;
            }
        }


        // Constructors
        public Bishop() : base(3)
        {

        }
        public Bishop(Square square, int color) : base(square, color, 3)
        {

        }
    }
}
