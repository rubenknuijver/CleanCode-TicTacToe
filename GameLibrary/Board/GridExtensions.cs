using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public static class GridExtensions
    {
        public static IEnumerable<Cell> AsEnumerable(this Grid grid)
        {
            return grid._cells;
        }
        public static IEnumerable<Cell> AllEmpty(this IEnumerable<Cell> cells)
        {
            return cells.Where(w => w.IsEmpty);
        }
    }
}
