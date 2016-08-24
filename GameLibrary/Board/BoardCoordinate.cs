using System;
using System.Linq;

namespace GameLibrary.Board
{
    public struct BoardCoordinate
    {
        public int X { get; }
        public int Y { get; }

        public BoardCoordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int ToIndex(int rowSize, int colSize)
        {
            int x = this.X % colSize;
            int y = this.Y % rowSize;
            return (y * colSize) + x;
        }

        public bool IsOnGameBoard(GameBoard board)
        {
            return IsValidDimention(X, board._columnSize) && IsValidDimention(Y, board._rowSize);
        }
        private static bool IsValidDimention(int pos, int dimention)
        {
            return pos >= 0 && pos < dimention;
        }
    }
}
