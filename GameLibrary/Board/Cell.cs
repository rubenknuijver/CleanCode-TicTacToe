using GameLibrary.Gamer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public class Cell
    {
        public int Score { get; }

        public Player Owner { get; set; } = null;

        public bool IsEmpty
        {
            get { return Owner == null; }
        }

        public Cell(int score)
        {
            Score = score;
        }

        public static Cell Create(int score)
        {
            return new Cell(score);
        }
    }
}
