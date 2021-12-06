using System;

namespace Practice
{
    public class AvlTree
    {
        public Node? Root { get; private set; }

        public void Insert(int value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int value)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraverse(Action<Node> traversalAction)
        {
            throw new NotImplementedException();
        }
        
        public class Node
        {
            public int Value { get; private set; }

            public Node? LeftChild { get; set; }

            public Node? RightChild { get; set; }

            public int Height { get; }
        }
    }
}
