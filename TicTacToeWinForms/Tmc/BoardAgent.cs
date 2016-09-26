namespace TicTacToeWinForms.Tmc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using GameLibrary;

    public class BoardAgent
    {
        private Game _game;
        private readonly Panel _control;

        public event EventHandler Next;

        public BoardAgent(Game game, Panel control)
        {
            _control = control;
            Control = control;
            this._game = game;
            control.Enabled = false;
        }

        public Panel Control { get; }

        public ICollection<DisplayCell> Cells { get; } = new List<DisplayCell>();

        public void Prepare()
        {
            _control.SuspendLayout();
            _control.Controls.Clear();

            foreach (var cell in _game.Board) {
                var c = new DisplayCell(cell);

                _control.Controls.Add(c.CellControl);
                c.UpdateSize(_game.Board);

                Cells.Add(c);

                c.Click += Cell_Clicked;
            }

            _control.ResumeLayout();            
        }

        public void Pulse()
        {
            
        }

        private void Cell_Clicked(object sender, CellClickEventArgs e)
        {
            if (_game.CurrentGameRound == null) {
                return;
            }

            if (e.Cell.IsEmpty) {             

                var turn = _game.CurrentGameRound.TakeTurn(e.Cell.Coordinate);
                if (turn != null) {
                    ((DisplayCell)sender).DrawPlaySymbol(turn.Player.Symbol);
                }

                _game.ProcessRules();
                _game.CurrentGameRound.NextTurn();
            }            
        }
    }
}
