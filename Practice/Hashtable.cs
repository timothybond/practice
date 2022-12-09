using System;
using System.Collections.Generic;

namespace Practice
{
    public class Hashtable<TKey, TValue> where TKey: notnull
    {
        public int Count { get; private set; }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
