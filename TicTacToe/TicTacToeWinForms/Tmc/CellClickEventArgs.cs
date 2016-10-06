
namespace TicTacToeWinForms.Tmc
{
    using GameLibrary.Board;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CellClickEventArgs : EventArgs
    {
        private Cell _cell;

        public CellClickEventArgs(Cell cell)
        {
            this._cell = cell;
        }

        public Cell Cell
        {
            get { return _cell; }
        }
    }
}
