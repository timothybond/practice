using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
            private Dictionary<Node, Link> _linksByTarget = new();

            public IReadOnlyList<Link> Links => _links;

            public IReadOnlyDictionary<Node, Link> LinksByTarget => _linksByTarget;

            public void AddLink(Node target, int distance)
            {
                var link = new Link(target, distance);
                _links.Add(link);
                _linksByTarget.Add(target, link);
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
                _links.Add(link);

                TotalDistance += link.Distance;
            }

            public void AddRange(IEnumerable<Link> links)
            {
                _links.AddRange(links);

                TotalDistance = _links.Sum(l => l.Distance);
            }
        }
    }
}
