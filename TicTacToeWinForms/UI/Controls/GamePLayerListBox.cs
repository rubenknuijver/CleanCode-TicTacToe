namespace TicTacToeWinForms.UI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class GamePlayerListBox : ListBox
    {
        public GamePlayerListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 18;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

            if (e.Index >= 0) {
                e.DrawBackground();
                
                var textRect = e.Bounds;
                textRect.X += 20;
                textRect.Width -= 20;

                if (DesignMode) {
                    e.Graphics.DrawRectangle(Pens.Red, 2, e.Bounds.Y + 2, 14, 14); // Simulate an icon.
                    TextRenderer.DrawText(e.Graphics, "GamePLayerListBox", e.Font, textRect, e.ForeColor, flags);
                }
                else {
                    var item = Items[e.Index] as GameLibrary.Players.Player;
                    if (item != null) {

                        var symbol = new Bitmap(48, 48);
                        item.Symbol.DrawSymbol(symbol);

                        e.Graphics.DrawImage(symbol, 2, e.Bounds.Y + 2, 14, 14); // Simulate an icon.
                        TextRenderer.DrawText(e.Graphics, item.Name, e.Font, textRect, e.ForeColor, flags);
                    }
                }
                e.DrawFocusRectangle();
            }
        }
    }
}
