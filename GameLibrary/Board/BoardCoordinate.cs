namespace GameLibrary.Board
{
    using System;
    using System.Linq;

    /// <summary>Provides the base class for value types.</summary>
    /// <filterpriority>2</filterpriority>
    public struct BoardCoordinate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardCoordinate"/> struct.
        /// Coordinate point on the GameBoard
        /// </summary>
        /// <param name="x">Column or X prostion</param>
        /// <param name="y">Row or Y postion</param>
        public BoardCoordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets column or X prostion
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets Row or Y postion
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Translate matrix Coordinate to array index position within matrix bounds
        /// </summary>
        /// <param name="rowSize">row size</param>
        /// <param name="colSize">column size</param>
        /// <returns>index value</returns>
        public int Position(int rowSize, int colSize)
        {
            int x = this.X % colSize;
            int y = this.Y % rowSize;
            return (y * colSize) + x;
        }

        /// <summary>
        /// Determains if the coordiante is on the <see cref="GameBoard"/>
        /// </summary>
        /// <param name="board"><see cref="GameBoard"/></param>
        /// <returns>true it is on the <see cref="GameBoard"/></returns>
        public bool IsOnGameBoard(GameBoard board) => IsValidDimention(this.X, board.ColumnSize) && IsValidDimention(this.Y, board.RowSize);

        private static bool IsValidDimention(int pos, int dimention) => pos >= 0 && pos < dimention;
    }
}
