using System;

namespace Practice
{
    public class MaxHeap
    {
        private static int capacity = 10;
        private int size = 0;

        int[] items = new int[capacity];

        private int GetLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int GetRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int GetParentIndex(int childIndex) { return 2 * (childIndex - 1) / 2; }

        private bool HasLeftChild(int index) { return GetLeftChildIndex(index) < size; }
        private bool HasRightChild(int index) { return GetRightChildIndex(index) < size; }
        private bool HasParent(int index) { return GetParentIndex(index) >= 0; }

        private int LeftChild(int index) { return items[GetLeftChildIndex(index)]; }
        private int RightChild(int index) { return items[GetRightChildIndex(index)]; }
        private int Parent(int index) { return items[GetParentIndex(index)]; }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if(size == capacity)
            {
                 Array.Resize<int>(ref items, capacity * 2);
                 capacity *= 2;
            }
        }

        public int Peek()
        {
            if (size == 0)
            {
                throw new Exception();
            }
            return items[0];
        }
        //public int poll()
        //{
        //    if(size == 0)
        //    {
        //        throw new Exception();
        //    }
        //    int item = items[0];
        //    items[0] = items[size - 1];
        //    size--;
        //    HeapifyDown();
        //    return item;
        //}
        //public void Add(int item)
        //{
        //    EnsureExtraCapacity();
        //    items[size] = item;
        //    size++;
        //    HeapifyUp();
        //}

        private void HeapifyUp()
        {
            int index = size - 1;
            while(HasParent(index) && Parent(index) < items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
        private void HeapifyDown()
        {
            int index = 0;
            //if there is no left child then there is no right child
            while(HasLeftChild(index))
            {
                int largerChildIndex = GetLeftChildIndex(index);
                if(HasRightChild(index) && RightChild(index) > LeftChild(index))
                {
                    largerChildIndex = GetRightChildIndex(index);
                }
                if(items[index] > items[largerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, largerChildIndex);
                }
                index = largerChildIndex;
            }
        }

        public int GetMax()
        {
            if (size == 0)
            {
                throw new Exception();
            }
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }

        public void Insert(int value)
        {
            EnsureExtraCapacity();
            items[size] = value;
            size++;
            HeapifyUp();
        }
    }
}
