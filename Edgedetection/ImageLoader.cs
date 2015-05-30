using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace QuadTree
{


    [Flags]
    public enum PixelAround
    {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 4,
        Left = 8
    }

    class ImageLoader
    {

        public static ImageInfo MakeShape(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);
            ImageInfo info = new ImageInfo();

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Point point = new Point(x, y);
                    if (IsBorderPixel(source, point))
                    {
                        info.AddEdgePixel(point);
                        result.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return info;
        }

        public static bool IsBorderPixel(Bitmap source, Point start)
        {
            if (source.GetPixel(start.X, start.Y).A == 0)
            {
                return false;
            }

            PixelAround pixelAround = 0;
            // right valid
            if (start.X + 1 < source.Width)
            {
                if (source.GetPixel(start.X + 1, start.Y).A > 0)
                pixelAround = pixelAround | PixelAround.Right;
            }

            // left valid
            if (start.X - 1 >= 0)
            {
                if (source.GetPixel(start.X - 1, start.Y).A > 0)
                pixelAround = pixelAround | PixelAround.Left;
            }

            // up valid
            if (start.Y - 1 >= 0)
            {
                if (source.GetPixel(start.X, start.Y - 1).A > 0)
                pixelAround = pixelAround | PixelAround.Up;
            }

            // down valid
            if (start.Y + 1 < source.Height)
            {
                if (source.GetPixel(start.X, start.Y + 1).A > 0)
                pixelAround = pixelAround | PixelAround.Down;
            }

            return (pixelAround != 0 && (int)pixelAround != 15);
        }
    }
}
