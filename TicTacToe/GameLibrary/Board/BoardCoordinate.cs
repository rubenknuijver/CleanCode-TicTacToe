namespace GameLibrary.Board
{
    using System;
    using System.Diagnostics;
    using System.Linq;
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
        /// <param name="x">Column or X position</param>
        /// <param name="y">Row or Y position</param>
        public BoardCoordinate(int x, int y)
        {
            Argument.Validate(x >= 0, nameof(x));
            Argument.Validate(y >= 0, nameof(y));

            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets column or X position
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets Row or Y position
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

            if (!IsValidDimention(index , board.Size.Rows * board.Size.Columns)) {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var rows = index / board.Size.Columns;
            var columns = index % board.Size.Columns;

            return new BoardCoordinate(columns, rows);
        }

        /// <summary>
        /// Translate matrix Coordinate to array index position within matrix bounds
        /// </summary>
        /// <param name="boardSize">Dimension</param>
        /// <returns>index value</returns>
        public int Position(BoardSize boardSize)
        {
            Argument.ThrowIfNull(boardSize, nameof(boardSize));

            int x = this.X % boardSize.Columns;
            int y = this.Y % boardSize.Rows;
            return (y * boardSize.Columns) + x;
        }

        /// <summary>
        /// Determines if the coordinate is on the <see cref="GameBoard"/>
        /// </summary>
        /// <param name="boardSize"><see cref="BoardSize"/></param>
        /// <returns>true it is on the <see cref="BoardSize"/></returns>
        public bool IsOnGameBoard(BoardSize boardSize) => IsValidDimention(this.X, boardSize.Columns) && IsValidDimention(this.Y, boardSize.Rows);

        private static bool IsValidDimention(int pos, int dimention) => pos >= 0 && pos < dimention;
    }
}
