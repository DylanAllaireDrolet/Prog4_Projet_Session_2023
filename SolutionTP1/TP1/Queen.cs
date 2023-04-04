using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Queen class, child of Piece
    /// </summary>
    public class Queen : Piece
    {
        // Properties
        /// <summary>
        /// Queen Image
        /// </summary>
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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Queen() : base(9)
        {

        }

        /// <summary>
        /// Queen constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public Queen(Square square, int color) : base(square, color, 9)
        {

        }
    }
}
