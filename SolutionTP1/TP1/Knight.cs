using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Knight class, child of Piece
    /// </summary>
    public class Knight : Piece
    {
        /// <summary>
        /// Knight Image
        /// </summary>
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("knightW.bmp") : new Bitmap("knightB.bmp");
                else
                    return null;
            }
        }

        // Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Knight() : base(3)
        {

        }

        /// <summary>
        /// Knight constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public Knight(Square square, int color) : base(square, color, 3)
        {

        }

        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Knight movement

            if (board[sourceY, sourceX].Me is Knight)
            {
                if ((Math.Abs(targetX - sourceX) == 1 && Math.Abs(targetY - sourceY) == 2) ||
                    (Math.Abs(targetX - sourceX) == 2 && Math.Abs(targetY - sourceY) == 1))
                {
                    if (!(board[targetY, targetX].Me is Piece) || board[targetY, targetX].Me.Color != turn)
                    {
                        return true;
                    }
                }
            }
            // Knight movement - END
            // ------------------------------
            return false;
        }
    }
}
