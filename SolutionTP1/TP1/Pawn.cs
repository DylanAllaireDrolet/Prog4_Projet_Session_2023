using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Pawn Class, child of moved piece
    /// </summary>
    public class Pawn : MovedPiece
    {
        // Properties
        /// <summary>
        /// Pawn Image
        /// </summary>
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
        /// <summary>
        /// Default property
        /// </summary>
        public Pawn() : base(1)
        {
        }
        /// <summary>
        /// Pawn Constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public Pawn(Square square, int color) : base(square, color, 1)
        {

        }
    }
}
