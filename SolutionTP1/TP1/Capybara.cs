using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Capybara : Piece
    {
        public override Bitmap IMG
        {
            get
            {
                if (this.Color != 0)
                    return this.Color == Board.WHITE ? new Bitmap("capybaraW.bmp") : new Bitmap("capybaraB.bmp");
                else
                    return null;
            }
        }

        public Capybara() : base(3)
        {

        }

        /// <summary>
        /// Capybara constructor
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        public Capybara(Square square, int color) : base(square, color, 3)
        {

        }

        public override bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn)
        {
            // Capybara movement

            if (board[sourceY, sourceX].Me is Capybara)
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

            if (board[sourceY, sourceX].Me is Capybara)
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
            // Capybara movement - END
            // ------------------------------
            return false;
        }
    }
}
