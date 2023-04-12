using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Piece Class
    /// </summary>
    public abstract class Piece
    {
        // Members
        private Square _mySquare; // My current square
        private int _color; // 2 is black and 1 is white
        private int _value; // Value of the pieces

        // Properties
        /// <summary>
        /// Piece Image
        /// </summary>
        public virtual Bitmap IMG
        {
            get
            {
                    return null;
            }
        }

        /// <summary>
        /// Piece square
        /// </summary>
        public Square MySquare
        {
            get { return _mySquare; }
            set { _mySquare = value; }
        }

        /// <summary>
        /// Picec Color
        /// </summary>
        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Piece()
        {
            _mySquare = null;
            _color = 1;
            _value = 0;
        }

        /// <summary>
        /// Constructor with value
        /// </summary>
        /// <param name="value">Value of piece</param>
        public Piece (int value)
        {
            _value = value;
            _mySquare = null;
            _color = 1;
        }

        /// <summary>
        /// Constructor of piece
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        /// <param name="value">Value of piece</param>
        public Piece (Square square, int color, int value)
        {
            _mySquare = square;
            _color = color;
            _value = value;
        }

        // Help ressources : Stack overflow and github for obstructions
        /// <summary>
        /// Check if the path is obstructed
        /// </summary>
        /// <param name="sourceX">Source square on X</param>
        /// <param name="sourceY">Source square on Y</param>
        /// <param name="targetX">Target square on X</param>
        /// <param name="targetY">Target square on Y</param>
        /// <returns>True if the path is obstructed, false if it isn't obstructed</returns>
        public static bool isObstructed(Board board, int sourceX, int sourceY, int targetX, int targetY)
        {
            int dirX = (targetX - sourceX) / Math.Max(Math.Abs(targetX - sourceX), 1);
            int dirY = (targetY - sourceY) / Math.Max(Math.Abs(targetY - sourceY), 1);
            int x = sourceX + dirX;
            int y = sourceY + dirY;

            while (x != targetX || y != targetY)
            {
                if (board[y, x].Me is Piece)
                {
                    return true;
                }

                x += dirX;
                y += dirY;
            }

            return false;
        }

        public abstract bool isLegalMove(Board board, int sourceX, int sourceY, int targetX, int targetY, int turn);

    }
}
