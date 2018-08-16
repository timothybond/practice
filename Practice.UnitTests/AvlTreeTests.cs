using System;
using System.Collections.Generic;

using NUnit.Framework;
using System.Linq;

namespace Practice.UnitTests
{
    [TestFixtureSource("TestCases")]
    public class AvlTreeTests
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

        private AvlTree tree;

        private List<int> numbers;

        private List<int> numbersToDelete;

        static object[] BuildTestCases()
        {
            var testCases = new List<object[]>();

            for (var i = 1; i < Numbers.Count; i++)
            {
                for (var j = 0; j <= i; j++)
                { 
                    testCases.Add(new object[] { Numbers.Take(i).ToList(), Numbers.Take(j).ToList() });
                }
            }

            return testCases.ToArray<object>();
        }

        public AvlTreeTests(List<int> numbers, List<int> numbersToDelete)
        {
            this.numbers = numbers;
            this.numbersToDelete = numbersToDelete;
        }

        [SetUp]
        public void Setup()
        {
            tree = new AvlTree();

            foreach (var number in numbers)
            {
                tree.Insert(number);
            }

            foreach (var number in numbersToDelete)
            {
                tree.Delete(number);
            }
        }

        [Test]
        public void TraversalIsNumbersInOrder()
        {
            var results = new List<int>();

            tree.InOrderTraverse(n => results.Add(n.Value));

            Assert.AreEqual(numbers.Count - numbersToDelete.Count, results.Count);

            for (var i = 1; i < numbers.Count - numbersToDelete.Count; i++)
            {
                Assert.Greater(results[i], results[i - 1]);
            }
        }
        
        [Test]
        public void AllSubtreesAreWithinOneHeight()
        {
            tree.InOrderTraverse(n =>
            {
                if (Math.Abs(GetHeight(n.LeftChild) - GetHeight(n.RightChild)) > 1)
                {
                    Assert.Fail("Tree not balanced at node {0}.", n);
                }
            });
        }

        private int GetHeight(AvlTree.Node node)
        {
            if (node == null)
            {
                return 0;
            }
            
            return 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
        }
        
        private List<List<AvlTree.Node>> GetPaths(AvlTree tree)
        {
            var paths = new List<List<AvlTree.Node>>();
            var ancestorsAndSelf = new Stack<AvlTree.Node>();

            if (tree.Root == null)
            {
                return paths;
            }

            ancestorsAndSelf.Push(tree.Root);
            BuildPaths(tree.Root, ancestorsAndSelf, paths);

            return paths;
        }

        private void BuildPaths(AvlTree.Node node, Stack<AvlTree.Node> ancestorsAndSelf, List<List<AvlTree.Node>> results)
        {
            if (node.LeftChild == null || node.RightChild == null)
            {
                results.Add(ancestorsAndSelf.ToList());
            }

            var children = new List<AvlTree.Node> { node.LeftChild, node.RightChild };
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
