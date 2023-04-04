using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    /// <summary>
    /// King class, child of MovedPiece
    /// </summary>
    public class King : MovedPiece
    {
        /// <summary>
        /// King Image
        /// </summary>
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

        /// <summary>
        /// Default constructor
        /// </summary>
        public King() : base(10)
        {
            
        }

        /// <summary>
        /// King constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public King(Square square, int color) : base(square, color, 10)
        {

        }
    }
}
