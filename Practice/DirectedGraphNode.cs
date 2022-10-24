using System;
using System.Collections.Generic;

namespace Practice
{
    public class DirectedGraph
    {
        public List<Node> Nodes { get; private set; }

        public DirectedGraph()
        {
            this.Nodes = new List<Node>();
        }

        /// <summary>
        /// Uses Dijkstra's algorithm to get the shortest path from one node to another.
        /// </summary>
        /// <param name="target">The destination node to reach.</param>
        /// <returns>The shortest path to the target node, or null if no path exists.</returns>
        public Path? GetShortestPath(Node startNode, Node destinationNode)
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            private List<Link> _links = new();

            public IReadOnlyList<Link> Links => _links;

            public void AddLink(Node target, int distance)
            {
                _links.Add(new Link(target, distance));
            }
        }

        public class Link
        {
            public int Distance { get; private set; }

            public Node Target { get; private set; }

            public Link(Node target, int distance)
            {
                this.Target = target;
                this.Distance = distance;
            }
        }

        public class Path
        {
            private readonly List<Link> _links = new();

            public IReadOnlyList<Link> Links => _links;

            public int TotalDistance { get; private set; }

            public void Add(Link link)
            {
                throw new NotImplementedException();
            }
        }
    }
}
