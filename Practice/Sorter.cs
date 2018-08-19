using System;
using System.Collections.Generic;

namespace Practice
{
    public static class Sorter
    {
        /*
         * Some well-known sorting algorithms:
         * 
         * Heapsort - build a heap out of the data. Repeatedly remove the max item and put it at the end
         *            (reducing the size of the 'heap' part of the array).
         *            n log n worst-case performance, constant memory, unstable.
         * 
         * Merge sort - divide-and-conquer on sub-arrays. Break array into arrays of size 1 and then slowly merge them.
         *              n log n worst-case time, n memory, stable.
         * 
         * Bubble sort - Loop through the list and swap adjacent items if they are out of order.
         *               n^2 time. Very easy to code. Stable.
         * 
         */

        public static List<int> Sort(IReadOnlyList<int> numbers)
        {
            throw new NotImplementedException();
        }
    }
}
