using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public static class GameBoardExtensions
    {
        public static IEnumerable<Cell> AsEnumerable(this GameBoard board)
        {
            return board._cells;
        }
        public static IEnumerable<Cell> AllEmpty(this IEnumerable<Cell> cells)
        {
            return cells.Where(w => w.IsEmpty);
        }
    }
}
