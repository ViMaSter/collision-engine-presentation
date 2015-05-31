namespace QuadTree
{
    partial class FormQuadtree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.quadtree_insert = new System.Windows.Forms.Button();
            this.quadtree_clear = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Quadtree = new System.Windows.Forms.TabPage();
            this.panel_Quadtree = new System.Windows.Forms.Panel();
            this.checkBox_showNodes = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tab_Quadtree.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadtree_insert
            // 
            this.quadtree_insert.Location = new System.Drawing.Point(6, 6);
            this.quadtree_insert.Name = "quadtree_insert";
            this.quadtree_insert.Size = new System.Drawing.Size(129, 23);
            this.quadtree_insert.TabIndex = 0;
            this.quadtree_insert.Text = "Random &Insertion";
            this.quadtree_insert.UseVisualStyleBackColor = true;
            this.quadtree_insert.Click += new System.EventHandler(this.quadtree_insert_Click);
            // 
            // quadtree_clear
            // 
            this.quadtree_clear.Location = new System.Drawing.Point(141, 6);
            this.quadtree_clear.Name = "quadtree_clear";
            this.quadtree_clear.Size = new System.Drawing.Size(130, 23);
            this.quadtree_clear.TabIndex = 1;
            this.quadtree_clear.Text = "&Clear";
            this.quadtree_clear.UseVisualStyleBackColor = true;
            this.quadtree_clear.Click += new System.EventHandler(this.quadtree_clear_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Quadtree);
            this.tabControl1.Location = new System.Drawing.Point(13, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(717, 406);
            this.tabControl1.TabIndex = 2;
            // 
            // tab_Quadtree
            // 
            this.tab_Quadtree.Controls.Add(this.panel_Quadtree);
            this.tab_Quadtree.Controls.Add(this.quadtree_insert);
            this.tab_Quadtree.Controls.Add(this.quadtree_clear);
            this.tab_Quadtree.Location = new System.Drawing.Point(4, 22);
            this.tab_Quadtree.Name = "tab_Quadtree";
            this.tab_Quadtree.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Quadtree.Size = new System.Drawing.Size(709, 380);
            this.tab_Quadtree.TabIndex = 0;
            this.tab_Quadtree.Text = "Quadtree";
            this.tab_Quadtree.UseVisualStyleBackColor = true;
            this.tab_Quadtree.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel_Quadtree_Wheel);
            // 
            // panel_Quadtree
            // 
            this.panel_Quadtree.Location = new System.Drawing.Point(6, 35);
            this.panel_Quadtree.Name = "panel_Quadtree";
            this.panel_Quadtree.Size = new System.Drawing.Size(697, 339);
            this.panel_Quadtree.TabIndex = 2;
            this.panel_Quadtree.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Quadtree_Paint);
            this.panel_Quadtree.MouseLeave += new System.EventHandler(this.panel_Quadtree_MouseLeave);
            this.panel_Quadtree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Quadtree_MouseMove);
            // 
            // checkBox_showNodes
            // 
            this.checkBox_showNodes.AutoSize = true;
            this.checkBox_showNodes.Checked = true;
            this.checkBox_showNodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_showNodes.Location = new System.Drawing.Point(17, 13);
            this.checkBox_showNodes.Name = "checkBox_showNodes";
            this.checkBox_showNodes.Size = new System.Drawing.Size(87, 17);
            this.checkBox_showNodes.TabIndex = 3;
            this.checkBox_showNodes.Text = "Show Nodes";
            this.checkBox_showNodes.UseVisualStyleBackColor = true;
            this.checkBox_showNodes.CheckedChanged += new System.EventHandler(this.checkBox_showNodes_CheckedChanged);
            // 
            // FormQuadtree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 460);
            this.Controls.Add(this.checkBox_showNodes);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormQuadtree";
            this.Text = "Quadtree";
            this.tabControl1.ResumeLayout(false);
            this.tab_Quadtree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quadtree_insert;
        private System.Windows.Forms.Button quadtree_clear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Quadtree;
        private System.Windows.Forms.Panel panel_Quadtree;
        private System.Windows.Forms.CheckBox checkBox_showNodes;
    }
}

