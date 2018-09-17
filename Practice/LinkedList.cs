using System;

namespace Practice
{
    public class LinkedList
    {
        private DoublyLinkedNode head;
        private DoublyLinkedNode tail;

        public int Count
        {
            get
            {
                var current = this.head;
                var count = 0;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public void Add(int value)
        {
            var node = new DoublyLinkedNode(value);

            if(head == null)
            {
                head = node;
                tail = head;
                return;
            }
            if (tail != null)
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }
            //var current = this.head;

            //while(current != null)
            //{
            //    if(current.Next == null)
            //    {
            //        current.Next = node;
            //        node.Previous = current;
            //        return;
            //    }
            //    current = current.Next;

            //}
        }

        public void Insert(int value, int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirst(int value)
        {
            throw new NotImplementedException();
        }

        public int[] GetEntries()
        {
            var current = this.head;
            var entries = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                entries[i] = current.Data;
                current = current.Next;
            }
            return entries;
        }
    }
}
