using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Queen : Piece
    {
        // Members
        
        // Properties
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("queenW.bmp") : new Bitmap("queenB.bmp");
                else
                    return null;
            }

        }

        // Constructors
        public Queen() : base(9)
        {

        }
        public Queen(Square square, int color) : base(square, color, 9)
        {

        }
    }
}
