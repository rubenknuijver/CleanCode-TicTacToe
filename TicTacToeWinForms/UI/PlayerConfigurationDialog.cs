using System;
using GameLibrary.Players;

namespace TicTacToeWinForms.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Linq;
    using System.Windows.Forms;
    using TicTacToeWinForms.UI.Controls;

    public partial class PlayerConfigurationDialog : Form
    {
        private BindingList<PlayerItem> _dataSource;

        [Category("Data")]
        [DefaultValue(null)]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [Editor("System.Windows.Forms.Design.DataSourceListEditor, System.Design", typeof(UITypeEditor))]
        public BindingList<PlayerItem> DataSource
        {
            get { return _dataSource; }
            set
            {
                if (_dataSource == value)
                    return;

                _dataSource = value;
                BindToControls();
            }
        }

        public PlayerConfigurationDialog()
        {
            InitializeComponent();
        }

        public void PreparePlayers(BindingList<Player> players, int maxPlayers)
        {
            var playerItems = new BindingList<PlayerItem>();

            CopyExistingPlayers(players, playerItems);

            FillToMaximumAllowedPlayers(maxPlayers, playerItems);

            this.DataSource = playerItems;
        }

        private static void FillToMaximumAllowedPlayers(int maxPlayers, BindingList<PlayerItem> playerItems)
        {
            var posibleSymbols = Styx.Enumeration
                .GetAll<PlayerSymbol>()
                .ToArray();

            for (int i = playerItems.Count; i < maxPlayers; i++) {
                var player = new PlayerItem { SelectedSymbol = posibleSymbols[i % posibleSymbols.Length] };
                playerItems.Add(player);
            }
        }

        private static void CopyExistingPlayers(BindingList<Player> players, BindingList<PlayerItem> playerItems)
        {
            foreach (var player in players) {
                playerItems.Add(new PlayerItem(player));
            }
        }

        private void BindToControls()
        {
            SuspendLayout();
            pnlPlayers.Controls.Clear();
            foreach (var item in DataSource) {
                var ctrl = new PlayerItemControl(item)
                {
                    Width = pnlPlayers.ClientSize.Width - 6
                };
                pnlPlayers.Controls.Add(ctrl);
            }
            ResumeLayout();
        }
    }
}
