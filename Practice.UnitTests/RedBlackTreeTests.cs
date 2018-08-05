using System.Collections.Generic;

using NUnit.Framework;
using System.Linq;

namespace Practice.UnitTests
{
    [TestFixtureSource("TestCases")]
    public class RedBlackTreeTests
    {
        // TODO: Add some other test cases, probably rewrite as
        // a generator with a random seed so it stays the same
        // Pre-randomized list of integers from 1 through 50
        private readonly static List<int> Numbers = new List<int>
        {
            17, 8, 48, 46, 30, 31, 18, 33, 20, 22,
            34, 3, 50, 42, 27, 38, 9, 19, 35, 4,
            11, 37, 29, 14, 15, 24, 44, 7, 26, 1,
            43, 32, 13, 21, 16, 12, 5, 41, 6, 45,
            49, 47, 10, 2, 36, 23, 40, 28, 25, 39
        };

        static object[] TestCases = BuildTestCases();

        private RedBlackTree tree;

        private List<int> numbers;

        static object[] BuildTestCases()
        {
            var testCases = new List<object[]>();

            for (var i = 1; i < Numbers.Count; i++)
            {
                testCases.Add(new object[] { Numbers.Take(i).ToList() });
            }

            return testCases.ToArray<object>();
        }

        public RedBlackTreeTests(List<int> numbers)
        {
            this.numbers = numbers;
        }

        [SetUp]
        public void Setup()
        {
            tree = new RedBlackTree();

            foreach (var number in numbers)
            {
                tree.Insert(number);
            }
        }

        [Test]
        public void TraversalIsNumbersInOrder()
        {
            var results = new List<int>();

            tree.InOrderTraverse(n => results.Add(n.Value));

            Assert.AreEqual(numbers.Count, results.Count);

            for (var i = 1; i < numbers.Count; i++)
            {
                Assert.Greater(results[i], results[i - 1]);
            }
        }

        [Test]
        public void RedNodesHaveBlackChildren()
        {
            tree.InOrderTraverse(n =>
            {
                if (n.Color == RedBlackTree.Color.Red)
                {
                    Assert.AreEqual(RedBlackTree.Color.Black, n.LeftChild?.Color ?? RedBlackTree.Color.Black);
                    Assert.AreEqual(RedBlackTree.Color.Black, n.RightChild?.Color ?? RedBlackTree.Color.Black);

                }
            });
        }

        [Test]
        public void RootNodeIsBlack()
        {
            Assert.AreEqual(RedBlackTree.Color.Black, tree.Root.Color);
        }
        
        [Test]
        public void AllPathsHaveEqualBlackNodes()
        {
            var paths = GetPaths(tree);

            var blackNodeCount = BlackNodeCount(paths[0]);

            for (var i = 1; i < paths.Count; i++)
            {
                Assert.AreEqual(blackNodeCount, BlackNodeCount(paths[i]));
            }
        }

        private int BlackNodeCount(List<RedBlackTree.Node> path)
        {
            // Note that we count the 'null' child of the final node in the path as Black
            // even though path does not contain the 'null' reference.
            var count = 1;

            foreach (var node in path)
            {
                if (node.Color == RedBlackTree.Color.Black)
                {
                    count += 1;
                }
            }

            return count;
        }

        private List<List<RedBlackTree.Node>> GetPaths(RedBlackTree tree)
        {
            var paths = new List<List<RedBlackTree.Node>>();
            var ancestorsAndSelf = new Stack<RedBlackTree.Node>();

            if (tree.Root == null)
            {
                return paths;
            }

            ancestorsAndSelf.Push(tree.Root);
            BuildPaths(tree.Root, ancestorsAndSelf, paths);

            return paths;
        }

        private void BuildPaths(RedBlackTree.Node node, Stack<RedBlackTree.Node> ancestorsAndSelf, List<List<RedBlackTree.Node>> results)
        {
            if (node.LeftChild == null || node.RightChild == null)
            {
                results.Add(ancestorsAndSelf.ToList());
            }

            var children = new List<RedBlackTree.Node> { node.LeftChild, node.RightChild };
            children.RemoveAll(item => item == null);

            foreach (var child in children)
            {
                ancestorsAndSelf.Push(child);
                BuildPaths(child, ancestorsAndSelf, results);
                ancestorsAndSelf.Pop();
            }
        }
    }
}
