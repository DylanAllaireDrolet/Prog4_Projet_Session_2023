using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Square
    {
        // Members
        private int _color; // Color of square (1 is white, 2 is black)
        private Piece _me; // Piece on square

        // Properties
        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Piece Me
        {
            get { return _me; }
            set { _me = value; }
        }

        // Constructors
        public Square ()
        {
            _me = null;
            _color = 0;
        }
        public Square (Piece me , int color)
        {
            _me = me;
            _color = color;
        }
        public Square (int color, Piece me)
        {
            _color = color;
            _me = me;
        }
        public Square(int color)
        {
            _me = null;
            _color = color;
        }

        public Square(Piece me)
        {
            _me = me;
            _color = 0;
        } 
    }
}
