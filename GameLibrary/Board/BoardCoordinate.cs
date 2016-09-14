namespace GameLibrary.Board
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using Styx.Diagnostics;

    /// <summary>Provides the base class for value types.</summary>
    /// <filterpriority>2</filterpriority>
    [DebuggerDisplay("X, Y = {X}, {Y}")]
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
            Argument.Validate(x >= 0, nameof(x));
            Argument.Validate(y >= 0, nameof(y));

            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets column or X postion
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets Row or Y postion
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Transposition index on matrix
        /// </summary>
        /// <param name="board"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static BoardCoordinate FromBoardIndex(GameBoard board, int index)
        {
            Argument.ThrowIfNull(board, nameof(board));
            Argument.Validate(index >= 0, nameof(index));

            if (!IsValidDimention(index , board.RowSize * board.ColumnSize)) {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var rows = index / board.ColumnSize;
            var columns = index % board.ColumnSize;

            return new BoardCoordinate(columns, rows);
        }

        /// <summary>
        /// Translate matrix Coordinate to array index position within matrix bounds
        /// </summary>
        /// <param name="rowSize">row size</param>
        /// <param name="colSize">column size</param>
        /// <returns>index value</returns>
        public int Position(int rowSize, int colSize)
        {
            Argument.Validate(colSize >= 0, nameof(colSize));
            Argument.Validate(rowSize >= 0, nameof(rowSize));

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
