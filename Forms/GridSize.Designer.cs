namespace Visual_path_finding.Forms
{
    partial class GridSize
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
            this.label1 = new System.Windows.Forms.Label();
            this.grid_width = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.grid_height = new System.Windows.Forms.NumericUpDown();
            this.ok_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_height)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "X size:";
            // 
            // grid_width
            // 
            this.grid_width.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_width.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.grid_width.Location = new System.Drawing.Point(130, 39);
            this.grid_width.Name = "grid_width";
            this.grid_width.Size = new System.Drawing.Size(120, 44);
            this.grid_width.TabIndex = 1;
            this.grid_width.ThousandsSeparator = true;
            this.grid_width.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.grid_width.Validating += new System.ComponentModel.CancelEventHandler(this.grid_width_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y size:";
            // 
            // grid_height
            // 
            this.grid_height.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_height.Location = new System.Drawing.Point(131, 104);
            this.grid_height.Name = "grid_height";
            this.grid_height.Size = new System.Drawing.Size(120, 44);
            this.grid_height.TabIndex = 3;
            this.grid_height.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(149, 188);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(102, 36);
            this.ok_btn.TabIndex = 4;
            this.ok_btn.Text = "&Ok";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(257, 188);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(109, 36);
            this.cancel_btn.TabIndex = 5;
            this.cancel_btn.Text = "&Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // GridSize
            // 
            this.AcceptButton = this.ok_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(383, 237);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.grid_height);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grid_width);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GridSize";
            this.Text = "Set grid size";
            ((System.ComponentModel.ISupportInitialize)(this.grid_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown grid_width;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown grid_height;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}