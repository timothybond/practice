using System;

namespace Practice
{
   public class LinkedList
	{
		private class Node
		{
			public int count;

			public Node Next;

			public int Data;

            public Node(int data)
			{
				this.Data = data;
				this.Next = null;
			}
		}
		private Node head;
		public int count;

	}
}
