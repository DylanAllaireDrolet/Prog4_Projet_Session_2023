using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Piece
    {
        // Members
        private Square _mySquare; // My current square
        private int _color; // 2 is black and 1 is white
        private int _value; // Value of the pieces

        // Properties
        public virtual Bitmap IMG
        {
            get
            {
                    return null;
            }
        }
        public Square MySquare
        {
            get { return _mySquare; }
            set { _mySquare = value; }
        }
        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Constructors
        public Piece()
        {
            _mySquare = null;
            _color = 1;
            _value = 0;
        }
        public Piece (int value)
        {
            _value = value;
            _mySquare = null;
            _color = 1;
        }
        public Piece (Square square, int color, int value)
        {
            _mySquare = square;
            _color = color;
            _value = value;
        }
    }
}
