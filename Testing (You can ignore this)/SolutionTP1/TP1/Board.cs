using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// Board class
    /// </summary>
    public class Board
    {
        // Members
        private Square[,] _squares;
        /// <summary>
        /// Constant for White = 1
        /// </summary>
        public const int WHITE = 1; // White color
        /// <summary>
        /// Constant for Black = 2
        /// </summary>
        public const int BLACK = 2; // Black color
        /// <summary>
        /// Constant for board Size = 8
        /// </summary>
        public const int SIZE = 8; // Board size

        // Properties
        /// <summary>
        /// Indexer for board (2D array of Square)
        /// </summary>
        /// <param name="i">index at i</param>
        /// <param name="j">index at j</param>
        /// <returns>index at i & j = [i, j]</returns>
        public Square this[int i, int j]
        {
            get { return _squares[i, j]; }
            set { _squares[i, j] = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Board ()
        {
            _squares = new Square[8, 8];
            // Init square colors
            bool starter = true;
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (starter)
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            _squares[i, j] = new Square(WHITE);
                        }
                        else
                        {
                            _squares[i, j] = new Square(BLACK);
                        }
                    }
                    else
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            _squares[i, j] = new Square(BLACK);
                        }
                        else
                        {
                            _squares[i, j] = new Square(WHITE);
                        }
                    }
                }
                starter = !starter;
            }

            // Init pieces on squares
            _squares[0, 0].Me = new Rook(_squares[0, 0], WHITE);
            _squares[7, 0].Me = new Rook(_squares[7, 0], BLACK);

            _squares[0, 1].Me = new Knight(_squares[0, 1], WHITE);
            _squares[7, 1].Me = new Knight(_squares[7, 1], BLACK);


            _squares[0, 2].Me = new Bishop(_squares[0, 2], WHITE);
            _squares[7, 2].Me = new Bishop(_squares[7, 2], BLACK);


            _squares[0, 3].Me = new Queen(_squares[0, 3], WHITE);
            _squares[7, 3].Me = new Queen(_squares[7, 3], BLACK);


            _squares[0, 4].Me = new King(_squares[0, 4], WHITE);
            _squares[7, 4].Me = new King(_squares[7, 4], BLACK);


            _squares[0, 5].Me = new Bishop(_squares[0, 5], WHITE);
            _squares[7, 5].Me = new Bishop(_squares[7, 5], BLACK);


            _squares[0, 6].Me = new Knight(_squares[0, 6], WHITE);
            _squares[7, 6].Me = new Knight(_squares[7, 6], BLACK);


            _squares[0, 7].Me = new Rook(_squares[0, 7], WHITE);
            _squares[7, 7].Me = new Rook(_squares[7, 7], BLACK);


            for (int i = 0; i < 8; i++)
            {
                _squares[1, i].Me = new Pawn(_squares[1, i], WHITE);
                _squares[6, i].Me = new Pawn(_squares[6, i], BLACK);
            }
        }
    }
}
