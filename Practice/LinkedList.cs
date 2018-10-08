using System;

namespace Practice
{
   public class LinkedList
	{
		private class Node
		{         
			public Node Next;

			public Node Previous;

			public int Data;

            public Node(int data)
			{
				this.Data = data;
				this.Next = null;
			}
		}
		private Node head;
		private Node tail;

		public int Count { get; set; }

		public int[] GetEntries()
		{
			var entries = new int[Count];
			var index = 0;

			for (var current = this.head; current != null; current = current.Next)
			{
				entries[index] = current.Data;
				index++;
			}
			return entries;
		}

        public void Add(int data)
		{
			var node = new Node(data);
                     
			if(this.head == null)
			{
				this.head = node;
				this.tail = node;
			}         
			else
			{
				this.tail.Next = node;
				node.Previous = tail;
				this.tail = node;            
			}  
			this.Count++;
		}

        public void RemoveFirst(int data)
		{  
			Node next = this.head?.Next;

			if (this.head.Data == data)
			{
				if (this.head.Next == null)
				{
					this.head = null;
					this.Count--;
					return;
				}
				next.Previous = null;
				this.head = next;
				this.Count--;
				return;
			}         
            
			for (var current = next; current != null; current = current.Next)
			{
				if (current.Data == data)
				{
					if (current == this.tail)
					{
						this.tail = this.tail.Previous;
                        this.tail.Next = null;
					}
					else
					{
						current.Previous.Next = current.Next;
					}

					this.Count--;
					return;
				}
			}
		}

        public void Insert(int data, int index)
		{
			if (index == this.Count)
			{
				Add(data);
				return;
			}

			if (index < this.Count)
            {
                var node = new Node(data);

                if (index == 0)
                {
                    node.Next = this.head;
                    this.head = node;
                }

                else
                {
                    var current = this.tail;

                    for (int i = this.Count; i != index; i--)
                    {
						current = current.Previous;
                    }
					var before = current;
					node.Previous = before;
					node.Next = current.Next;               
					before.Next.Next.Previous = node;
					before.Next = node;
                }
				this.Count++;
			}         
   
		}      
	}
}
