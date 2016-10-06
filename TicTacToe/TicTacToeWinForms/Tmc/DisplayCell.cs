using System.Windows.Forms;
namespace TicTacToeWinForms.Tmc
{
    using GameLibrary.Board;
    using GameLibrary.Players;
    using Styx.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using UI.Controls;

    public class DisplayCell
    {
        private readonly Cell _cell;

        public EventHandler<CellClickEventArgs> Click;

        public DisplayCell(Cell cell)
            : this(cell, new CellControl())
        {
        }

        public DisplayCell(Cell cell, CellControl cellControl)
        {
            Argument.ThrowIfNull(cell, nameof(cell));
            Argument.ThrowIfNull(cellControl, nameof(cellControl));

            _cell = cell;
            this.CellControl = cellControl;
            this.CellControl.RegisterClickAction(() => {
                Click?.Invoke(this, new CellClickEventArgs(_cell));
            });
        }

        public CellControl CellControl { get; }


        public void UpdateSize(GameBoard board)
        {
            Argument.ThrowIfNull(board, nameof(board));

            CellControl.AdjustToBoard(board);
            CellControl.MapCoordinate(_cell);

            CellControl.Image = CellControl.CreateEmptyImage(Color.Transparent);
            //CellControl.BackgroundImage = CellControl.CreateEmptyImage(Color.WhiteSmoke);
        }

        public void DrawPlaySymbol(PlayerSymbol symbol)
        {
            Argument.ThrowIfNull(symbol, nameof(symbol));
            this.CellControl.DrawSymbol(symbol.DrawSymbol);
        }
    }
}
