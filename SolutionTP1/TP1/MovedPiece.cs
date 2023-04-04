using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// MovedPiece Class, child of Piece
    /// </summary>
    public class MovedPiece : Piece
    {
        // Members
        private bool _moved; // If piece has moved

        // Properties
        /// <summary>
        /// Moved boolean property
        /// </summary>
        public bool Moved
        {
            get { return _moved;  }
            set { _moved = value; }
        }
        // Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public MovedPiece () : base ()
        {
            _moved = false;
        }

        /// <summary>
        /// Constructor for Moved Piece
        /// </summary>
        /// <param name="value">Value of piece</param>
        public MovedPiece (int value) : base (value)
        {
            _moved = false;
        }
        /// <summary>
        /// Constructor for a moved piece
        /// </summary>
        /// <param name="square">Current square</param>
        /// <param name="color">Color of piece</param>
        /// <param name="value">Value of piece</param>
        public MovedPiece (Square square, int color, int value) : base (square, color, value)
        {
            _moved = false;
        }
    }
}
