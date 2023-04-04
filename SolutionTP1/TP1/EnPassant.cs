using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{

    /// <summary>
    /// EnPassant class, child of Piece
    /// </summary>
    public class EnPassant : Piece
    {
        // Constructors

        /// <summary>
        /// Invisible piece for the En Passant (Child of piece)
        /// </summary>
        /// <param name="color">Color of the En Passant</param>
        public EnPassant(int color)
        {
            this.Color = color;
        }
    }
}
