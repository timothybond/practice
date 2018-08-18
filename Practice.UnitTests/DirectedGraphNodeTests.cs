using System;

using NUnit.Framework;
using System.Collections.Generic;

namespace Practice
{
    [TestFixture]
    public class DirectedGraphNodeTests
    {
        private Dictionary<string, DirectedGraphNode> graphNodes;

        [SetUp]
        public void CreateGraph()
        {
            /* a -> b[2], c[4]
             * b -> c[1], d[3]
             * c -> d[2]
             * d -> e[5], f[2], g[1]
             * e -> g[2], h[4]
             * f -> g[2], h[7], i[10]
             * g -> h[6], i[2]
             * h -> i[2], j[1]
             * i -> j[2]
             */

            var a = new DirectedGraphNode();
            var b = new DirectedGraphNode();
            var c = new DirectedGraphNode();
            var d = new DirectedGraphNode();
            var e = new DirectedGraphNode();
            var f = new DirectedGraphNode();
            var g = new DirectedGraphNode();
            var h = new DirectedGraphNode();
            var i = new DirectedGraphNode();
            var j = new DirectedGraphNode();
            var z = new DirectedGraphNode();

            a.AddLink(b, 2);
            a.AddLink(c, 4);
            b.AddLink(c, 1);
            b.AddLink(d, 3);
            c.AddLink(d, 2);
            d.AddLink(e, 5);
            d.AddLink(f, 2);
            d.AddLink(g, 1);
            e.AddLink(g, 2);
            e.AddLink(h, 4);
            f.AddLink(g, 2);
            f.AddLink(h, 7);
            f.AddLink(i, 10);
            g.AddLink(h, 6);
            g.AddLink(i, 2);
            h.AddLink(i, 2);
            h.AddLink(j, 1);
            i.AddLink(j, 2);

            graphNodes = new Dictionary<string, DirectedGraphNode>
            {
                {"a", a },
                {"b", b },
                {"c", c },
                {"d", d },
                {"e", e },
                {"f", f },
                {"g", g },
                {"h", h },
                {"i", i },
                {"j", j },
                {"z", z }
            };
        }

        [Test]
        public void GetShortestPath()
        {
            var a = graphNodes["a"];
            var j = graphNodes["j"];

            var shortestPath = a.GetShortestPath(j);

            Assert.AreEqual(10, shortestPath.TotalDistance);
        }

        [Test]
        public void GetShortestPathToUnreachableNode()
        {
            var a = graphNodes["a"];
            var z = graphNodes["z"];

            var shortestPath = a.GetShortestPath(z);

            Assert.IsNull(shortestPath);
        }
    }
}
