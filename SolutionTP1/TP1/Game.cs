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
        public Game(Player white, Player black, Chess chess, int gameMode = 0)
        {
            _chess = chess;
            _pw = white;
            _pb = black;
            _board = new Board(gameMode);
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
           // _chess.Menu.initFile();
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
            if (_board[sourceY, sourceX].Me is Piece && _board[sourceY, sourceX].Me.Color == _turn)
            {
                for (int i = 0; i < Board.SIZE; i++)
                    for (int j = 0; j < Board.SIZE; j++)
                    {
                        if (_board[i, j].Me is EnPassant && _board[i, j].Me.Color == _turn)
                            _board[i, j].Me = null;
                    }

                if (_board[sourceY, sourceX].Me.isLegalMove(_board, sourceX, sourceY, targetX, targetY, _turn))
                {
                    Board remember = new Board();
                    for (int i = 0; i < Board.SIZE; i++)
                        for (int j = 0; j < Board.SIZE; j++)
                        {
                            remember[i, j].Me = _board[i, j].Me;
                        }

                    _board[targetY, targetX].Me = _board[sourceY, sourceX].Me;
                    _board[sourceY, sourceX].Me = null;
                    if (isChecked(_board))
                    {
                        if (isCheckMated())
                        {
                            Player winner = _turn == Chess.WHITE ? _pb : _pw;
                            Player loser = _turn == Chess.WHITE ? _pw : _pb;
                            GameEnd(winner, loser);
                        }
                        else
                        {
                            MessageBox.Show("You are in check! Please make another move", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _board = remember;
                            return false;
                        }
                    }
                    else
                    {
                        if (_board[targetY, targetX].Me is MovedPiece)
                            ((MovedPiece)_board[targetY, targetX].Me).Moved = true;
                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                        return true;
                    }
                }

                // Castling
                else if (_board[sourceY, sourceX].Me is King && _board[sourceY, sourceX].Me.Color == _turn && _board[targetY, targetX].Me is Rook && sourceY == targetY)
                {
                    if ( ((King)_board[sourceY, sourceX].Me).Castling(_board, sourceX, sourceY, targetX, targetY, _turn))
                    {
                        int direction = targetX - sourceX > 0 ? 1 : -1;
                        int rookX = direction > 0 ? 7 : 0;
                        int newKingX = sourceX + (direction * 2);

                        // Perform the castling
                        ((King)_board[sourceY, sourceX].Me).Moved = true;
                        ((Rook)_board[targetY, targetX].Me).Moved = true;

                        _board[sourceY, newKingX].Me = _board[sourceY, sourceX].Me;
                        _board[sourceY, sourceX].Me = null;
                        _board[sourceY, newKingX - direction].Me = _board[sourceY, rookX].Me;
                        _board[sourceY, rookX].Me = null;
                        _turn = _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE;
                        return true;
                    }
                }

                else
                {
                    MessageBox.Show("Illegal move! Please make another move!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Please choose your pieces!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }        

        /// <summary>
        /// Check if the king is in check
        /// </summary>
        /// <returns>True if the king is check, false if it isn't in check</returns>
        private bool isChecked(Board board)
        {
            int kingX = 0, KingY = 0;

            for (int x = 0;  x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    if (board[y, x].Me is King && board[y, x].Me.Color == _turn)
                    {
                        kingX = x; 
                        KingY = y;
                    }
                }
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    if (board[y, x].Me is Piece && board[y, x].Me.Color != _turn)
                        if (board[y, x].Me.isLegalMove(board, x, y, kingX, KingY, _turn == Chess.WHITE ? Chess.BLACK : Chess.WHITE))
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
                                if (_board[y, x].Me.isLegalMove(_board, x, y, x2, y2, _turn))
                                    if(!isChecked(makeFakeMove(x, y, x2 ,y2)))
                                        return false;
            return true;
        }

        private Board makeFakeMove(int x, int y, int tx, int ty)
        {
            Board board = new Board();
            for (int i = 0; i < Board.SIZE; i++)
                for (int j = 0; j < Board.SIZE; j++)
                {
                    board[i, j].Me = _board[i, j].Me;
                }
            board[ty, tx].Me = board[y, x].Me;
            board[y, x].Me = null;
            return board;
        }

    }
}