using System;

namespace Practice
{
    public class RedBlackTree
    {
        public Node Root { get; private set; }

        public void Insert(int value)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraverse(Action<Node> traversalAction)
        {
            throw new NotImplementedException();
        }

        public enum Color
        {
            Red,
            Black
        }

        public class Node
        {
            public Color Color { get; set; }

            public int Value { get; private set; }

            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }
        }
    }
}
