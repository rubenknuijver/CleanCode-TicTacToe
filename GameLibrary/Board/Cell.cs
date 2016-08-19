using GameLibrary.Gamer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public class Cell
    {
        public int Index { get; }

        public Player Taken { get; set; } = null;

        public bool IsEmpty
        {
            get { return Taken == null; }
        }

        public Cell(int index)
        {
            Index = index;
        }

        public static Cell Create(int index)
        {
            return new Cell(index);
        }
    }
}
