namespace TicTacToeWinForms.Pdc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class Drawings
    {
        public Palette Palette { get; }

        public Drawings(int pixelWidth, int pixelHeight)
        {
            var palette = new BitmapPalette(new List<Color>());
            var writeableBitmap = new WriteableBitmap(
                        pixelWidth,
                        pixelHeight,
                        96,
                        96,
                        PixelFormats.Indexed8, // Paletted bitmap with 256 colours
                        palette);
        }

        /// <summary>
        /// Calculates the Screen Dots Per Inch of a Display Monitor
        /// </summary>
        /// <param name="monitorSize">Size, in inches</param>
        /// <param name="resolutionWidth">width resolution, in pixels</param>
        /// <param name="resolutionHeight">height resolution, in pixels</param>
        /// <returns>double precision value indicating the Screen Dots Per Inch</returns>
        public static double ScreenDPI(int monitorSize, int resolutionWidth, int resolutionHeight)
        {
            //int resolutionWidth = 1600;
            //int resolutionHeight = 1200;
            //int monitorSize = 19;
            if (0 < monitorSize) {
                double screenDpi = Math.Sqrt(Math.Pow(resolutionWidth, 2) + Math.Pow(resolutionHeight, 2)) / monitorSize;
                return screenDpi;
            }

            return 0;
        }
    }

    /// <summary>
    /// https://myworldofcolour.wordpress.com/category/theory/
    /// </summary>
    public class Palette : List<Color>
    {
        public Color GenerateRandomColor(Color mix)
        {
            Random random = new Random();
            byte[] rgb = new byte[3];

            random.NextBytes(rgb);

            byte red = rgb[0];
            byte green = rgb[1];
            byte blue = rgb[2];

            red = (byte)((red + mix.R) / 2);
            green = (byte)((green + mix.G) / 2);
            blue = (byte)((blue + mix.B) / 2);

            Color color = Color.FromArgb(255, red, green, blue);
            return color;
        }

    }
}
