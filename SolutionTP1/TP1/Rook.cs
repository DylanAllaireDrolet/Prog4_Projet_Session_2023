using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Rook class, child of MovedPiece
    /// </summary>
    public class Rook : MovedPiece
    {
        // Properties
        /// <summary>
        /// Rook Image
        /// </summary>
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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Rook() : base (5)
        {

        }
        /// <summary>
        /// Rook constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public Rook(Square square, int color) : base(square, color, 5)
        {

        }
    }
}
