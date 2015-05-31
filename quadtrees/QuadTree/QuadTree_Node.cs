using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    public class Node
    {
        private int Depth = -1;
        public int MaximumDepth = -1;
        public int MaxElementsPerNode = -1;
        private bool hoveredFlag = false;
        private bool hovered = false;
        public bool Hovered
        {
            set
            {
                if (value)
                {
                    this.hoveredFlag = true;
                    this.hovered = true;
                }
                else
                {
                    if (this.hoveredFlag)
                    {
                        this.hoveredFlag = false;
                    }
                    else
                    {
                        this.hovered = false;
                    }
                }
            }
            get
            {
                return this.hovered;
            }
        }
        private Rectangle bounds;
        public Rectangle Bounds { set { this.bounds = value; } get { Rectangle b = this.bounds == null ? new Rectangle() : this.bounds; b.Location += this.Offset; return b; } }
        public Size Offset;
        public Node[] SubNodes;

        public List<Element> Elements = new List<Element>();

        public void Render(Graphics g, bool considerMouse, Size offset)
        {
            Offset = offset;
            Hovered = false;

            if (considerMouse) {
                Hovered = Form1.MouseSelection.GetBounds().IntersectsWith(this.Bounds);
            }

            if (Form1.DrawNodes)
            {
                if (Hovered)
                {
                    Color c = Color.FromArgb((int)(((float)Depth / (float)MaximumDepth) * 255), 255, 128, 0);
                    g.FillRectangle(new SolidBrush(c), Bounds);
                }

                g.DrawRectangle(new Pen(Color.Red), Bounds);
            }

            if (SubNodes == null)
            {
                foreach (Element element in Elements)
                {
                    element.Draw(g, considerMouse, Offset);
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    SubNodes[i].Render(g, considerMouse, Offset);
                }
            }
        }

        public void SplitUp()
        {
            Rectangle b = Bounds;
            // create new subnodes
            SubNodes = new Node[4];
            SubNodes[0] = new Node(Depth + 1, new Rectangle((Bounds.X + Bounds.Width / 2 * 0), (Bounds.Y + Bounds.Height / 2 * 0), (Bounds.Width / 2), (Bounds.Height / 2)), MaximumDepth, MaxElementsPerNode, Offset);
            SubNodes[1] = new Node(Depth + 1, new Rectangle((Bounds.X + Bounds.Width / 2 * 1), (Bounds.Y + Bounds.Height / 2 * 0), (Bounds.Width / 2), (Bounds.Height / 2)), MaximumDepth, MaxElementsPerNode, Offset);
            SubNodes[2] = new Node(Depth + 1, new Rectangle((Bounds.X + Bounds.Width / 2 * 0), (Bounds.Y + Bounds.Height / 2 * 1), (Bounds.Width / 2), (Bounds.Height / 2)), MaximumDepth, MaxElementsPerNode, Offset);
            SubNodes[3] = new Node(Depth + 1, new Rectangle((Bounds.X + Bounds.Width / 2 * 1), (Bounds.Y + Bounds.Height / 2 * 1), (Bounds.Width / 2), (Bounds.Height / 2)), MaximumDepth, MaxElementsPerNode, Offset);
            // split up old elements into new nodes
            foreach (Element Element in Elements)
            {
                for (int i = 0; i < 4; i++)
                {

                    if (SubNodes[i].Bounds.Contains(Element.Position))
                        SubNodes[i].Add(Element);
                }
            }
            Elements.Clear();
        }

        public Node(int depth, Rectangle bounds, int maximumDepth, int maxElementsPerNode, Size offset)
        {
            MaximumDepth = maximumDepth;
            MaxElementsPerNode = maxElementsPerNode;
            if (depth > MaximumDepth)
                throw new TooDeepException();

            Depth = depth;
            Bounds = bounds;
            Offset = offset;
        }

        public void Add(Element newElement)
        {
            if (SubNodes == null)
            {
                Elements.Add(newElement);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (SubNodes[i].Bounds.Contains(newElement.Position))
                        SubNodes[i].Add(newElement);
                }
            }

            bool test = Depth + 1 >= MaximumDepth;

            if (Elements.Count > MaxElementsPerNode && Depth+1 <= MaximumDepth)
            {
                SplitUp();
            }
        }

        public bool IntersectsWith(Rectangle externalRectangle)
        {
            return Bounds.IntersectsWith(externalRectangle);
        }

        public List<Node> FindIntersectingSubNodes(Rectangle externalRectangle)
        {
            List<Node> intersections = new List<Node>();
            if (SubNodes != null)
            {
                foreach (Node node in SubNodes)
                {
                    if (node.IntersectsWith(externalRectangle)) {
                        intersections.AddRange(node.FindIntersectingSubNodes(externalRectangle));
                        intersections.Add(node);
                    }
                    else
                    {
                        node.Hovered = false;
                        if (node.SubNodes == null) {
                            foreach (Element element in node.Elements)
                            {
                                element.Hovered = false;
                            }
                        }
                    }
                }
            }

            return intersections;
        }
    }
}
