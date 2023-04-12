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
        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Bishop Movement

            if (board[sourceY, sourceX].Me is Bishop)
            {
                if (Math.Abs(targetX - sourceX) == Math.Abs(targetY - sourceY))
                {
                    if (!isObstructed(board, sourceX, sourceY, targetX, targetY))
                    {
                        if (!(board[targetY, targetX].Me is Piece) || board[targetY, targetX].Me.Color != turn)
                        {
                            return true;
                        }
                    }
                }
            }
            // Bishop movement - END
            // ----------------------------
            return false;
        }
    }
}
