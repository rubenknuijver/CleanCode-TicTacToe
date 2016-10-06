namespace TicTacToeWinForms.Tmc
{
    using GameLibrary;
    using GameLibrary.Players;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using UI;
    using UI.Controls;

    public sealed class PlayerConfiguration
    {
        private PlayerConfigurationDialog _dialog;
        private readonly Game _game;

        public PlayerConfiguration(Game game)
            : this(game, new PlayerConfigurationDialog())
        {
        }

        public PlayerConfiguration(Game game, PlayerConfigurationDialog dialog)
        {
            this._game = game;
            this._dialog = dialog;
            this._dialog.FormClosing += Dialog_FormClosing;
        }

        public PlayerConfigurationDialog Dialog
        {
            get { return _dialog; }
        }

        public bool Show()
        {
            this._dialog.PreparePlayers(_game.Players, _game.MaxPlayers);

            if (this._dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) {
                return false;
            }

            UpdatePlayersInTheGame();

            return true;
        }

        private void UpdatePlayersInTheGame()
        {
            if (!_game.CanRegisterPlayers)
                _game.Reset(true);

            foreach (var item in _dialog.DataSource) {
                if (item.IsCpu) {
                    _game.RegisterPlayer(new ArtificialIntelligencePlayer()
                    {
                        Symbol = item.SelectedSymbol
                    });
                }
                else {
                    _game.RegisterPlayer(new HumanPlayer(item.Name)
                    {
                        Symbol = item.SelectedSymbol
                    });
                }
            }

            _game.PrepareGameRound();
        }

        private void Dialog_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (_dialog.DialogResult == System.Windows.Forms.DialogResult.OK) {
                try {
                    UpdatePlayersInTheGame();
                }
                catch (DuplicatePlayerException ex) {
                    e.Cancel = true;
                }
            }
        }
    }
}
