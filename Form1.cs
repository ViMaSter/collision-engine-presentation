using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadTree
{
    public partial class Form1 : Form
    {
        private static Random r;
        public static bool DrawNodes = true;

        public Form1()
        {
            InitializeComponent();
            r = new Random();

            InitQuadTree();
            InitEdgedetection();
            InitPixelPerfect();
        }


        //// QuadTree
        // config
        public static System.Drawing.Rectangle MainNodeArea;

        // variables
        public static Graphics QuadTreeGraphics;
        private static Node MainNode;
        public static Size SelectionRadius = new Size(100, 100);
        public static Point MousePos;
        public static GraphicsPath MouseSelection; // used to determine, if element is in selection

        public void InitQuadTree() {
            QuadTreeGraphics = panel_Quadtree.CreateGraphics();

            MainNodeArea = new System.Drawing.Rectangle(0, 0, panel_Quadtree.Width, panel_Quadtree.Height);

            MainNode = new Node(0, MainNodeArea, 6, 3, new Size(0, 0));

            panel_Quadtree.Refresh();
        }

        private void quadtree_insert_Click(object sender, EventArgs e)
        {
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));

            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));
            MainNode.Add(new Element((r.Next() % MainNodeArea.Width) + MainNodeArea.X, (r.Next() % MainNodeArea.Height) + MainNodeArea.X));

            panel_Quadtree.Refresh();
        }

        private void quadtree_clear_Click(object sender, EventArgs e)
        {
            MainNode = new Node(0, MainNodeArea, 6, 3, new Size(0, 0));
            panel_Quadtree.Refresh();
        }

        private void panel_Quadtree_MouseMove(object sender, MouseEventArgs e) {
            MousePos = e.Location;
            panel_Quadtree.Refresh();
        }

        private void panel_Quadtree_Wheel(object sender, MouseEventArgs e)
        {
            SelectionRadius.Width += e.Delta / 120;
            SelectionRadius.Height += e.Delta / 120;

            panel_Quadtree.Refresh();
        }

        private void panel_Quadtree_MouseLeave(object sender, EventArgs e) {
            MousePos = new Point(-100, -100);
            panel_Quadtree.Refresh();
        }

        private void panel_Quadtree_Paint(object sender, PaintEventArgs e) {
            MouseSelection = new GraphicsPath();
            MouseSelection.AddEllipse(new System.Drawing.Rectangle(MousePos - new Size(SelectionRadius.Width / 2, SelectionRadius.Height / 2), SelectionRadius));

            // render Nodes
            MainNode.Render(QuadTreeGraphics, true, new Size(0, 0));

            // render MouseSelection
            QuadTreeGraphics.DrawEllipse(new Pen(Color.Green), new System.Drawing.Rectangle(MousePos - new Size(SelectionRadius.Width / 2, SelectionRadius.Height / 2), SelectionRadius));
        }




        //// Edgedetection
        public static Bitmap image;
        public static ImageInfo mask;
        public static string FilePath = "";

        public Graphics EdgedetectionRawGraphics;
        public Graphics EdgedetectionDoneGraphics;

        public void InitEdgedetection() {
            EdgedetectionRawGraphics = edgedetection_before.CreateGraphics();
            EdgedetectionDoneGraphics = edgedetection_after.CreateGraphics();
        }

        public ImageInfo RenderNewImages(string filePath)
        {
            if (filePath != "")
            {
                try
                {
                    return ImageLoader.MakeShape(new Bitmap(Bitmap.FromFile(filePath)));
                }
                catch (IOException)
                {
                    return new ImageInfo();
                }
            } else {
                return new ImageInfo();
            }
        }

        private void edgedetection_before_Paint(object sender, PaintEventArgs e)
        {
            if (image != null)
            {
                EdgedetectionRawGraphics.DrawImage(image, new Point(0, 0));
            }
        }
        private void edgedetection_after_Paint(object sender, PaintEventArgs e)
        {
            if (mask != null)
            {
                Bitmap map = mask;
                EdgedetectionDoneGraphics.DrawImage(mask, new Point(0, 0));
            }
        }

        private void edgedetection_before_Click(object sender, EventArgs e) {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "";
            fDialog.Filter += "PNG (*.png)|*.png|"
                           +  "TIFF (*.tif,*.tiff)|*.tif;*.tiff|"
                           + "JPG (*.jpg,*.jpeg)|*.jpg;*.jpeg";
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FilePath = fDialog.FileName;
                Console.WriteLine(FilePath);
                try
                {
                    image = new Bitmap(Bitmap.FromFile(FilePath));
                    mask = RenderNewImages(FilePath);
                    if (mask != new ImageInfo())
                    {
                        edgedetection_before_label.Visible = false;
                        pixelperfect_updateNode();
                        pixelperfect_panel.Refresh();
                        edgedetection_before.Refresh();
                        edgedetection_after.Refresh();
                    }
                }
                catch (IOException)
                {

                }
            }
        }



        //// Pixelperfect
        public Graphics PixelPerfectGraphics;
        public static Node PixelPerfectNode;
        public static System.Drawing.Rectangle PixelPerfectRectangle;
        public static Node PixelPerfectMouseNode;
        public static System.Drawing.Rectangle PixelPerfectMouseRectangle;
        public void InitPixelPerfect()
        {
            PixelPerfectGraphics = pixelperfect_panel.CreateGraphics();
        }

        public void pixelperfect_updateNode()
        {
            PixelPerfectRectangle = mask.getDimensions();
            PixelPerfectNode = new Node(0, PixelPerfectRectangle, 4, 6, new Size(0, 0));
            if (mask != null)
            {
                foreach (Point point in mask.EdgePixels)
                {
                    PixelPerfectNode.Add(new Element(point.X, point.Y));
                }
            }

            PixelPerfectMouseRectangle = mask.getDimensions();
            PixelPerfectMouseNode = new Node(0, PixelPerfectMouseRectangle, 4, 6, new Size(0, 0));
            if (mask != null)
            {
                foreach (Point point in mask.EdgePixels)
                {
                    PixelPerfectMouseNode.Add(new Element(point.X, point.Y));
                }
            }
        }
        private void pixelperfect_panel_Paint(object sender, PaintEventArgs e)
        {
            PixelPerfectNode.Render(PixelPerfectGraphics, false, new Size(20, 20));
            PixelPerfectMouseNode.Render(PixelPerfectGraphics, false, new Size(MousePos.X, MousePos.Y));
        }

        private void checkBox_showNodes_CheckedChanged(object sender, EventArgs e)
        {
            DrawNodes = checkBox_showNodes.Checked;

            panel_Quadtree.Refresh();
            pixelperfect_panel.Refresh();
        }

        private void pixelperfect_panel_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;
            if (PixelPerfectNode != null)
            {
                List<Node> Overlap = PixelPerfectNode.FindIntersectingSubNodes(PixelPerfectMouseNode.Bounds);
                foreach (Node node in Overlap)
                {
                    node.Hovered = true;
                    foreach (Element element in node.Elements)
                    {
                        if (element.IntersectsWith(PixelPerfectMouseNode.Bounds))
                            element.Hovered = true;
                        else
                            element.Hovered = false;
                    }
                }
                if (Overlap.Count > 0)
                {
                    Console.WriteLine(DateTime.Now.Millisecond.ToString());
                }
                pixelperfect_panel.Refresh();
            }
        }
    }
}
