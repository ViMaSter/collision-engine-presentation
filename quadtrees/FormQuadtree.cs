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
    public partial class FormQuadtree : Form
    {
        private static Random r;
        public static bool DrawNodes = true;

        public FormQuadtree()
        {
            InitializeComponent();
            r = new Random();

            InitQuadTree();
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



        private void checkBox_showNodes_CheckedChanged(object sender, EventArgs e)
        {
            DrawNodes = checkBox_showNodes.Checked;

            panel_Quadtree.Refresh();
        }
    }
}
