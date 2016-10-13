namespace TicTacToeWinForms.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using GameLibrary;
    using GameLibrary.Messaging;
    using GameLibrary.Board;

    public partial class GameConfigurationDialog : Form
    {
        public GameConfigurationDialog(Game game)
        {
            InitializeComponent();

            if (DesignMode) {
                propertyGrid1.SelectedObject = new Game(new InMemoryBus(), new GameBoard(new BoardSize(3, 3)));
            }
            else {
                propertyGrid1.SelectedObject = game;
            }
        }
    }
}
