namespace QuadTree
{
    partial class Form1
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
            this.tab_Edgedetection = new System.Windows.Forms.TabPage();
            this.edgedetection_after = new System.Windows.Forms.Panel();
            this.edgedetection_before = new System.Windows.Forms.Panel();
            this.edgedetection_before_label = new System.Windows.Forms.Label();
            this.tab_PixelPerfectCollision = new System.Windows.Forms.TabPage();
            this.pixelperfect_panel = new System.Windows.Forms.Panel();
            this.checkBox_showNodes = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tab_Quadtree.SuspendLayout();
            this.tab_Edgedetection.SuspendLayout();
            this.edgedetection_before.SuspendLayout();
            this.tab_PixelPerfectCollision.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tab_Edgedetection);
            this.tabControl1.Controls.Add(this.tab_PixelPerfectCollision);
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
            // tab_Edgedetection
            // 
            this.tab_Edgedetection.Controls.Add(this.edgedetection_after);
            this.tab_Edgedetection.Controls.Add(this.edgedetection_before);
            this.tab_Edgedetection.Location = new System.Drawing.Point(4, 22);
            this.tab_Edgedetection.Name = "tab_Edgedetection";
            this.tab_Edgedetection.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Edgedetection.Size = new System.Drawing.Size(709, 380);
            this.tab_Edgedetection.TabIndex = 1;
            this.tab_Edgedetection.Text = "Edgedetection";
            this.tab_Edgedetection.UseVisualStyleBackColor = true;
            // 
            // edgedetection_after
            // 
            this.edgedetection_after.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgedetection_after.Location = new System.Drawing.Point(363, 6);
            this.edgedetection_after.Name = "edgedetection_after";
            this.edgedetection_after.Size = new System.Drawing.Size(340, 368);
            this.edgedetection_after.TabIndex = 1;
            this.edgedetection_after.Paint += new System.Windows.Forms.PaintEventHandler(this.edgedetection_after_Paint);
            // 
            // edgedetection_before
            // 
            this.edgedetection_before.AllowDrop = true;
            this.edgedetection_before.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgedetection_before.Controls.Add(this.edgedetection_before_label);
            this.edgedetection_before.Location = new System.Drawing.Point(6, 6);
            this.edgedetection_before.Name = "edgedetection_before";
            this.edgedetection_before.Size = new System.Drawing.Size(340, 368);
            this.edgedetection_before.TabIndex = 0;
            this.edgedetection_before.Click += new System.EventHandler(this.edgedetection_before_Click);
            this.edgedetection_before.Paint += new System.Windows.Forms.PaintEventHandler(this.edgedetection_before_Paint);
            // 
            // edgedetection_before_label
            // 
            this.edgedetection_before_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.edgedetection_before_label.Location = new System.Drawing.Point(0, 0);
            this.edgedetection_before_label.Name = "edgedetection_before_label";
            this.edgedetection_before_label.Size = new System.Drawing.Size(338, 366);
            this.edgedetection_before_label.TabIndex = 0;
            this.edgedetection_before_label.Text = "Click to choose image";
            this.edgedetection_before_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edgedetection_before_label.Click += new System.EventHandler(this.edgedetection_before_Click);
            // 
            // tab_PixelPerfectCollision
            // 
            this.tab_PixelPerfectCollision.Controls.Add(this.pixelperfect_panel);
            this.tab_PixelPerfectCollision.Location = new System.Drawing.Point(4, 22);
            this.tab_PixelPerfectCollision.Name = "tab_PixelPerfectCollision";
            this.tab_PixelPerfectCollision.Size = new System.Drawing.Size(709, 380);
            this.tab_PixelPerfectCollision.TabIndex = 2;
            this.tab_PixelPerfectCollision.Text = "PixelPerfectCollision";
            this.tab_PixelPerfectCollision.UseVisualStyleBackColor = true;
            // 
            // pixelperfect_panel
            // 
            this.pixelperfect_panel.Location = new System.Drawing.Point(6, 6);
            this.pixelperfect_panel.Name = "pixelperfect_panel";
            this.pixelperfect_panel.Size = new System.Drawing.Size(697, 368);
            this.pixelperfect_panel.TabIndex = 0;
            this.pixelperfect_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.pixelperfect_panel_Paint);
            this.pixelperfect_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pixelperfect_panel_MouseMove);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 460);
            this.Controls.Add(this.checkBox_showNodes);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tab_Quadtree.ResumeLayout(false);
            this.tab_Edgedetection.ResumeLayout(false);
            this.edgedetection_before.ResumeLayout(false);
            this.tab_PixelPerfectCollision.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quadtree_insert;
        private System.Windows.Forms.Button quadtree_clear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Quadtree;
        private System.Windows.Forms.TabPage tab_Edgedetection;
        private System.Windows.Forms.Panel edgedetection_before;
        private System.Windows.Forms.Panel edgedetection_after;
        private System.Windows.Forms.Label edgedetection_before_label;
        private System.Windows.Forms.Panel panel_Quadtree;
        private System.Windows.Forms.TabPage tab_PixelPerfectCollision;
        private System.Windows.Forms.Panel pixelperfect_panel;
        private System.Windows.Forms.CheckBox checkBox_showNodes;
    }
}

