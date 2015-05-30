using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace QuadTree
{
    public class Element
    {
        public Size Offset;
        public bool Hovered;
        private Point position;
        public Point Position {get{return this.position + Offset;} set{this.position = value;}}
        public static Size drawSizeRegularPX = new Size(2, 2);
        public static Size drawSizeHoverPX = new Size(4, 4);
        
        public Element(int x, int y) {
            Position = new Point(x, y);
        }
        public Element(Point position) {
            Position = position;
        }

        public bool IntersectsWith(System.Drawing.Rectangle externalRectangle)
        {
            return externalRectangle.Contains(Position);
        }

        public void Draw(Graphics g, bool considerMouse, Size offset)
        {
            Offset = offset;

            if (considerMouse)
            {
                Hovered = Form1.MouseSelection.IsVisible(Position);
            }

            if (Hovered)   // Selected
            {
                g.FillRectangle(new SolidBrush(Color.Green), new System.Drawing.Rectangle(Position, Element.drawSizeHoverPX));
            }
            else                                // Not Selected
            {
                g.FillRectangle(new SolidBrush(Color.Blue), new System.Drawing.Rectangle(Position, Element.drawSizeRegularPX));
            }
        }
    }
}
