using System;
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
          if(n >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }
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
        
            var afterDeleted = startIndex + length;
            
            if(afterDeleted > this.Length || startIndex > this.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
            char replacement = arr[afterDeleted];

            for (int i = startIndex; i < afterDeleted; i++)
            {
                arr[i] = replacement; 
                replacement = arr[i + 1];
                this.Length--;

            }
            
            if (arr[afterDeleted] != default(char))
            {
                for (int i = afterDeleted; i < this.Length; i++)
                {
                    arr[i] = default(char);
                }
            }
        }
        
        public override string ToString()
        {
            return new string(arr, 0, this.Length);
        }
    }
}
