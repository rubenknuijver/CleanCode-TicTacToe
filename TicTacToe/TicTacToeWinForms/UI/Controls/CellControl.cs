using System;
using GameLibrary.Board;

namespace TicTacToeWinForms.UI.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class CellControl : PictureBox
    {
        bool _mouseOver;

        public CellControl()
        {
            this.Cursor = Cursors.Hand;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void AdjustToBoard(BoardSize boardSize)
        {
            if (this.Parent != null) {
                this.Width = this.Parent.Width / boardSize.Columns;
                this.Height = this.Parent.Height / boardSize.Rows;
            }
        }

        public void MapCoordinate(Cell cell)
        {
            Location = new Point(
                cell.Coordinate.X * this.Width,
                cell.Coordinate.Y * this.Height
                );
        }

        public void RegisterClickAction(Action action)
        {
            this.Click += (sender, args) => {
                action?.Invoke();
            };
        }

        public void DrawSymbol(Action<Image> draw)
        {
            this.SuspendLayout();
            draw?.Invoke(this.Image);
            this.Invalidate();
            this.ResumeLayout();
        }
        public static Image CreateEmptyImage(Color color)
        {
            var flag = new Bitmap(100, 100);
            using (var flagGraphics = Graphics.FromImage(flag)) {
                flagGraphics.Clear(color);
            }
            return flag;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this._mouseOver = false;
            this.Invalidate(true);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this._mouseOver = true;
            this.Invalidate(true);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled) {
                this.Visible = true;
            }
            else {
                this.Visible = false;
            }

            base.OnEnabledChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_mouseOver)
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Dotted);
        }
    }
}
