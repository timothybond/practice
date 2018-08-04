﻿using NUnit.Framework;

namespace Practice.UnitTests
{
    [TestFixture]
    public class MaxHeapTests
    {
        [Test]
        public void ReturnsItemsSorted()
        {
            var heap = new MaxHeap();

            heap.Insert(12);
            heap.Insert(99);
            heap.Insert(72);
            heap.Insert(5);
            heap.Insert(27);
            heap.Insert(2);
            heap.Insert(46);

            Assert.AreEqual(99, heap.GetMax());
            Assert.AreEqual(72, heap.GetMax());
            Assert.AreEqual(46, heap.GetMax());
            Assert.AreEqual(27, heap.GetMax());
            Assert.AreEqual(12, heap.GetMax());
            Assert.AreEqual(5, heap.GetMax());
            Assert.AreEqual(2, heap.GetMax());
        }
    }
}
