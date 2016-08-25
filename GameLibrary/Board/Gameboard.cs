using GameLibrary.Gamer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public class GameBoard : IEnumerable<Cell>
    {
        internal readonly Cell[] _cells;

        public int RowSize { get; }

        public int ColumnSize { get; }

        public Cell[,] Cells()
        {
            var ret = new Cell[RowSize, ColumnSize];
            for (int n = 0; n < _cells.Length; n++) {
                ret[n % RowSize, n / RowSize] = _cells[n];
            }
            return ret;
        }

        public Cell this[BoardCoordinate coordinate]
        {
            get
            {
                if (!coordinate.IsOnGameBoard(this)) {
                    throw ExceptionFactory.CoordinateOutOfBound(nameof(coordinate));
                }
                return _cells[coordinate.Position(RowSize, ColumnSize)];
            }
            set
            {
                if (!coordinate.IsOnGameBoard(this)) {
                    throw ExceptionFactory.CoordinateOutOfBound(nameof(coordinate));
                }
                _cells[coordinate.Position(RowSize, ColumnSize)] = value;
            }
        }

        public GameBoard(int rowSize, int columnSize)
        {
            ColumnSize = columnSize;
            RowSize = rowSize;

            _cells = new Cell[rowSize * columnSize];
        }

        public void Initialize()
        {
            for (int n = 0; n < RowSize * ColumnSize; n++) {
                _cells[n] = Cell.Create(n);
            }
        }

        public void OccupyCell(Player player, BoardCoordinate coordinate)
        {
            var cell = this[coordinate];
            if (cell.IsEmpty)
                cell.Owner = player;
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return ((IEnumerable<Cell>)_cells).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Cell>)_cells).GetEnumerator();
        }
    }
}