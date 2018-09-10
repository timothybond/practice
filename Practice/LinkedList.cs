﻿using System;
using System.Collections.Generic;

namespace Practice
{
    public class LinkedList
    {
        public int Count => CountList();

        private Node Head;
        /// <summary>
        /// Adds a new Node at the front of the list.
        /// </summary>
        /// <param name="value">Value.</param>
        public void AddFront(int value)
        {
            var node = new Node(value)
            {
                Next = Head,
                Previous = null
                    
            };

            if(Head != null)
            {
                Head.Previous = node;
            }

            Head = node;

        }
        public void Add(int value)
        {
            var node = new Node(value);

            var currentNode = Head;

            if (Head == null)
            {
                Head = node;
                return;
            }
            while(currentNode != null)
            {
                if(currentNode.Next == null)
                {
                    currentNode.Next = node;
                    node.Previous = currentNode;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }
        /// <summary>
        /// Inserts a new Node after the given index.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="index">Index.</param>
        public void InsertAfter(int value, int index)
        {
            var node = new Node(value);
            Node current = Head;
            if (index <= Count)
            {
                for (int i = 0; i <= index; i++)
                {
                    if(i == index)
                    {
                        node.Next = current.Next;
                        node.Previous = current;
                        current.Next.Previous = node;
                        current.Next = node;

                    }
                    current = current.Next;
                }
            }

        }
        public void Insert(int value, int index)
        {
            var node = new Node(value);
            Node current = Head;
            if (index <= Count)
            {
                for (int i = 0; i <= index; i++)
                {
                    if(index == 0)
                    {
                        node.Next = Head;
                        Head.Previous = node;
                        Head = node;
                    }
                    if (i == index - 1)
                    {
                        node.Next = current.Next;
                        node.Previous = current;
                        if(current.Next != null)
                        {
                            current.Next.Previous = node; 
                        }

                        current.Next = node;
                    }
                    current = current.Next;
                }
            }

        }

        public void Remove(int value)
        {
            var current = Head;

            while (current != null)
            {
                if (value == current.Data)
                {
                    if(current.Previous == null)
                    {
                        current.Next.Previous = null;
                        Head = current.Next;
                        return;
                    }
                    else if (current.Next == null)
                    {
                        current.Previous.Next = null;
                        return;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        return;
                    }

                }
                current = current.Next;
            }
        }

        public int[] GetEntries()
        {
            int[] array = new int[Count];
            Node node = Head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Data;

                if(node.Next != null)
                {
                    node = node.Next;
                }
            }
            return array;
        }
        public int CountList()
        {
            var n = Head;
            var count = 0;

            while (n != null)
            {
                count++;
                n = n.Next;
            }
            return count;
        }

        public void Delete(int d)
        {
            Node n = this.Head;

            if (n.Data == d)
            {
                this.Head = this.Head.Next;
            }

            while (n.Next != null)
            {
                if (n.Next.Data == d)
                {
                    n.Next = n.Next.Next;
                }
                n = n.Next;
            }
        }

        public Node RemoveDuplicateNodes()
        {
            var set = new HashSet<int>
            {
                this.Head.Data
            };

            Node node = this.Head;

            while (node.Next != null)
            {
                if (set.Contains(node.Next.Data))
                {
                    node.Next = node.Next.Next;
                }
                else
                {
                    set.Add(node.Data);
                }
                if (node.Next != null)
                {
                    node = node.Next;
                }

            }
            return this.Head; 
        }
    }

    public class Node
    {
        public Node Next;

        public Node Previous;

        public int Data;

        public Node()
        {

        }
        public Node(int data)
        {
            this.Data = data;
        }
    }
}
