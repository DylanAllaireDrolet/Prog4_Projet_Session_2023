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

        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Queen Movement
            if (board[sourceY, sourceX].Me is Queen)
            {
                if (sourceX == targetX || sourceY == targetY || Math.Abs(targetX - sourceX) == Math.Abs(targetY - sourceY))
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
            // Queen movement - END
            // ---------------------------
            return false;
        }
    }
}
