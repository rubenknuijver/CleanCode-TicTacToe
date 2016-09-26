namespace GameLibrary.Players
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public abstract class PlayerSymbol : Styx.Enumeration//, ICustomMarker
    {
        /// <summary>
        /// No Symbol
        /// </summary>
        public static readonly PlayerSymbol Empty = new EmptyMarkType();

        /// <summary>
        /// X
        /// </summary>
        public static readonly PlayerSymbol X = new XMarkType();

        /// <summary>
        /// O
        /// </summary>
        public static readonly PlayerSymbol O = new OMarkType();

        protected PlayerSymbol(int value, string displayName)
            : base(value, displayName)
        {
        }

        public virtual void DrawSymbol(Image image)
        {
            if (image == null) {
                return;
            }

            using (var g = Graphics.FromImage(image)) {
                g.Clear(Color.White);
            }
        }

        private class EmptyMarkType : PlayerSymbol
        {
            public EmptyMarkType()
                : base(0, "Empty")
            {
            }
        }

        private class XMarkType : PlayerSymbol
        {
            public XMarkType()
                : base(1, "X")
            {
            }

            public override void DrawSymbol(Image image)
            {
                const int margin = 0;
                var pen = new Pen(Brushes.DarkBlue, (image.Width / image.VerticalResolution) * 5f)
                {
                    Alignment = System.Drawing.Drawing2D.PenAlignment.Center
                };

                using (var g = Graphics.FromImage(image)) {
                    // g.Clear(Color.White);
                    g.DrawLine(pen, margin, margin, image.Width - margin, image.Height - margin);
                    g.DrawLine(pen, image.Width - margin, margin, margin, image.Height - margin);
                }
            }
        }

        private class OMarkType : PlayerSymbol
        {
            public OMarkType()
                : base(2, "O")
            {
            }

            public override void DrawSymbol(Image image)
            {
                const int margin = 0;
                var pen = new Pen(Brushes.Red, (image.Width / image.VerticalResolution) * 5f)
                {
                    Alignment = System.Drawing.Drawing2D.PenAlignment.Inset
                };

                using (var g = Graphics.FromImage(image)) {
                    //g.Clear(Color.White);
                    g.DrawEllipse(pen, margin, margin, image.Width - margin, image.Height - margin);
                }
            }
        }
    }
}
