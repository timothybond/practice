using System;
using System.Collections.Generic;

namespace Practice
{
    public class GraphNode
    {
        private readonly List<GraphNode> neighbors = new List<GraphNode>();

        public IReadOnlyList<GraphNode> Neighbors { get { return neighbors; } }

        public int Value { get; private set; }

        public GraphNode(int value)
        {
            this.Value = value;
        }

        public void AddNeighbor(GraphNode node)
        {
            if (this == node)
            {
                throw new ArgumentException("Cannot set node as its own neighbor.");
            }

            if (neighbors.Contains(node))
            {
                throw new ArgumentException("Neighbor relationship already exists.");
            }

            this.neighbors.Add(node);
            node.neighbors.Add(this);
        }

        /// <summary>
        /// Perform a breadth-first search for the node matching the given condition, starting here.
        /// </summary>
        /// <param name="condition">The condition to look for.</param>
        /// <returns>The node matching the condition, or <c>null</c> if none is found.</returns>
        public GraphNode? BreadthFirstSearch(Func<GraphNode, bool> condition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Perform a depth-first search for the node matching the given condition, starting here.
        /// </summary>
        /// <param name="condition">The condition to look for.</param>
        /// <returns>The node matching the condition, or <c>null</c> if none is found.</returns>
        public GraphNode? DepthFirstSearch(Func<GraphNode, bool> condition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Perform a bi-directional search to find the shortest path from
        /// this node to a target node.
        /// </summary>
        /// <param name="other">The target node to find a path to.</param>
        /// <param name="onCheckNode">A function that needs to be invoked
        /// whenever a node is checked by either side of the search.
        /// 
        /// Used for testing purposes to validate that the correct
        /// number of nodes get hit as part of the search.</param>
        /// <returns></returns>
        public IReadOnlyList<GraphNode>? BidirectionalSearch(GraphNode other, Action<GraphNode> onCheckNode)
        {
            throw new NotImplementedException();
        }
    }
}
