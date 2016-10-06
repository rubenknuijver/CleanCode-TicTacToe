namespace TicTacToeWinForms.UI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using GameLibrary.Players;
    using Styx.Diagnostics;

    public class PlayerSymbolSelectorItem
    {
        private PlayerSymbol _item;

        public PlayerSymbolSelectorItem(PlayerSymbol item)
        {
            Argument.ThrowIfNull(item, nameof(item));

            this._item = item;

            this.Image = new Bitmap(48, 48);
            this.Item.DrawSymbol(this.Image);
        }

        public PlayerSymbol Item
        {
            get { return _item; }
        }

        public Image Image
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this._item.DisplayName;
        }
    }
}
