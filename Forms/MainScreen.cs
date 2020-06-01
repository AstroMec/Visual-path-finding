using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_path_finding.Controls;
using Visual_path_finding.Forms;
using Visual_path_finding.Library;

namespace Visual_path_finding
{
    public partial class MainScreen : Form
    {
        public static Graph<WalkableSquare> graph; //This is the graph on which the path finding algorithm is performed. 

        List<ToolStripButton> actionGroup; //This is the action group (set obstacle, set source, ... etc.)

        public PathTable? PathTableResult { get; set; } = null;

        public Node<WalkableSquare>[] PathRestult { get; set; } = null;

        public static int? Source_nodeID { get; set; } = null;

        public static int? Target_nodeID { get; set; } = null;

        public static WalkableSquare[] WalkableSquares { get; set; }

        public static bool ObstacleChanged { get; set; } = false;

        public int? PreviousSource_nodeID { get; set; } = null; //This tracks whether the source has changed position.

        public MainScreen()
        {
            InitializeComponent();
            Program.GridSize.GridSizeChanged += On_Sizechanged;
            actionGroup = new List<ToolStripButton> { toolStripButton1, sourcePlacer, targetPlacer, setObstacle };
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoadGrid(30, 30); //The default grid size is 30 x 30
        }

        /// <summary>
        /// This is executed everytime the grid size is changed.
        /// </summary>
        /// <param name="sender">this</param>
        /// <param name="e">Leave empty (has no effect)</param>
        public void On_Sizechanged(object sender, EventArgs e)
        {
            LoadGrid(Program.grid_size.Width, Program.grid_size.Height);
        }

        public void LoadGrid(int x, int y)
        {
            this.grid_container.Controls.Clear();

            int horizontal_size = (int)Math.Floor((double)this.grid_container.Size.Width / x);
            int vertical_size = (int)Math.Floor((double)this.grid_container.Size.Width / y);

            if (x < 35)
                horizontal_size -= (int)(horizontal_size * 0.1);
            else if (x < 45)
                horizontal_size -= (int)(horizontal_size * 0.12);
            else if (x < 100)
                horizontal_size -= (int)(horizontal_size * 0.15);


            List<WalkableSquare> tags = new List<WalkableSquare>();


            #region Creating a graph
            Thread graphThread = new Thread(new ThreadStart(() =>
                {
                    List<Edge> edges = new List<Edge>();

                    foreach (WalkableSquare square in grid_container.Controls)
                    {
                        int[] lastOfRowID = Enumerable.Range(1, Program.grid_size.Height + 1).AsParallel().Select(n => (n * Program.grid_size.Width) - 1).ToArray();
                        int[] idList = Enumerable.Range(0, Program.grid_size.GetLast).ToArray();

                        if ((square.PosID == 0) || ((square.PosID + 1) % Program.grid_size.Width != 0))
                            //The above statement will evaluate if the square is the last square of the row.
                            edges.Add(new Edge(square.PosID, square.PosID + 1, 10));

                        if (idList.Contains(square.PosID + Program.grid_size.Width))
                            //The above statement will evaluate if this is the last row
                            //This portion takes care of viertical edges.
                            edges.Add(new Edge(square.PosID, square.PosID + Program.grid_size.Width, 10));

                        if ((!lastOfRowID.AsParallel().Select(n => n + 1).Contains(square.PosID + Program.grid_size.Width + 1)) && idList.Contains(square.PosID + Program.grid_size.Width + 1))
                        {
                            //This takes care of the right diagonal edge. 
                            //The above if statement means if the diagonal isn't the first one of the row (cause it's not a diagonal otherwise) and if it's a valid ID. 
                            double weight = Math.Sqrt(2 * Math.Pow(10, 2)); //Pythagoras because this is a diagonal weight. 
                            edges.Add(new Edge(square.PosID, square.PosID + Program.grid_size.Width + 1, weight));
                        }

                        if ((!lastOfRowID.Contains(square.PosID + Program.grid_size.Width - 1)) && idList.Contains(square.PosID + Program.grid_size.Width - 1))
                        {
                            //This takes care of the left diagonal eges
                            //The above if statement means if the diagonal isn't the last one of the row (cause it's not a diagonal otherwise) and if it's a valid ID.
                            double weight = Math.Sqrt(2 * Math.Pow(10, 2)); //Pythagoras because this is a diagonal weight.
                            edges.Add(new Edge(square.PosID, square.PosID + Program.grid_size.Width - 1, weight));
                        }
                    }

                    this.Invoke((MethodInvoker)(() => graph = new Graph<WalkableSquare>(edges.ToArray(), tags.ToArray())));

                    this.Invoke((MethodInvoker)(() => this.setGridSize.Enabled = true));
                    this.grid_container.Invoke((MethodInvoker)(() => this.grid_container.Cursor = Cursors.Default));
                }))
            { Priority = ThreadPriority.Highest };
            #endregion


            #region Resizing grid
            Thread gridThread = new Thread(new ThreadStart(() =>
                {
                    this.Invoke((MethodInvoker)(() => Target_nodeID = null));
                    this.Invoke((MethodInvoker)(() => Source_nodeID = null));

                    this.Invoke((MethodInvoker)(() => WalkableSquare.PreviousTarget = null));
                    this.Invoke((MethodInvoker)(() => WalkableSquare.PreviousSource = null));

                    this.grid_container.Invoke((MethodInvoker)(() => this.grid_container.Cursor = Cursors.WaitCursor));
                    this.Invoke((MethodInvoker)(() => this.setGridSize.Enabled = false));

                    for (int i = 1; i <= x * y; i++)
                    {
                        WalkableSquare square = new WalkableSquare()
                        {
                            Height = vertical_size,
                            Width = horizontal_size,
                            PosID = i - 1
                        };

                        this.grid_container.Invoke((MethodInvoker)(() => this.grid_container.Controls.Add(square)));
                        this.Invoke((MethodInvoker)(() => tags.Add(square)));
                    }

                    graphThread.Start();

                    this.Invoke((MethodInvoker)(() => WalkableSquares = tags.ToArray()));
                }))
            { Priority = ThreadPriority.Highest };
            #endregion

            gridThread.Start();

        }

        private void setGridSize_Click(object sender, EventArgs e)
        {
            new GridSize().Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            ChangeAction();

            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = CheckState.Checked;

            Program.selected_mode = Program.Modes.Normal;
        }

        private void sourcePlacer_Click(object sender, EventArgs e)
        {
            ChangeAction();

            sourcePlacer.Checked = true;
            sourcePlacer.CheckState = CheckState.Checked;

            Program.selected_mode = Program.Modes.Source;
        }



        private void targetPlacer_Click(object sender, EventArgs e)
        {
            ChangeAction();

            targetPlacer.Checked = true;
            targetPlacer.CheckState = CheckState.Checked;

            Program.selected_mode = Program.Modes.Target;
        }

        private void setObstacle_Click(object sender, EventArgs e)
        {
            ChangeAction();

            setObstacle.Checked = true;
            setObstacle.CheckState = CheckState.Checked;

            Program.selected_mode = Program.Modes.Obstacle;
        }

        /// <summary>
        /// This will change the selected action.
        /// </summary>
        private void ChangeAction()
        {
            foreach (var item in actionGroup.Where(item => item.Checked))
            {
                item.Checked = false;
                item.CheckState = CheckState.Unchecked;
            }
        }


        private void computePath_Click(object sender, EventArgs e)
        {

            if ((Source_nodeID != null) && (Target_nodeID != null))
            {
                //The above statement will evaluate if both the source and the target have been selected. 
                switch (this.setAlgorithm.Text)
                {
                    case "Dijkstra":
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            void ReCalculate()
                            {
                                ClearPath();
                                PathTableResult = null;
                                PathRestult = null;
                                graph.Reset(); //This resets the graph so that all the distances are infinity again.
                                PathTableResult = graph.Dijktra(graph.GetNode((int)Source_nodeID));
                                PathRestult = graph.GetShortestPath(graph.GetNode((int)Target_nodeID), (PathTable)PathTableResult);
                            }

                            void ClearPath()
                            {
                                try
                                {
                                    foreach (var node in PathRestult)
                                        //This will clear teh previous path.
                                        node.Tag.State = (node.Tag.State == WalkableSquare.States.Obstacle) ?
                                            node.Tag.State = WalkableSquare.States.Obstacle : WalkableSquare.States.Normal; //If the square state has been changed into an obstacle, 
                                                                                                                            //Then it should stay as an obstacle. 
                                }
                                catch
                                {
                                }
                            }
                            if (PathTableResult == null)
                            {
                                //If the path has never been calculated, I need to recalculate.
                                ReCalculate();
                            }
                            else if (ObstacleChanged)
                            {
                                //Becuase if the obstacle changed, we need to check if the paths calculated are still the shortest. 
                                ReCalculate();
                            }
                            else if (PreviousSource_nodeID != Source_nodeID)
                            {
                                //Likewise if the source node has changed, I need to recalculate.
                                ReCalculate();
                            }

                            else
                            {
                                ClearPath();

                                PathRestult = graph.GetShortestPath(graph.GetNode((int)Target_nodeID), (PathTable)PathTableResult);
                            }



                            foreach (var node in PathRestult)
                                //This will trace the path.
                                node.Tag.State = WalkableSquare.States.GoPath;

                            this.Cursor = Cursors.Default;

                            PreviousSource_nodeID = Source_nodeID;

                            MessageBox.Show("Success!");

                            break;
                        }
                        catch (ApplicationException)
                        {
                            MessageBox.Show("The target could not be reached! The way the obstacle was set up prevents the target from being reached.\n" +
                                "The grid will be refreshed.", "Error in path finding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetGrid();
                            break;
                        }
                        catch (NullReferenceException ex)
                        {
                            //This should theoretically never happen, but if it does, it is caught anyways.
                            //Previously I needed to have this error caught but I now don't have this error popping up anymore. 
                            MessageBox.Show($"Internal error occured!\n{ex.Message}",
                                "Internal Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            PathTableResult = null;
                            PathRestult = null;
                            break;
                        }

                    default:
                        //If no algorithm has been selected, th program will fall in this block.
                        MessageBox.Show("You must select an algorithm before starting!",
                            "Compute error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }

                ObstacleChanged = false; 
            }
            else
            {
                MessageBox.Show("You have not selected a a source and/or a target!", "Compute error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetGrid()
        {
            //This will clear everything and restart the program.
            this.Hide();
            new MainScreen().ShowDialog();
            this.Dispose();
        }
    }
}
