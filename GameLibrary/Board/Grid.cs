using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Board
{
    public class Grid
    {
        internal readonly int _rowSize;
        internal readonly int _columnSize;
        internal readonly Cell[] _cells;

        public Cell[,] Cells()
        {
            var ret = new Cell[_rowSize, _columnSize];
            for (int n = 0; n < _cells.Length; n++) {
                ret[n % _rowSize, n / _rowSize] = _cells[n];
            }
            return ret;
        }

        public Cell this[int rowIndex, int columnIndex]
        {
            get { return _cells[columnIndex * rowIndex]; }
            set { _cells[columnIndex * rowIndex] = value; }
        }

        public Grid(int rowSize, int columnSize)
        {
            _columnSize = columnSize;
            _rowSize = rowSize;

            _cells = new Cell[rowSize * columnSize];
        }

        public void Initialize()
        {
            for (int n = 0; n < _rowSize * _columnSize; n++) {
                _cells[n] = Cell.Create(n);
            }
        }
    }
}