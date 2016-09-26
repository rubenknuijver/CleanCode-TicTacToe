namespace TicTacToeWinForms.UI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using GameLibrary.Players;
    using Styx.Diagnostics;

    public class PlayerSymbolSelector : ComboBox
    {
        public PlayerSymbolSelector()
        {
            InitializeComponent();

            this.BeginUpdate();
            foreach (var item in Styx.Enumeration.GetAll<PlayerSymbol>()) {
                var sym = new PlayerSymbolSelectorItem(item);
                Items.Add(sym);
            }
            this.EndUpdate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0 && e.Index < Items.Count) {
                var item = Items[e.Index] as PlayerSymbolSelectorItem;

                Graphics g = e.Graphics;
                using (Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                          ? new SolidBrush(SystemColors.Highlight)
                          : new SolidBrush(e.BackColor)) {

                    g.FillRectangle(brush, e.Bounds);

                    using (Brush textBrush = new SolidBrush(e.ForeColor)) {
                        g.DrawImage(item.Image, e.Bounds.X, e.Bounds.Y, ItemHeight, ItemHeight);
                        //g.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(e.ForeColor),
                        //    new RectangleF(e.Bounds.X + ItemHeight, e.Bounds.Y, DropDownWidth, ItemHeight));

                        g.DrawString(Items[e.Index].ToString(),
                                 e.Font,
                                 textBrush,
                                 new RectangleF(e.Bounds.X + ItemHeight + 5, e.Bounds.Y, DropDownWidth, ItemHeight),
                                 StringFormat.GenericDefault);
                    }
                }
                //var rectSrc = new Rectangle(0, 0, item.Image.Width, item.Image.Height);
                //var rectDest = new Rectangle(e.Bounds.Left, e.Bounds.Top, 16, 16);
                //var image = item.Image.GetThumbnailImage(16, 16, () => false, IntPtr.Zero);

                // Draw the colored 16 x 16 square
                //e.Graphics.DrawImage(image, e.Bounds.Left, e.Bounds.Top);
                // Draw the value (in this case, the color name)
                //e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);
            }

            e.DrawFocusRectangle();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownStyle = ComboBoxStyle.DropDownList;

            ItemHeight = 20;
            Height = ItemHeight + 4;
            // 
            // PlayerSymbolSelector
            // 
            this.ResumeLayout(false);

        }
    }
}
