using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_path_finding.Library;

namespace Visual_path_finding.Forms
{
    public partial class GridSize : Form
    {
        public GridSize()
        {
            InitializeComponent();
            this.grid_width.Value = Program.grid_size.Width;
            this.grid_height.Value = Program.grid_size.Height;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Program.grid_size = new Program.GridSize() 
            { 
                Width = (int)this.grid_width.Value, 
                Height = (int)this.grid_height.Value 
            };

            Program.GridSize.UpdateSize(this, EventArgs.Empty);
            this.Hide();
        }

        private void grid_width_Validating(object sender, CancelEventArgs e)
        {
            if (this.grid_width.Value % 5 != 0)
            {
                MessageBox.Show("The grid width must be a multiple of 5!", "Grid size error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.grid_width.Value = 50;
                e.Cancel = true;
            }
        }
    }
}
