using System;
using System.Collections.Generic;

namespace Visual_path_finding.Library
{
    public class Node<T>
	{
		double? totalWeightFromSource;

		public int NodeID { get; set; }

		public T Tag { get; set; }

		/// <summary>
		/// The value that will be returned if the Property is null is 
		/// infinity (long.MaxValue).
		/// </summary>
		public double? TotalWeightFromSource 
		{ 
			get => ((totalWeightFromSource == null) || Obstacle) ? long.MaxValue : totalWeightFromSource;
			set => totalWeightFromSource = value;
		}

		public bool Obstacle { get; set; } = false; //If this property is true, then the weight property will return infinity.

		public bool Visited { get; set; } = false; //I could have had an array of visited nodes in the algorithm but encapsulating 
												//is more abstracted and makes the code easier to read and write and it's faster accessing a property rather than searching an array
												//anyway.

		public List<Edge> Edges { get; set; } = new List<Edge>();

		public int? PreviousNodeID { get; set; } //If it's null, it means that there is no path available to the starting node. 
	}
}
