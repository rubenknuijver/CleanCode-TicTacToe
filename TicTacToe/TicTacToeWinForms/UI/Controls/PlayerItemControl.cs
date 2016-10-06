namespace TicTacToeWinForms.UI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using GameLibrary.Players;
    using Pdc;

    [DefaultBindingProperty("DataSource")]
    public partial class PlayerItemControl : UserControl
    {

        private PlayerItem _dataSource;

        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [Category("Data")]
        [DefaultValue(null)]
        public PlayerItem DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
            }
        }

        public PlayerItemControl(PlayerItem player)
        {
            InitializeComponent();
            DataSource = player;

            this.checkBox1.DataBindings.Add(new Binding("Checked", DataSource, "IsCpu", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.DataBindings.Add("Text", DataSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);

            var bind = new Binding("Enabled", DataSource, "IsCpu", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox1.DataBindings.Add(bind);
            bind.Format += SwitchBool;
            bind.Parse += SwitchBool;

            //playerSymbolSelector1.DataBindings.Add("SelectedItem.Item", DataSource, "SelectedSymbol", false, DataSourceUpdateMode.OnPropertyChanged);
            playerSymbolSelector1.SelectedValueChanged += SelectedSymbolChanged;
        }

        private void SelectedSymbolChanged(object sender, EventArgs e)
        {
            if(playerSymbolSelector1.SelectedItem is PlayerSymbolSelectorItem) {
                var item = playerSymbolSelector1.SelectedItem as PlayerSymbolSelectorItem;
                DataSource.SelectedSymbol = item.Item;
            }
        }

        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            e.Value = !((bool)e.Value);
        }
    }
}
