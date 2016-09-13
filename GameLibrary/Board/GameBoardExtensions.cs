namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helper extension methods for the GameBoard
    /// </summary>
    public static class GameBoardExtensions
    {
        /// <summary>
        /// As Cell enumerator
        /// </summary>
        /// <param name="board"><see cref="GameBoard"/></param>
        /// <returns><see cref="Cell"/></returns>
        public static IEnumerable<Cell> AsEnumerable(this GameBoard board)
        {
            return board;
        }

        /// <summary>
        /// Enumerate thru all empty cells
        /// </summary>
        /// <param name="cells"><see cref="Cell"/></param>
        /// <returns>All Empty Cells</returns>
        public static IEnumerable<Cell> Empty(this IEnumerable<Cell> cells)
        {
            return cells.Where(w => w.IsEmpty);
        }

        /// <summary>
        /// Enumerate thru all none empty cells
        /// </summary>
        /// <param name="cells"><see cref="Cell"/></param>
        /// <returns>All none empty cells</returns>
        public static IEnumerable<Cell> ExceptEmpty(this IEnumerable<Cell> cells)
        {
            return cells.Where(w => !w.IsEmpty);
        }
    }
}
