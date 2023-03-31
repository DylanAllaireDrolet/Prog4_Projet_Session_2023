using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public class Game
    {
        // Members
        private Board _board;
        private Player _pw;
        private Player _pb;
        private FormGame _myForm;
        private Thread _thread;
        private int _turn = Chess.WHITE;

        // Properties
        public Board Board
        {
            get { return _board; }
        }
        public Player WhitePlayer
        {
            get { return _pw; }
        }
        public Player BlackPlayer
        {
            get { return _pb; }
        }
        public FormGame MyForm
        {
            get { return _myForm; }
        }

        // Consctructor
        public Game()
        {
            _pw = new Player();
            _pb = new Player();
            _board = new Board();
            _myForm = new FormGame(this);
            _thread = new Thread(() =>
            {
                Application.Run(_myForm);

            });
            _thread.Start();
        }
        public Game(Player white, Player black)
        {
            _pw = white;
            _pb = black;
            _board = new Board();
            _myForm = new FormGame(this);
            _thread = new Thread(() =>
            {
                Application.Run(_myForm);
            });
            _thread.Start();
        }

        // Methods
        public bool Play(int sourceX, int sourceY, int targetX, int targetY)
        {
            if (isLegalMove(sourceX, sourceY, targetX, targetY))
            {
                Board remember = new Board();
                for (int i = 0; i < Board.SIZE; i++)
                    for (int j = 0; j < Board.SIZE; j++)
                    {
                        remember[i, j].Me = _board[i, j].Me;
                    }

                _board[targetY, targetX].Me = _board[sourceY, sourceX].Me;
                _board[sourceY, sourceX].Me = null;
                if (isChecked())
                {
                    MessageBox.Show("You are in check! Please make another move", "Error", MessageBoxButtons.OK);
                    _board = remember;
                    return false;
                }
                else
                {
                    _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Illegal move! Please make another move!", "Error", MessageBoxButtons.OK);
            }
            
            return false;
        }

        private bool isLegalMove (int sourceX, int sourceY, int targetX, int targetY, bool checking = false)
        {
            if (checking)
                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
            if (_board[sourceY, sourceX].Me is Piece && _board[sourceY, sourceX].Me.Color == _turn)
            {
                // King movement
                if (_board[sourceY, sourceX].Me is King)
                {
                    if (Math.Abs(sourceX - targetX) <= 1 && Math.Abs(sourceY - targetY) <= 1)
                    {
                        if (!(_board[targetY, targetX].Me is Piece) || _board[targetY, targetX].Me.Color != _turn)
                        {
                            if (checking)
                                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                            return true;
                        }
                    }
                }
                // King movement - END
                // --------------------------------------

                // Queen Movement
                if (_board[sourceY, sourceX].Me is Queen)
                {
                    if (sourceX == targetX || sourceY == targetY || Math.Abs(targetX - sourceX) == Math.Abs(targetY - sourceY))
                    {
                        if (!isObstructed(sourceX, sourceY, targetX, targetY))
                        {
                            if (!(_board[targetY, targetX].Me is Piece) || _board[targetY, targetX].Me.Color != _turn)
                            {
                                if (checking)
                                    _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                return true;
                            }
                        }
                    }
                }
                // Queen movement - END
                // ---------------------------

                // Bishop Movement

                if (_board[sourceY, sourceX].Me is Bishop)
                {
                    if (Math.Abs(targetX - sourceX) == Math.Abs(targetY - sourceY))
                    {
                        if (!isObstructed(sourceX, sourceY, targetX, targetY))
                        {
                            if (!(_board[targetY, targetX].Me is Piece) || _board[targetY, targetX].Me.Color != _turn)
                            {
                                if (checking)
                                    _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                return true;
                            }
                        }
                    }
                }
                // Bishop movement - END
                // ----------------------------

                // Knight movement

                if (_board[sourceY, sourceX].Me is Knight)
                {
                    if ((Math.Abs(targetX - sourceX) == 1 && Math.Abs(targetY - sourceY) == 2) ||
                        (Math.Abs(targetX - sourceX) == 2 && Math.Abs(targetY - sourceY) == 1))
                    {
                        if (!(_board[targetY, targetX].Me is Piece) || _board[targetY, targetX].Me.Color != _turn)
                        {
                            if (checking)
                                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                            return true;
                        }
                    }
                }
                // Knight movement - END
                // ------------------------------

                // Rook movement

                if (_board[sourceY, sourceX].Me is Rook)
                {
                    if (sourceX == targetX || sourceY == targetY)
                    {
                        if (!isObstructed(sourceX, sourceY, targetX, targetY))
                        {
                            if (!(_board[targetY, targetX].Me is Piece) || _board[targetY, targetX].Me.Color != _turn)
                            {
                                if (checking)
                                    _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                return true;
                            }
                        }
                    }
                }
                // Rook movement - END

                // Pawn movement
                if (_board[sourceY, sourceX].Me is Pawn)
                {
                    // Eating a piece
                    if (sourceX != targetX)
                    {
                        if (Math.Abs(sourceY - targetY) == 1 && Math.Abs(sourceX - targetX) == 1)
                        {
                            if (_board[targetY, targetX].Me is Piece && _board[targetY, targetX].Me.Color != _turn)
                            {
                                if (checking)
                                    _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if ((sourceY < targetY && _turn == Chess.WHITE) || (sourceY > targetY && _turn == Chess.BLACK))
                        {
                            if (Math.Abs(sourceY - targetY) == 2)
                            {
                                if (((Pawn)_board[sourceY, sourceX].Me).Moved)
                                {
                                    if (checking)
                                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                    return false;
                                }
                                else
                                {
                                    for (int i = 1; i < 3; i++)
                                    {
                                        if (_turn == Chess.WHITE && _board[sourceY + i, sourceX].Me is Piece)
                                        {
                                            if (checking)
                                                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                            return false;
                                        }                                     
                                        if (_turn == Chess.BLACK && _board[sourceY - i, sourceX].Me is Piece)
                                        {
                                            if (checking)
                                                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                            return false;
                                        }
                                    }
                                    if (checking)
                                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                    return true;
                                }
                            }
                            else if (Math.Abs(sourceY - targetY) == 1)
                            {
                                if (!(_board[targetY, targetX].Me is Piece))
                                {
                                    if (checking)
                                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                    return true;
                                }
                            }
                        }
                    }
                }
                    // Pawn movement - END
                    // --------------------------------
            }
            if (checking)
                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
            return false;
        }

        // Help ressources : Stack overflow and github for obstructions
        private bool  isObstructed (int sourceX, int sourceY, int targetX, int targetY)
        {
            int dirX = (targetX - sourceX) / Math.Max(Math.Abs(targetX - sourceX), 1);
            int dirY = (targetY - sourceY) / Math.Max(Math.Abs(targetY - sourceY), 1);
            int x = sourceX + dirX;
            int y = sourceY + dirY;

            while (x != targetX || y != targetY)
            {
                if (_board[y, x].Me is Piece)
                {
                    return true;
                }

                x += dirX;
                y += dirY;
            }

            return false;
        }
        private bool isChecked()
        {
            int kingX = 0, KingY = 0;

            for (int x = 0;  x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    if (_board[y, x].Me is King && _board[y, x].Me.Color == _turn)
                    {
                        kingX = x; 
                        KingY = y;
                    }
                }
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    if (_board[y, x].Me is Piece && _board[y, x].Me.Color != _turn)
                        if (isLegalMove(x, y, kingX, KingY, true))
                            return true; 

            return false;
        }

    }
}
