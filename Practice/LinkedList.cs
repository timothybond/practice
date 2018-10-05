using System;

namespace Practice
{
    public class LinkedList
    {
		public class DoublyLinkedNode
        {
            public DoublyLinkedNode Previous;

            public DoublyLinkedNode Next;

            public int Data;
         
            public DoublyLinkedNode(int data)
            {
                this.Data = data;
            }
        }
        private DoublyLinkedNode head;
        private DoublyLinkedNode tail;

        public int Count
        {
            get
            {
				var count = 0;

				for (var current = this.head; current != null; current = current.Next)
                {
                    count++;
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
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }
     
        }

        public void Insert(int value, int index)
        {
            var node = new DoublyLinkedNode(value);
           

            if(index == 0)
			{
                node.Next = this.head;
                this.head = node;
                return;
            }
            if(index == this.Count)
            {
                Add(value);
                return;
            }

			var current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
			var before = current.Previous;
            before.Next = node;
            node.Previous = before;
            node.Next = current;
            current.Previous = node;
           
        }

		public void RemoveFirst(int value)
		{
			if (this.head.Data == value)
			{
				//if (this.head.Next != null)
				//{
				var next = this.head.Next;
				if (this.head.Next != null)
				{
					next.Previous = null;
				}
				this.head = next;
				//  }
				//  else
				//  {
				//     this.head = null;
				//  }
				return;
			}
			var current = this.head;

			while (current != null)
			{
				if (current.Data == value)
				{
					current.Previous.Next = current.Next;
				}
				current = current.Next;
			}

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
