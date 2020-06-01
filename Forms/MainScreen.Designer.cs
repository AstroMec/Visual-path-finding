namespace Visual_path_finding
{
    partial class MainScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.setAlgorithm = new System.Windows.Forms.ToolStripComboBox();
            this.setGridSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.sourcePlacer = new System.Windows.Forms.ToolStripButton();
            this.targetPlacer = new System.Windows.Forms.ToolStripButton();
            this.setObstacle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.computePath = new System.Windows.Forms.ToolStripLabel();
            this.grid_container = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1642, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAlgorithm,
            this.setGridSize,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.sourcePlacer,
            this.targetPlacer,
            this.setObstacle,
            this.toolStripSeparator2,
            this.computePath});
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1642, 42);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // setAlgorithm
            // 
            this.setAlgorithm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.setAlgorithm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.setAlgorithm.Items.AddRange(new object[] {
            "Dijkstra"});
            this.setAlgorithm.Name = "setAlgorithm";
            this.setAlgorithm.Size = new System.Drawing.Size(121, 42);
            this.setAlgorithm.ToolTipText = "Choose algorithm";
            // 
            // setGridSize
            // 
            this.setGridSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setGridSize.Image = global::Visual_path_finding.Properties.Resources.Grid_icon;
            this.setGridSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setGridSize.Name = "setGridSize";
            this.setGridSize.Size = new System.Drawing.Size(46, 36);
            this.setGridSize.Text = "Set grid size";
            this.setGridSize.ToolTipText = "Set grid size";
            this.setGridSize.Click += new System.EventHandler(this.setGridSize_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Visual_path_finding.Properties.Resources.Default_cursor;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 36);
            this.toolStripButton1.Text = "Cursor";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // sourcePlacer
            // 
            this.sourcePlacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sourcePlacer.Image = global::Visual_path_finding.Properties.Resources.source;
            this.sourcePlacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sourcePlacer.Name = "sourcePlacer";
            this.sourcePlacer.Size = new System.Drawing.Size(46, 36);
            this.sourcePlacer.Text = "Place source";
            this.sourcePlacer.Click += new System.EventHandler(this.sourcePlacer_Click);
            // 
            // targetPlacer
            // 
            this.targetPlacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.targetPlacer.Image = global::Visual_path_finding.Properties.Resources.target;
            this.targetPlacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.targetPlacer.Name = "targetPlacer";
            this.targetPlacer.Size = new System.Drawing.Size(46, 36);
            this.targetPlacer.Text = "Place target";
            this.targetPlacer.Click += new System.EventHandler(this.targetPlacer_Click);
            // 
            // setObstacle
            // 
            this.setObstacle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setObstacle.Image = global::Visual_path_finding.Properties.Resources.Obstacle;
            this.setObstacle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setObstacle.Name = "setObstacle";
            this.setObstacle.Size = new System.Drawing.Size(46, 36);
            this.setObstacle.Text = "Set obstacle (Cannot be undone!)";
            this.setObstacle.Click += new System.EventHandler(this.setObstacle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // computePath
            // 
            this.computePath.IsLink = true;
            this.computePath.LinkColor = System.Drawing.SystemColors.ControlText;
            this.computePath.Name = "computePath";
            this.computePath.Size = new System.Drawing.Size(52, 36);
            this.computePath.Text = "Go!";
            this.computePath.ToolTipText = "Compute the shortest path with the selected algorithm";
            this.computePath.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.computePath.Click += new System.EventHandler(this.computePath_Click);
            // 
            // grid_container
            // 
            this.grid_container.AutoScroll = true;
            this.grid_container.BackColor = System.Drawing.Color.White;
            this.grid_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_container.Location = new System.Drawing.Point(0, 82);
            this.grid_container.Margin = new System.Windows.Forms.Padding(0);
            this.grid_container.Name = "grid_container";
            this.grid_container.Size = new System.Drawing.Size(1642, 916);
            this.grid_container.TabIndex = 2;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1642, 998);
            this.Controls.Add(this.grid_container);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "Path finding visualizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox setAlgorithm;
        private System.Windows.Forms.ToolStripButton setGridSize;
        private System.Windows.Forms.FlowLayoutPanel grid_container;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton sourcePlacer;
        private System.Windows.Forms.ToolStripButton targetPlacer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel computePath;
        private System.Windows.Forms.ToolStripButton setObstacle;
    }
}

