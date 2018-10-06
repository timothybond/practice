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
				var next = this.head.Next;

				if (this.head.Next != null)
				{
					next.Previous = null;
				}
				this.head = next;

				return;
			}
			for (var current = this.head; current != null; current = current.Next)
            {
				if (current.Data == value)
				{
					current.Previous.Next = current.Next;

                    if(current.Previous.Next != null)
					{
						current.Previous.Next.Previous = current.Previous;
					}
					return;
				}
			}

		}

        public int[] GetEntries()
        {
			var index = 0;
            var entries = new int[Count];

			for (var current = this.head; current != null; current = current.Next)
            {
                entries[index] = current.Data;
				index++;
            }
            return entries;
        }
    }
}
