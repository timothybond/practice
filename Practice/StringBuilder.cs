using System;
using System.Text;
namespace Practice
{
    public class StringBuilder
    {
        private static int capacity = 10;
        private char[] arr = new char[capacity];
        
        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }
        public char this [int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
        public int Length 
        {
            get;
            private set;
            
        }
        public StringBuilder()
        {
            
        }
        public void Append(char c)
        {
            CheckCapacity();
            arr[this.Length] = c;

            this.Length++;
        }

        private void CheckCapacity()
        {
            if (this.Length > this.Capacity)
            {
                this.Capacity *= 2;
                Array.Resize(ref arr, this.Capacity);

            }
        }
        private void CheckCapacity(int index)
        {
            if (index >= this.Capacity)
            {
                this.Capacity *= 2;
                Array.Resize(ref arr, this.Capacity);

            }
        }

        public void Insert(int n, char c)
        {
            char temp;
            char replacement = c;
            for (int j = n; j <= this.Length; j++)
            {
                CheckCapacity(j);
                temp = arr[j];
                arr[j] = replacement;
                replacement = temp;
            }
            this.Length++;
        }
        public void Remove(int startIndex, int length)
        {
            //TODO:Do.
            this.Length--;
        }
        public override string ToString()
        {
            //why is arr.Length changing?
            return new string(arr, 0, this.Length);
        }
    }
}
