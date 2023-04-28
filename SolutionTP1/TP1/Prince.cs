using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Prince : Piece
    {
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Chess.WHITE ? new Bitmap("princeW.bmp") : new Bitmap("princeB.bmp");
                else
                    return null;
            }
        }

        public Prince() : base(3)
        {

        }

        /// <summary>
        /// Prince constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public Prince(Square square, int color) : base(square, color, 3)
        {

        }

        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Prince movement
            if (board[sourceY, sourceX].Me is Prince)
            {
                if((Math.Abs(targetX - sourceX) == 1 && Math.Abs(targetY - sourceY) == 2) ||
                    (Math.Abs(targetX - sourceX) == 2 && Math.Abs(targetY - sourceY) == 1))
                    return false;

                if (Math.Abs(sourceX - targetX) <= 2 && Math.Abs(sourceY - targetY) <= 2)
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
            // Prince movement - END
            // ------------------------------
            return false;
        }
    }
}
