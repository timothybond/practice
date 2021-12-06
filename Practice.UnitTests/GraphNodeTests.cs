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
            },
            n => false);

            Assert.That(allNodes.All(n => n.Marked));
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
            },
            n => n.Value == 3);

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
            },
            n => false);

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
            },
            n => false);

            Assert.That(allNodes.All(n => n.Marked));
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
            },
            n => n.Value == 11);

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
            },
            n => false);

            Assert.That(searchedNodes[0].Value == 0);

            for (int i = 1; i < 5; i++)
            {
                Assert.That(searchedNodes[i * 2 - 1].Value > 0 && searchedNodes[i * 2 - 1].Value <= 5);
                Assert.That(searchedNodes[i * 2].Value > 10 && searchedNodes[i * 2].Value <= 15);
            }
        }
    }
}
