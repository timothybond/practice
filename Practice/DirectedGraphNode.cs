using System;
using System.Collections.Generic;

namespace Practice
{
    public class DirectedGraphNode
    {
        public Path ShortestPath { get; set; }

        public void AddLink(DirectedGraphNode target, int distance)
        {
            AddLink(new Link(target, distance));
        }

        public void AddLink(Link link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Uses A* algorithm to get the shortest path from this node to a target node.
        /// </summary>
        /// <param name="target">The destination node to reach.</param>
        /// <returns>The shortest path to the target node, or null if no path exists.</returns>
        public Path GetShortestPath(DirectedGraphNode target)
        {
            throw new NotImplementedException();
        }

        public class Link
        {
            public int Distance { get; private set; }

            public DirectedGraphNode Target { get; private set; }

            public Link(DirectedGraphNode target, int distance)
            {
                this.Target = target;
                this.Distance = distance;
            }
        }

        public class Path
        {
            private List<Link> links;

            public IReadOnlyList<Link> Links
            {
                get
                {
                    return links;
                }
            }

            public int TotalDistance { get; private set; }

            public void Add(Link link)
            {
                throw new NotImplementedException();
            }
        }
    }
}
