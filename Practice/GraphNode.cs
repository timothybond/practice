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
        
        public GraphNode BreadthFirstSearch(Action<GraphNode> onCheckNode, Func<GraphNode, bool> condition)
        {
            throw new NotImplementedException();
        }

        public GraphNode DepthFirstSearch(Action<GraphNode> onCheckNode, Func<GraphNode, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}
