namespace TicTacToeWinForms.UI.Controls
{
    using System;
    using System.Linq;
    using GameLibrary.Players;
    using Pdc;
    using Styx.Diagnostics;

    public class PlayerItem : NotificationObjectBase
    {
        private bool _isCpu;
        private string _name;
        private PlayerSymbol _selectedSymbol;

        public PlayerItem()
        {
        }
        public PlayerItem(Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));
            _isCpu = player is ArtificialIntelligencePlayer;
            _name = player.Name;
        }
        
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;

                _name = value;
                OnPropertyChanged();
            }
        }
        public bool IsCpu
        {
            get { return _isCpu; }
            set
            {
                if (_isCpu == value)
                    return;

                _isCpu = value;
                OnPropertyChanged();
            }
        }

        public PlayerSymbol SelectedSymbol
        {
            get
            {
                return _selectedSymbol;
            }
            set
            {
                if (_selectedSymbol == value)
                    return;

                _selectedSymbol = value;
                OnPropertyChanged();
            }
        }
    }
}
