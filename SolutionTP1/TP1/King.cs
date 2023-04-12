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

        public bool Castling(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Castling
            if (board[sourceY, sourceX].Me is King && board[sourceY, sourceX].Me.Color == turn && board[targetY, targetX].Me is Rook && sourceY == targetY)
            {
                // Check if the king and rook have not moved
                if (!((King)board[sourceY, sourceX].Me).Moved && !((Rook)board[targetY, targetX].Me).Moved)
                {
                    int direction = targetX - sourceX > 0 ? 1 : -1;
                    int rookX = direction > 0 ? 7 : 0;
                    int newKingX = sourceX + (direction * 2);

                    // Make's sure there's no pieces between
                    for (int x = sourceX + direction; x != rookX; x += direction)
                    {
                        if (board[sourceY, x].Me != null)
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // King movement
            if (board[sourceY, sourceX].Me is King)
            {
                if (Math.Abs(sourceX - targetX) <= 1 && Math.Abs(sourceY - targetY) <= 1)
                {
                    if (!(board[targetY, targetX].Me is Piece) || board[targetY, targetX].Me.Color != turn)
                    {
                        return true;
                    }
                }
            }
            // King movement - END
            // --------------------------------------

            return false;
        }
    }
}
