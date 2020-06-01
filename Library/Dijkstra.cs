using iAssessement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_path_finding.Library
{
    public partial class Graph<T>
    {
        private delegate double ComputeWeight();



        #region Helper methods for Dijkstra's
        /// <summary>
        /// NodeShortestDistanced will get the next node that is not visited.
        /// </summary>
        public int NodeShortestDistanced
        {
            get
            {
                int storedNodeIndex = 0;
                double storedDistance = long.MaxValue;

                for (int i = 0; i < this.Nodes.Count; i++)
                {
                    double currentDistance = (double)this.Nodes[i].TotalWeightFromSource;

                    if (!this.Nodes[i].Visited && currentDistance < storedDistance)
                    {
                        storedDistance = currentDistance;
                        storedNodeIndex = i;
                    }
                }

                return storedNodeIndex;
            }
        }

        /// <summary>
        /// The below method will update the distance from the starting node. The approach I chose to go with is
        /// to encapsulate the distance from the starting node in the nodes objects. 
        /// </summary>
        /// <param name="startNodeID">The starting node.</param>
        public void calculateShortestDistances(int startNodeID)
        {
            this[startNodeID].TotalWeightFromSource = 0; //This will set the distance from the 
                                                         //start node to the start node to 0 
            this[startNodeID].PreviousNodeID = startNodeID;

            int nextNode = startNodeID; //This will fetch the index of the start node.

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                //These two nested loops will travese the graph.
                List<Edge> currentNodeEdges = this.Nodes[nextNode].Edges;

                for (int joinedEdge = 0; joinedEdge < currentNodeEdges.Count; joinedEdge++)
                {
                    int neighbourID = currentNodeEdges[joinedEdge].GetNeighbourID(nextNode);

                    //Only if not visited
                    if (!this.Nodes[neighbourID].Visited)
                    {
                        double tentative = (double)(this.Nodes[nextNode].TotalWeightFromSource + currentNodeEdges[joinedEdge].Weight);

                        if (tentative < Nodes[neighbourID].TotalWeightFromSource)
                        {
                            Nodes[neighbourID].TotalWeightFromSource = tentative;
                            Nodes[neighbourID].PreviousNodeID = nextNode;
                        }
                    }
                }

                //All neighbours checked so visited.
                Nodes[nextNode].Visited = true;
                nextNode = NodeShortestDistanced; //The property returns the shortest distance.
            }
        }
        #endregion

        /// <summary>
        /// This will run the famous Dijkstra's algorithm. 
        /// This algorithm computes the shortest path from the starting node to every other node
        /// in a graph. 
        /// </summary>
        /// <param name="startNode">The starting node.</param>
        /// <returns>It will return a table with the shortest path to every other node and the weight from 
        /// the starting node.
        /// </returns>
        public PathTable Dijktra(Node<T> startNode)
        {
            this.calculateShortestDistances(startNode.NodeID);

            try
            {
                PathTable toRet = new PathTable()
                {
                    PathTableRows = Nodes.Select(node => new PathTableRow()
                    {
                        DestinationNodeID = node.NodeID,
                        TotalWeight = node.TotalWeightFromSource,
                        PreviousNodeID = node.PreviousNodeID
                    }).ToArray()
                };
                
                return toRet;
            }
            catch (InvalidOperationException)
            {
                throw new NullReferenceException();
            }

            
        }

        public Node<T>[] GetShortestPath(Node<T> startNode, Node<T> endNode)
        {
            PathTable pathTable = Dijktra(startNode);
            return GetShortestPath(endNode, pathTable);
        }

        /// <summary>
        /// This decodes the table returned by Dijkstra's to return the shortest path.
        /// </summary>
        /// <param name="endNode">The target node.</param>
        /// <param name="pathTable">The table returned by the algorithm.</param>
        /// <returns>It returns the path as an array.</returns>
        public Node<T>[] GetShortestPath(Node<T> endNode, PathTable pathTable)
        {
            List<Node<T>> pathToRetrun = new List<Node<T>>();

            PathTableRow currentRow = pathTable[endNode.NodeID];
            pathToRetrun.Add(GetNode(currentRow.DestinationNodeID));

            try
            {
                while (!currentRow.Equals(pathTable.PathTableRows.AsParallel().Where(r => r.TotalWeight == 0).First()))
                {
                    //The query in the Equals statement fetched the row of the starting node. 
                    //Because where the start node has a distance 0 from the starting node (obviously).
                    pathToRetrun.Insert(0, GetNode((int)currentRow.PreviousNodeID));
                    currentRow = pathTable[(int)currentRow.PreviousNodeID];
                }

                return pathToRetrun.ToArray();
            }
            catch (InvalidOperationException)
            {
                //Because if there is no valid path, an invalid operation exeption will be thrown. 
                //(Due to the previous node ID being null. 
                throw new ApplicationException();
            }
        }


    }

    public struct PathTableRow
    {
        public int DestinationNodeID { get; set; }

        public double? TotalWeight { get; set; }

        public int? PreviousNodeID { get; set; } //The reason this is allowed to be null is that some nodes may never be able to reach
                                                //the source and this might cause this value to be none.

    }

    /// <summary>
    /// This is the table that is returned by Dijkstra's algorithm.
    /// </summary>
    public struct PathTable
    {
        public PathTableRow[] PathTableRows { get; set; }

        /// <summary>
        /// This will return the row that describes the node ID input.
        /// </summary>
        /// <param name="nodeID"></param>
        /// <returns>It returns a row object.</returns>
        public PathTableRow this[int nodeID]
        {
            get
            {
                return PathTableRows.Where(row => row.DestinationNodeID == nodeID).FirstOrDefault();
            }

            set
            {
                PathTableRows[PyFunct.PyEnumerate(PathTableRows)
                    .Where(row => row.Item2.DestinationNodeID == nodeID)
                    .Select(enumPair => enumPair.Item1).First()]
                = value;
            }
        }
    }
}
