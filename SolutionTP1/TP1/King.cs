using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class King : MovedPiece
    {
        // Members

        // Properties

        public override Bitmap IMG
        {
            get 
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("kingW.bmp") : new Bitmap("kingB.bmp");
                else
                    return null;
            }

        }

        // Constructors
        public King() : base(10)
        {
            
        }
        public King(Square square, int color) : base(square, color, 10)
        {

        }
    }
}
