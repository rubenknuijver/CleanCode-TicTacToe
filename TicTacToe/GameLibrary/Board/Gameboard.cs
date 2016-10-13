namespace GameLibrary.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Styx.Diagnostics;

    /// <summary>
    /// 
    /// </summary>
    public class GameBoard : IEnumerable<Cell>
    {
        private Cell[] _cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class.
        /// </summary>
        /// <param name="size"></param>
        public GameBoard(BoardSize size)
        {
            Enforce.NotNull(size);

            this.Size = size;
            this._cells = new Cell[size];
        }

        /// <summary>
        /// Gets the GameBoard demential size in Rows and Columns
        /// </summary>
        public BoardSize Size { get; }

        /// <summary>
        /// Get or Set a cell using a BoardCoordinate
        /// </summary>
        /// <param name="coordinate"><see cref="BoardCoordinate"/></param>
        /// <returns><see cref="Cell"/></returns>
        public Cell this[BoardCoordinate coordinate]
        {
            get
            {
                if (!coordinate.IsOnGameBoard(this.Size)) {
                    throw ExceptionFactory.CoordinateOutOfBound(nameof(coordinate));
                }

                return this._cells[coordinate.Position(this.Size)];
            }

            set
            {
                if (!coordinate.IsOnGameBoard(this.Size)) {
                    throw ExceptionFactory.CoordinateOutOfBound(nameof(coordinate));
                }

                this._cells[coordinate.Position(this.Size)] = value;
            }
        }

        /// <summary>
        /// Get an matrix array of all cells on the GameBoard
        /// </summary>
        /// <returns>matrix array of all cells</returns>
        public Cell[,] Cells()
        {
            var ret = new Cell[this.Size.Rows, this.Size.Columns];
            for (int n = 0; n < this._cells.Length; n++) {
                ret[n % this.Size.Rows, n / this.Size.Rows] = this._cells[n];
            }

            return ret;
        }

        /// <summary>
        /// Initialization Clears the GameBoard making all cells empty
        /// </summary>
        public void Initialize()
        {
            for (int n = 0; n < this._cells.Length; n++) {
                this._cells[n] = Cell.Create(BoardCoordinate.FromBoardIndex(this, n));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            for (int n = 0; n < this._cells.Length; n++) {
                this._cells[n].Reset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Cell OccupyCell(Players.Player player, BoardCoordinate coordinate)
        {
            var cell = this[coordinate];
            if (cell.IsEmpty) {
                cell.Occupant = player;
            }

            return cell;
        }

        /// <inheritdoc/>
        public IEnumerator<Cell> GetEnumerator()
        {
            return ((IEnumerable<Cell>)this._cells).GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Cell>)this._cells).GetEnumerator();
        }
    }
}