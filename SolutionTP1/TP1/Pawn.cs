using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Pawn movement
            if (board[sourceY, sourceX].Me is Pawn)
            {
                // Eating a piece
                if (sourceX != targetX)
                {
                    if (Math.Abs(sourceY - targetY) == 1 && Math.Abs(sourceX - targetX) == 1)
                    {
                        if (board[targetY, targetX].Me is Piece && board[targetY, targetX].Me.Color != turn)
                        {
                            if (board[targetY, targetX].Me is EnPassant)
                            {
                                int direction = board[targetY, targetX].Me.Color == Chess.WHITE ? 1 : -1;
                                board[targetY + direction, targetX].Me = null;
                            }

                            // Promotion
                            if (targetY == 0 || targetY == 7)
                            {
                                FormPromotion frm = new FormPromotion();
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    Piece promotedPiece = frm.SelectedPiece;
                                    promotedPiece.Color = board[sourceY, sourceX].Me.Color;
                                    board[sourceY, sourceX].Me = promotedPiece;
                                }
                                return true;
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    if ((sourceY < targetY && turn == Chess.WHITE) || (sourceY > targetY && turn == Chess.BLACK))
                    {
                        if (Math.Abs(sourceY - targetY) == 2)
                        {
                            if (((Pawn)board[sourceY, sourceX].Me).Moved)
                            {
                                return false;
                            }
                            else
                            {
                                for (int i = 1; i < 3; i++)
                                {
                                    if (turn == Chess.WHITE && board[sourceY + i, sourceX].Me is Piece)
                                    {
                                        return false;
                                    }
                                    if (turn == Chess.BLACK && board[sourceY - i, sourceX].Me is Piece)
                                    {
                                        return false;
                                    }
                                }
                                int direction = turn == Chess.WHITE ? 1 : -1;
                                board[sourceY + direction, sourceX].Me = new EnPassant(turn);
                                return true;
                            }
                        }
                        else if (Math.Abs(sourceY - targetY) == 1)
                        {
                            if (!(board[targetY, targetX].Me is Piece))
                            {
                                // Promotion
                                if (targetY == 0 || targetY == 7)
                                {
                                    FormPromotion frm = new FormPromotion();
                                    if (frm.ShowDialog() == DialogResult.OK)
                                    {
                                        Piece promotedPiece = frm.SelectedPiece;
                                        promotedPiece.Color = board[sourceY, sourceX].Me.Color;
                                        board[sourceY, sourceX].Me = promotedPiece;
                                    }
                                    return true;
                                    // Promotion End
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            // Pawn movement - END
            // --------------------------------
            return false;
        }
    }
}
