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
    public class Piece
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
    }
}
