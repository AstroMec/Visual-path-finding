using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_path_finding.Library;

namespace Visual_path_finding
{
    static class Program
    {
        public static GridSize grid_size;
        public static Modes selected_mode;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            grid_size = new GridSize(30, 30);
            selected_mode = Modes.Normal;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }

        public class GridSize
        {
            internal int width;
            internal int height;

            public int Width 
            { 
                get => width;

                set
                {
                    width = value;
                }
            }

            public int Height 
            { 
                get => height; 

                set 
                {
                    height = value;
                }
            }

            public int GetLast { get => Height * Width; }

            public static event EventHandler GridSizeChanged;

            public GridSize()
            {
            }

            public GridSize(int x, int y)
            {
                width = x;
                height = y;
            }

            public static void UpdateSize(object sender, EventArgs e)
            {
                GridSizeChanged(sender, e);
            }
        }

        public enum Modes
        {
            //This will be used to track what tool has been selected.
            Normal,
            Obstacle,
            Target,
            Source,
            Start
        }
    }
}
