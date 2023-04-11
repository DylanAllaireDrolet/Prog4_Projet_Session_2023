using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{

    /// <summary>
    /// Game Class
    /// </summary>
    public class Game
    {
        // Members
        private Chess _chess; // Chess controller
        private Board _board; // Game board
        private Player _pw; // White Player
        private Player _pb; // Black Player
        private FormGame _myForm; // Game Form
        private Thread _thread; // Thread of game
        private int _turn; // Current turn

        // Properties
        /// <summary>
        /// Board property
        /// </summary>
        public Board Board
        {
            get { return _board; }
        }

        /// <summary>
        /// White player property
        /// </summary>
        public Player WhitePlayer
        {
            get { return _pw; }
        }

        /// <summary>
        /// Black player property
        /// </summary>
        public Player BlackPlayer
        {
            get { return _pb; }
        }

        /// <summary>
        /// Current form property
        /// </summary>
        public FormGame MyForm
        {
            get { return _myForm; }
        }

        /// <summary>
        /// Current turn property
        /// </summary>
        public int Turn
        {
            get { return _turn; }
        }

        // Consctructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="chess"></param>
        public Game(Chess chess)
        {
            _chess = chess;
            _pw = new Player();
            _pb = new Player();
            _board = new Board();
            _turn = Chess.WHITE;
            _myForm = new FormGame(this);
            _thread = new Thread(() =>
            {
                Application.Run(_myForm);

            });
            _thread.Start();
        }

        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="white">white player</param>
        /// <param name="black">black player</param>
        /// <param name="chess">chess controller</param>
        public Game(Player white, Player black, Chess chess)
        {
            _chess = chess;
            _pw = white;
            _pb = black;
            _board = new Board();
            _turn = Chess.WHITE;
            _myForm = new FormGame(this);
            _thread = new Thread(() =>
            {
                Application.Run(_myForm);
            });
            _thread.Start();
            _chess = chess;
        }

        // Methods
        /// <summary>
        /// Ends the game
        /// </summary>
        /// <param name="winner">Winner of game</param>
        /// <param name="loser">Loser of game</param>
        /// <param name="draw">If this is true the game is a draw</param>
        public void GameEnd(Player winner, Player loser, bool draw = false)
        {
            List<Player> list = new List<Player>();
            if (File.Exists("./players.txt"))
            {
                StreamReader sr = new StreamReader("./players.txt");
                string line = "";
                string[] player;

                while ((line = sr.ReadLine()) != null)
                {
                    player = line.Split(' ');
                    list.Add(new Player(player[0], int.Parse(player[1]), int.Parse(player[2]), int.Parse(player[3])));
                }
                sr.Close();
            }
            else
            {
                File.Create("./players.txt");
            }

            if (!draw)
            {
                MessageBox.Show(winner.Name + " won!", "Winner, winner, chicken dinner!");


                int index = list.FindIndex(x => x == winner);
                list[index].Wins++;
                index = list.FindIndex(x => x == loser);
                list[index].GamesLost++;
            }
            else
            {
                int index = list.FindIndex(x => x == winner);
                list[index].GameDraw++;
                index = list.FindIndex(x => x == loser);
                list[index].GameDraw++;
            }
            StreamWriter sw = new StreamWriter("./players.txt");
            foreach (Player p in list)
            {
                sw.WriteLine(p.ToString());
            }
            sw.Close();

            _myForm.End();
        }

        /// <summary>
        /// Play a turn
        /// </summary>
        /// <param name="sourceX">Source square on X</param>
        /// <param name="sourceY">Source square on Y</param>
        /// <param name="targetX">Target square on X</param>
        /// <param name="targetY">Target square on Y</param>
        /// <returns>If the turn was valid</returns>
        public bool Play(int sourceX, int sourceY, int targetX, int targetY)
        {
            for (int i = 0; i < Board.SIZE; i++)
                for (int j = 0; j < Board.SIZE; j++)
                {
                    if (_board[i, j].Me is EnPassant && _board[i, j].Me.Color == _turn)
                        _board[i, j].Me = null;
                }

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
                    if (isCheckMated())
                    {
                        Player winner = _turn == Chess.WHITE ? _pb : _pw;
                        Player loser = _turn == Chess.WHITE ? _pw : _pb;
                        GameEnd(winner, loser);
                    }
                    else
                    {
                        MessageBox.Show("You are in check! Please make another move", "Error", MessageBoxButtons.OK);
                        _board = remember;
                        return false;
                    }
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

        /// <summary>
        /// Check if the play is legal
        /// </summary>
        /// <param name="sourceX">Source Square on X</param>
        /// <param name="sourceY">Source Square on Y</param>
        /// <param name="targetX">Target Square on X</param>
        /// <param name="targetY">Target Square on Y</param>
        /// <param name="checking">If this is true we are not modifying the board for real</param>
        /// <returns>True if the move is legal, false if it isn't legal</returns>
        private bool isLegalMove (int sourceX, int sourceY, int targetX, int targetY, bool checking = false)
        {
            if (checking)
                _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
            // Castling
            if (_board[sourceY, sourceX].Me is King && _board[sourceY, sourceX].Me.Color == _turn && _board[targetY, targetX].Me is Rook && sourceY == targetY)
            {
                // Check if the king and rook have not moved
                if (!((King)_board[sourceY, sourceX].Me).Moved && !((Rook)_board[targetY, targetX].Me).Moved)
                {
                    int direction = targetX - sourceX > 0 ? 1 : -1;
                    int rookX = direction > 0 ? 7 : 0;
                    int newKingX = sourceX + (direction * 2);

                    // Make's sure there's no pieces between
                    for (int x = sourceX + direction; x != rookX; x += direction)
                    {
                        if (_board[sourceY, x].Me != null)
                            return false;
                    }

                    // Making sure king is not checked
                    if (isChecked())
                        return false;

                    // Perform the castling
                    ((King)_board[sourceY, sourceX].Me).Moved = true;
                    ((Rook)_board[targetY, targetX].Me).Moved = true;

                    _board[sourceY, newKingX].Me = _board[sourceY, sourceX].Me;
                    _board[sourceY, sourceX].Me = null;
                    _board[sourceY, newKingX - direction].Me = _board[sourceY, rookX].Me;
                    _board[sourceY, rookX].Me = null;

                    if (checking)
                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                    return true;
                }
            }

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
                                if (_board[targetY, targetX].Me is EnPassant)
                                {
                                    int direction = _board[targetY, targetX].Me.Color == Chess.WHITE ? 1 : -1;
                                    _board[targetY + direction, targetX].Me = null;
                                }

                                // Promotion
                                if (targetY == 0 || targetY == 7)
                                {
                                    FormPromotion frm = new FormPromotion();
                                    if(frm.ShowDialog() == DialogResult.OK)
                                    {
                                        Piece promotedPiece = frm.SelectedPiece;
                                        promotedPiece.Color = _board[sourceY, sourceX].Me.Color;
                                        _board[sourceY, sourceX].Me = promotedPiece;
                                    }
                                    if (checking)
                                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                    return true;

                                }

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
                                    int direction = _turn == Chess.WHITE ? 1 : -1;
                                    _board[sourceY + direction, sourceX].Me = new EnPassant(_turn);
                                    return true;
                                }
                            }
                            else if (Math.Abs(sourceY - targetY) == 1)
                            {
                                if (!(_board[targetY, targetX].Me is Piece))
                                {
                                    if (targetY == 0 || targetY == 7)
                                    {
                                        FormPromotion frm = new FormPromotion();
                                        if (frm.ShowDialog() == DialogResult.OK)
                                        {
                                            Piece promotedPiece = frm.SelectedPiece;
                                            promotedPiece.Color = _board[sourceY, sourceX].Me.Color;
                                            _board[sourceY, sourceX].Me = promotedPiece;
                                        }
                                        if (checking)
                                            _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                                        return true;
                                    }
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
        /// <summary>
        /// Check if the path is obstructed
        /// </summary>
        /// <param name="sourceX">Source square on X</param>
        /// <param name="sourceY">Source square on Y</param>
        /// <param name="targetX">Target square on X</param>
        /// <param name="targetY">Target square on Y</param>
        /// <returns>True if the path is obstructed, false if it isn't obstructed</returns>
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

        /// <summary>
        /// Check if the king is in check
        /// </summary>
        /// <returns>True if the king is check, false if it isn't in check</returns>
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

        /// <summary>
        /// Check if it's checkmate
        /// </summary>
        /// <returns> True if it's check mate and false if it isn't</returns>
        private bool isCheckMated()
        {
            for (int x = 0; x < Board.SIZE; x++)
                for (int y = 0; y < Board.SIZE; y++)
                    if (_board[y, x].Me is Piece && _board[y, x].Me.Color == _turn)
                        for (int x2 = 0; x2 < Board.SIZE; x2++)
                            for (int y2 = 0; y2 < Board.SIZE; y2++)
                                if (isLegalMove(x, y, x2, y2))
                                    return false;
            return true;
        }

    }
}
