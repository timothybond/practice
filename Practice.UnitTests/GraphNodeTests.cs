using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Practice;

namespace Practice.UnitTests
{
    [TestFixture]
    public class BreadthFirstSearch
    {
        // Note temporary values are for nullability
        private GraphNode root = new(0);

        private List<GraphNode> searchedNodes = new(); 

        private List<GraphNode> allNodes = new();

        [SetUp]
        public void Setup()
        {
            allNodes = new List<GraphNode>();

            // Creates a graph with node 0 in the center,
            // nodes 1-5 surrounding node 0, and nodes 11-15
            // each connected to node [n-10].
            root = new GraphNode(0);
            allNodes.Add(root);
            
            for (int i = 1; i <= 5; i++)
            {
                var innerNode = new GraphNode(i);
                var outerNode = new GraphNode(i + 10);
                innerNode.AddNeighbor(outerNode);
                root.AddNeighbor(innerNode);

                allNodes.Add(innerNode);
                allNodes.Add(outerNode);
            }

            // Used to store the order in which nodes were searched
            searchedNodes = new List<GraphNode>();
        }

        [Test]
        public void SearchesAllNodesIfNoMatchIsFound()
        {
            root.BreadthFirstSearch(n =>
            {
                searchedNodes.Add(n);
                return false;
            });

            Assert.That(allNodes.All(n => searchedNodes.Contains(n)));
            Assert.AreEqual(searchedNodes.Count, 11);

            foreach (var node in allNodes)
            {
                Assert.That(searchedNodes.Contains(node));
            }
        }

        [Test]
        public void StopsSearchOnMatchingNode()
        {
            root.BreadthFirstSearch(n =>
            {
                searchedNodes.Add(n);
                return n.Value == 3;
            });

            Assert.That(searchedNodes.Count == 4);
            
            for (int i = 0; i <= 3; i++)
            {
                Assert.That(searchedNodes[i].Value == i);
            }
        }

        [Test]
        public void SearchesNeighborsFirst()
        {
            root.BreadthFirstSearch(n =>
            {
                searchedNodes.Add(n);
                return false;
            });

            Assert.That(searchedNodes[0].Value == 0);
            
            for (int i = 1; i < 5; i++)
            {
                Assert.That(searchedNodes[i].Value > 0 && searchedNodes[i].Value <= 5);
                Assert.That(searchedNodes[i + 5].Value > 10 && searchedNodes[i + 5].Value <= 15);
            }
        }
    }

    [TestFixture]
    public class DepthFirstSearch
    {
        // Note temporary values are for nullability
        private GraphNode root = new(0);

        private List<GraphNode> searchedNodes = new();

        private List<GraphNode> allNodes = new();

        [SetUp]
        public void Setup()
        {
            allNodes = new List<GraphNode>();

            // Creates a graph with node 0 in the center,
            // nodes 1-5 surrounding node 0, and nodes 11-15
            // each connected to node [n-10].
            root = new GraphNode(0);
            allNodes.Add(root);

            for (int i = 1; i <= 5; i++)
            {
                var innerNode = new GraphNode(i);
                var outerNode = new GraphNode(i + 10);
                innerNode.AddNeighbor(outerNode);
                root.AddNeighbor(innerNode);

                allNodes.Add(innerNode);
                allNodes.Add(outerNode);
            }

            // Used to store the order in which nodes were searched
            searchedNodes = new List<GraphNode>();
        }

        [Test]
        public void SearchesAllNodesIfNoMatchIsFound()
        {
            root.DepthFirstSearch(n =>
            {
                searchedNodes.Add(n);
                return false;
            });

            Assert.That(allNodes.All(n => searchedNodes.Contains(n)));
            Assert.AreEqual(searchedNodes.Count, 11);

            foreach (var node in allNodes)
            {
                Assert.That(searchedNodes.Contains(node));
            }
        }

        [Test]
        public void StopsSearchOnMatchingNode()
        {
            root.DepthFirstSearch(n =>
            {
                searchedNodes.Add(n);
                return n.Value == 11;
            });

            Assert.That(searchedNodes.Count == 3);

            Assert.That(searchedNodes[0].Value == 0);
            Assert.That(searchedNodes[1].Value == 1);
            Assert.That(searchedNodes[2].Value == 11);
        }

        [Test]
        public void SearchesToEdgeFirst()
        {
            root.DepthFirstSearch(n =>
            {
                searchedNodes.Add(n);
                return false;
            });

            Assert.That(searchedNodes[0].Value == 0);

            for (int i = 1; i < 5; i++)
            {
                Assert.That(searchedNodes[i * 2 - 1].Value > 0 && searchedNodes[i * 2 - 1].Value <= 5);
                Assert.That(searchedNodes[i * 2].Value > 10 && searchedNodes[i * 2].Value <= 15);
            }
        }
    }

    [TestFixture]
    public class BidirectionalGraphSearch
    {
        [Test]
        public void FindsShortestPath()
        {
            /* 
             *  1  2  3  4  5
             *  6  7  8  9 10
             * 11 12 13 14 15
             */
            var nodes = BuildGrid(3, 5);
            var checkedNodes = new List<GraphNode>();

            var path = nodes[7].BidirectionalSearch(nodes[9], node => checkedNodes.Add(node))!;

            Assert.AreEqual(3, path.Count);

            Assert.AreEqual(7, path[0].Value);

            // Technically there are several options here since we can move diagonally
            Assert.Contains(path[0], path[1].Neighbors.ToList());
            Assert.Contains(path[2], path[1].Neighbors.ToList());
            
            Assert.AreEqual(9, path[2].Value);
        }

        [Test]
        public void ChecksFewerNodes()
        {
            /* 
             *  1  2  3  4  5  6  7
             *  8  9 10 11 12 13 14
             * 15 16 17 18 19 20 21
             * 22 23 24 25 26 27 28
             * 29 30 31 32 33 34 35
             * 36 37 38 39 40 41 42
             * 43 44 45 46 47 48 49
             */
            var nodes = BuildGrid(20, 20);
            var checkedNodes = new List<GraphNode>();

            var path = nodes[207].BidirectionalSearch(nodes[213], node => checkedNodes.Add(node))!;

            Assert.AreEqual(7, path.Count);

            Assert.AreEqual(207, path[0].Value);

            // Technically there are several options here since we can move diagonally
            Assert.Contains(path[0], path[1].Neighbors.ToList());
            Assert.Contains(path[2], path[1].Neighbors.ToList());
            
            Assert.Contains(path[1], path[2].Neighbors.ToList());
            Assert.Contains(path[3], path[2].Neighbors.ToList());

            Assert.Contains(path[2], path[3].Neighbors.ToList());
            Assert.Contains(path[4], path[3].Neighbors.ToList());

            Assert.Contains(path[3], path[4].Neighbors.ToList());
            Assert.Contains(path[5], path[4].Neighbors.ToList());

            Assert.Contains(path[4], path[5].Neighbors.ToList());
            Assert.Contains(path[6], path[5].Neighbors.ToList());

            Assert.AreEqual(213, path[6].Value);

            // A single breadth-first graph search would check
            // at least 121 nodes to find this path, since first
            // we would have to check an 11x11 block around 207
            // (i.e. including 202 through 212), then at least one more.
            //
            // Bidirectionally we should max out at two 7x7 blocks.
            Assert.LessOrEqual(checkedNodes.Count, 98);
        }

        [Test]
        public void HandlesSelfSearch()
        {
            var nodes = BuildGrid(20, 20);
            var checkedNodes = new List<GraphNode>();

            var path = nodes[205].BidirectionalSearch(nodes[205], node => checkedNodes.Add(node))!;

            Assert.AreEqual(1, path.Count);
            Assert.AreSame(nodes[205], path[0]);
        }

        [Test]
        public void ReturnsNullForFailedSearch()
        {
            /*
             * 1 - 2 - 3   5 - 6
             *     |
             *     4
             * 
             * 
             */
            var nodes = new Dictionary<int, GraphNode>();
            for (var i = 1; i <= 6; i++)
            {
                nodes.Add(i, new GraphNode(i));
            }

            nodes[1].AddNeighbor(nodes[2]);
            nodes[2].AddNeighbor(nodes[3]);
            nodes[2].AddNeighbor(nodes[4]);

            nodes[5].AddNeighbor(nodes[6]);

            var path = nodes[2].BidirectionalSearch(nodes[6], n => { });

            Assert.IsNull(path);
        }

        private Dictionary<int, GraphNode> BuildGrid(int rows, int columns)
        {
            /* For comprehensibility, this builds a graph that's really just a grid, e.g.:
             * 
             *  1  2  3  4  5
             *  6  7  8  9 10
             * 11 12 13 14 15
             * 
             * Each node is connected to the left/right/above/below one (if any), and diagonals.
             */
            var nodes = new Dictionary<int, GraphNode>();

            for (var i = 1; i <= rows * columns; i++)
            {
                nodes.Add(i, new GraphNode(i));
            }

            for (var i = 1; i <= rows * columns; i++)
            {
                var below = i <= columns * (rows - 1);
                var left = i % columns != 1;
                var right = i % columns != 0;

                if (below)
                {
                    nodes[i].AddNeighbor(nodes[i + columns]);
                }

                if (left)
                {
                    nodes[i].AddNeighbor(nodes[i - 1]);
                }

                if (below && left)
                {
                    nodes[i].AddNeighbor(nodes[i - 1 + columns]);
                }

                if (below && right)
                {
                    nodes[i].AddNeighbor(nodes[i + 1 + columns]);
                }
            }

            return nodes;
        }
    }
}
