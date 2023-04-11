using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    /// <summary>
    /// Bishop class, child to Piece
    /// </summary>
    public class Bishop : Piece
    {
        // Members

        // Properties
        
        /// <summary>
        /// Bishop Image
        /// </summary>
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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Bishop() : base(3)
        {

        }
        /// <summary>
        /// Constructor for bishop
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Current color</param>
        public Bishop(Square square, int color) : base(square, color, 3)
        {

        }
    }
}
