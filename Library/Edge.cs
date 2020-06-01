using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_path_finding.Library
{
    public class Edge
    {
        //It technically doesn't matter whether a node is put as from or to.
        public int FromNodeID { get; set; }

        public int ToNodeID { get; set; }

        public double Weight { get; set; }

        /// <summary>
        /// This gets the node ID of the node attached to the specified node.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int GetNeighbourID(int ID)
        {
            if (this.FromNodeID == ID)
                return this.ToNodeID;
            else
                return this.FromNodeID;
        }

        public Edge(int startID, int finishID, double weight)
        {
            this.FromNodeID = startID;
            this.ToNodeID = finishID;
            this.Weight = weight;
        }
    }
}
