using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_path_finding.Properties;
using System.Windows.Forms.VisualStyles;

namespace Visual_path_finding.Controls
{
    public partial class WalkableSquare : UserControl
    {
        public static event EventHandler ColourChanged;
        private static Dictionary<Colours, Color> colorMap;


        States state = States.Normal;
        Colours colour = Colours.Normal;


        public static int? PreviousTarget { get; set; } = null;

        public static int? PreviousSource { get; set; } = null;

        public int PosID { get; set; } //This will store the corresponding node ID. 

        /// <summary>
        /// If this property is set, then the colour of the square sould be set. 
        /// It describes what the square is i.e.: path, obstacle or nothing.
        /// In future updates it will also show the a* computing live so there will be additional states.
        /// </summary>
        public States State
        {
            get => state;

            set
            {
                state = value;

                switch (state)
                {
                    case States.Normal:
                        Colour = Colours.Normal;
                        break;
                    case States.GoPath:
                        Colour = Colours.Red;
                        break;

                    case States.Obstacle:
                        MainScreen.ObstacleChanged = true;
                        Colour = Colours.Black;
                        break;
                }
            }
        }

        public Colours Colour
        {
            get => colour;

            set
            {
                colour = value;
                ColourChanged(this, EventArgs.Empty);
            }
        }

        public WalkableSquare()
        {
            InitializeComponent();

            ColourChanged += OnColourChanged;

            colorMap = (new (Colours, Color)[]
            { (Colours.Red, Color.Red), (Colours.Black, Color.Black), (Colours.Normal, Color.White) })
            .ToDictionary(kv => kv.Item1, kv => kv.Item2); //This maps the colour enum to the actual colour.
        }

        /// <summary>
        /// This will change the colour of the square.It runs whenever the state of the square has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnColourChanged(object sender, EventArgs e)
        {
            this.BackColor = colorMap[Colour];
        }

        private void WalkableSquare_Click(object sender, EventArgs e)
        {
            switch (Program.selected_mode)
            {
                case Program.Modes.Source:
                    if (PreviousSource != null)
                        MainScreen.WalkableSquares[(int)PreviousSource]
                            .pictureBox1.Visible = false;

                    PreviousSource = PosID;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Resources.source;
                    MainScreen.Source_nodeID = this.PosID;
                    break;

                case Program.Modes.Target:
                    if (PreviousTarget != null)
                        MainScreen.WalkableSquares[(int)PreviousTarget]
                            .pictureBox1.Visible = false;

                    PreviousTarget = PosID;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Resources.target;
                    MainScreen.Target_nodeID = this.PosID;
                    break;

                case Program.Modes.Obstacle:
                    MainScreen.graph[PosID].Obstacle = true;
                    this.State = States.Obstacle;
                    //Because PosID is the node ID. 
                    break;
            }
        }

        /// <summary>
        /// These are the available states.
        /// </summary>
        public enum States
        {
            Normal,
            Obstacle,
            PathFinding,
            GoPath
        }

        public enum Colours
        {
            Red,
            Black,
            Normal
        }
    }
}
