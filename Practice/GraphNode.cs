using System;
using System.Collections.Generic;

namespace Practice
{
    public class GraphNode
    {
        private readonly List<GraphNode> neighbors = new List<GraphNode>();

        public IReadOnlyList<GraphNode> Neighbors { get { return neighbors; } }

        public bool Marked { get; set; }

        public int Value { get; private set; }

        public GraphNode(int value)
        {
            this.Marked = false; // Explicit default for clarity
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
        
        public GraphNode BreadthFirstSearch(Action<GraphNode> markNode, Func<GraphNode, bool> condition)
        {
            throw new NotImplementedException();
        }

        public GraphNode DepthFirstSearch(Action<GraphNode> markNode, Func<GraphNode, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}
