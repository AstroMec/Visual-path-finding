using iAssessement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_path_finding.Library
{
	public partial class Graph<T>
	{
		internal int noOfNodes; //This is used to build the graph. 


		public List<Node<T>> Nodes { get; set; }

		public List<Edge> Edges { get; set; }

		/// <summary>
		/// This property is used to build the graph. I don't wan't to allow changing it outside the Graph class.
		/// </summary>
		public int NoOfNodes
		{
			get
			{
				if (NoSet)
					return noOfNodes;
				else
				{
					foreach (Edge e in Edges)
					{
						//What this Basically does is that it iterates through the edges and 
						//It looks for the biggest ID because the IDs are in increasing order and incremental.
						if (e.ToNodeID > noOfNodes)
							noOfNodes = e.ToNodeID;
						if (e.FromNodeID > noOfNodes)
							noOfNodes = e.FromNodeID;
					}

					noOfNodes++; //Since IDs start at 0, the actual number is 1 greater so the property is incremented.
					
					NoSet = true; //Because this whole block should only run once.
					return noOfNodes;
				}
			}
			internal set => noOfNodes = value;
		}

		public Node<T> this[int nodeID]
		{
			get
			{
				return Nodes.Where(node => node.NodeID == nodeID).FirstOrDefault();
			}
		}


		internal bool NoSet { get; set; } = false;


		public Graph(Edge[] edges, T[] tags)
		{
			this.Edges = edges.ToList();
			this.NoOfNodes = NoOfNodes;

			this.Nodes = new List<Node<T>>();

			for (int i = 0; i < this.NoOfNodes; i++)
			{
				//The number of nodes is computed via the property and the nodes objects are created.
				this.Nodes.Add(new Node<T>() 
				{ 
					Tag = tags[i], 
					NodeID = i
				});
			}

			foreach (Edge edge in edges)
			{
				//Here I assume that the graph will be bi-directional.
				this[edge.FromNodeID].Edges.Add(edge);
				this[edge.ToNodeID].Edges.Add(edge);

			}

		}

		public Node<T> GetNode(int id)
		{
			return Nodes.AsParallel().Where(node => node.NodeID == id).FirstOrDefault(); //AsParallel runs the query on multiple threads.
		}

		public Node<T>[] ToArray()
		{
			return Nodes.ToArray();
		}

		/// <summary>
		/// This method is needed because the first step in Dijkstra's algorithm is to 
		/// set the distance to infinity and to have no node visited.
		/// </summary>
		public void Reset()
		{
			//Parallel runs the foreach loop on multiple threads.
			Parallel.ForEach(Nodes, i =>
			{
				ref var node = ref i;
				node.TotalWeightFromSource = long.MaxValue;
				node.Visited = false;
			});
		}
	}
}
