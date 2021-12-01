using System.Collections.Generic;

using NUnit.Framework;

namespace Practice.UnitTests
{
    [TestFixture]
    public class DirectedGraphNodeTests
    {
        private Dictionary<string, DirectedGraph.Node> graphNodes;

        private DirectedGraph graph;

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

            var a = new DirectedGraph.Node();
            var b = new DirectedGraph.Node();
            var c = new DirectedGraph.Node();
            var d = new DirectedGraph.Node();
            var e = new DirectedGraph.Node();
            var f = new DirectedGraph.Node();
            var g = new DirectedGraph.Node();
            var h = new DirectedGraph.Node();
            var i = new DirectedGraph.Node();
            var j = new DirectedGraph.Node();
            var z = new DirectedGraph.Node();

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

            graphNodes = new Dictionary<string, DirectedGraph.Node>
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

            graph = new DirectedGraph();

            graph.Nodes.AddRange(new[] { a, b, c, d, e, f, g, h, i, j, z });
        }

        [Test]
        public void GetShortestPath()
        {
            var a = graphNodes["a"];
            var j = graphNodes["j"];

            var shortestPath = graph.GetShortestPath(a, j);

            Assert.AreEqual(10, shortestPath.TotalDistance);
        }

        [Test]
        public void GetShortestPathToUnreachableNode()
        {
            var a = graphNodes["a"];
            var z = graphNodes["z"];

            var shortestPath = graph.GetShortestPath(a, z);

            Assert.IsNull(shortestPath);
        }
    }
}
