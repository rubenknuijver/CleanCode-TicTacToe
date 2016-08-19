using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public class Grid
    {
        public Cell[,] Cells { get; set; } = new Cell[3, 3];
    }
}
