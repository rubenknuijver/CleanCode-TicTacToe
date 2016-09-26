namespace TicTacToeWinForms.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Controls;
    using GameLibrary;

    public partial class GameConfigurationDialog : Form
    {
        public GameConfigurationDialog(Game game)
        {
            InitializeComponent();

            if (DesignMode) {
                propertyGrid1.SelectedObject = new Game(new InMemoryBus(), new GameLibrary.Board.GameBoard(3, 3));
            }
            else {
                propertyGrid1.SelectedObject = game;
            }
        }
    }
}
