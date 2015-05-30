using System;
using System.Drawing;
using System.Collections.Generic;

namespace QuadTree
{
    public class ImageInfo
    {
        public List<Point> EdgePixels;

        public static implicit operator bool(ImageInfo imageInfo)
        {
            return imageInfo != new ImageInfo();
        }

        public static implicit operator Bitmap(ImageInfo imageInfo) {
            Bitmap result = new Bitmap(imageInfo.getDimensions().Width, imageInfo.getDimensions().Height);
            int i = 0;
            foreach (Point point in imageInfo.EdgePixels)
            {
                try
                {
                    result.SetPixel(point.X, point.Y, Color.Black);
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee);
                }
                i++;
            }
            return result;
        }

        public Rectangle getDimensions() {
            int smallX = int.MaxValue;
            int smallY = int.MaxValue;
            int largeX = int.MinValue;
            int largeY = int.MinValue;

            foreach (Point point in EdgePixels) {
                if (point.X < smallX) {
                    smallX = point.X;
                }
                if (point.X > largeX) {
                    largeX = point.X;
                }
    
                if (point.Y < smallY) {
                    smallY = point.Y;
                }
                if (point.Y > largeY) {
                    largeY = point.Y;
                }
            }
            return new System.Drawing.Rectangle(smallX, smallY, largeX+1, largeY+1);
        }

        public ImageInfo()
        {
            EdgePixels = new List<Point>();
        }

        public void AddEdgePixel(Point point) {
            if (!EdgePixels.Contains(point))
            {
                EdgePixels.Add(point);
            }
        }
    }
}
