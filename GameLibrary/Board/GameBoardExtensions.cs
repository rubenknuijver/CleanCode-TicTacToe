namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GameBoardExtensions
    {
        public static IEnumerable<Cell> AsEnumerable(this GameBoard board)
        {
            return board;
        }

        public static IEnumerable<Cell> Empty(this IEnumerable<Cell> cells)
        {
            return cells.Where(w => w.IsEmpty);
        }

        public static IEnumerable<Cell> ExceptEmpty(this IEnumerable<Cell> cells)
        {
            return cells.Where(w => !w.IsEmpty);
        }
    }
}
