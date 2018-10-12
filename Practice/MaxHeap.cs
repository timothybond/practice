using System;

namespace Practice
{
	public class MaxHeap
	{
		private static int capacity = 10;
		private int size = 0;

		int[] items = new int[capacity];

		public int GetMax()
		{
			var max = Pop();
			return max;
		}


		public void Insert(int value)
		{
			EnsureExtraCapacity();
			items[size] = value;
			size++;
			HeapifyUp();
		}
		private void HeapifyUp()
		{
			var index = size - 1;

			while (HasParent() && items[index] > GetParent(index))
			{
				Swap(index, GetParentIndex(index));
				index = GetParentIndex(index);
			}
		}
		private void HeapifyDown()
		{
			var index = 0;
			while (HasLeftChild(index))
			{
				int largerChildIndex = GetLeftChildIndex(index);
				if (HasRightChild(index) && GetRight(index) > Getleft(index))
				{
					largerChildIndex = GetRightChildIndex(index);
				}
				if (items[largerChildIndex] > items[index])
				{
					Swap(largerChildIndex, index);
					break;
				}
				else
				{
					index = largerChildIndex;
				}

			}
		}

		private int Pop()
		{
			if (size != 0)
			{
				var max = items[0];
				items[0] = items[size - 1]; 
				size--;
				HeapifyDown();
				return max;
			}
			else
			{
				throw new Exception(message: "Heap is empty");
			}
		}
		private void EnsureExtraCapacity()
		{
			if (size == capacity)
			{
				Array.Copy(items, items, capacity * 2);
				capacity *= 2;
			}
		}



		private void Swap(int indexOne, int indexTwo)
		{
			var temp = items[indexTwo];
			items[indexTwo] = items[indexOne];
			items[indexOne] = temp;
		}

		public int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
		public int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
		public int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

		public bool HasLeftChild(int index) => GetLeftChildIndex(index) < size;
		public bool HasRightChild(int index) => GetRightChildIndex(index) < size;
		public bool HasParent() => size > 1;

		public int Getleft(int index) => items[GetLeftChildIndex(index)];
		public int GetRight(int index) => items[GetRightChildIndex(index)];
		public int GetParent(int index) => items[GetParentIndex(index)];
	}
}
    
