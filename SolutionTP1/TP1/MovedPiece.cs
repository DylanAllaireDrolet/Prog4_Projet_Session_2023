using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class MovedPiece : Piece
    {
        // Members
        private bool _moved;
        // Properties
        public bool Moved
        {
            get { return _moved;  }
            set { _moved = value; }
        }
        // Constructors
        public MovedPiece () : base ()
        {
            _moved = false;
        }
        public MovedPiece (int value) : base (value)
        {
            _moved = false;
        }
        public MovedPiece (Square square, int color, int value) : base (square, color, value)
        {
            _moved = false;
        }
    }
}
