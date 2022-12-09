using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice
{
    public class LinkedList<T> : IEnumerable<T> where T : notnull
    {
        public int Count { get; }

        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public void Insert(T value, int index)
        {
            throw new NotImplementedException();
        }

        
        public bool RemoveFirst(T value)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFirst(Predicate<T> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
