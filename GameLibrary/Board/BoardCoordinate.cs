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

        public int Position(int rowSize, int colSize)
        {
            int x = this.X % colSize;
            int y = this.Y % rowSize;
            return (y * colSize) + x;
        }

        public bool IsOnGameBoard(GameBoard board) => IsValidDimention(X, board.ColumnSize) && IsValidDimention(Y, board.RowSize);

        private static bool IsValidDimention(int pos, int dimention) => pos >= 0 && pos < dimention;
    }
}
