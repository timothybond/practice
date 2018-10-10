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

		public int Count { get; private set; }

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

			if (this.head == null)
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
			var match = true;

			if (this.head == null)
			{
				return;
			}
			if (this.head.Data == data)
			{
				if (next == null)
				{
					this.head = null;
				}
				else
				{
					next.Previous = null;
					this.head = next;
				}
			}
			else
			{
				for (var current = next; current != null; current = current.Next)
				{
					if (current.Data == data)
					{
						current.Previous.Next = current.Next;
						
                        if (current == this.tail)
						{
							this.tail = this.tail.Previous;
							this.tail.Next = null;
						}
						break;
					}
					else if (current.Next == null)
					{
						match = false;
					}
				}
			}
			if (match)
			{
				this.Count--;
				return;
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

					for (int i = 1; i == index -1; i++)
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
