using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.UnitTests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(5, 4, 3, 2, 1)]
        [TestCase(5, 10, 15, 15, 20)]
        public void AddItems(params int[] entries)
        {
            var list = new LinkedList();

            foreach (var item in entries)
            {
                list.Add(item);
            }

            var listEntries = list.GetEntries();

            Assert.That(listEntries.Length == entries.Length);

            for (var i = 0; i < entries.Length; i++)
            {
                Assert.AreEqual(entries[i], listEntries[i]);
            }
        }

        [Test]
        public void RemoveFirst()
        {
            var list = new LinkedList();
            list.Add(15);
            list.Add(20);
            list.Add(25);
            list.Add(15);
            list.Add(30);

            list.RemoveFirst(15);

            var listEntries = list.GetEntries();

            Assert.That(listEntries.Length == 4);

            Assert.AreEqual(20, listEntries[0]);
            Assert.AreEqual(25, listEntries[1]);
            Assert.AreEqual(15, listEntries[2]);
            Assert.AreEqual(30, listEntries[3]);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(2, 4, 6, 8, 10, 12, 14, 16, 18, 20)]
        [TestCase(new int[] { })]
        public void Count(params int[] entries)
        {
            var list = new LinkedList();

            foreach (var entry in entries)
            {
                list.Add(entry);
            }

            Assert.AreEqual(entries.Length, list.Count);
        }

        [Test]
        public void RemoveFirstEntry()
        {
            var list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveFirst(1);
            
            var entries = list.GetEntries();
            Assert.AreEqual(4, entries.Length);

            Assert.AreEqual(2, entries[0]);
            Assert.AreEqual(3, entries[1]);
            Assert.AreEqual(4, entries[2]);
            Assert.AreEqual(5, entries[3]);
        }

        [Test]
        public void RemoveLastEntry()
        {
            var list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveFirst(5);

            var entries = list.GetEntries();
            Assert.AreEqual(4, entries.Length);

            Assert.AreEqual(1, entries[0]);
            Assert.AreEqual(2, entries[1]);
            Assert.AreEqual(3, entries[2]);
            Assert.AreEqual(4, entries[3]);
        }

        [Test]
        public void Insert()
        {
            var list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Insert(10, 3);

            var entries = list.GetEntries();
            Assert.AreEqual(6, entries.Length);

            Assert.AreEqual(1, entries[0]);
            Assert.AreEqual(2, entries[1]);
            Assert.AreEqual(3, entries[2]);
            Assert.AreEqual(10, entries[3]);
            Assert.AreEqual(4, entries[4]);
            Assert.AreEqual(5, entries[5]);
        }

        [Test]
        public void InsertAtZero()
        {
            var list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Insert(10, 0);

            var entries = list.GetEntries();
            Assert.AreEqual(6, entries.Length);

            Assert.AreEqual(10, entries[0]);
            Assert.AreEqual(1, entries[1]);
            Assert.AreEqual(2, entries[2]);
            Assert.AreEqual(3, entries[3]);
            Assert.AreEqual(4, entries[4]);
            Assert.AreEqual(5, entries[5]);
        }

        [Test]
        public void InsertAtCount()
        {
            var list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Insert(10, 5);

            var entries = list.GetEntries();
            Assert.AreEqual(6, entries.Length);

            Assert.AreEqual(1, entries[0]);
            Assert.AreEqual(2, entries[1]);
            Assert.AreEqual(3, entries[2]);
            Assert.AreEqual(4, entries[3]);
            Assert.AreEqual(5, entries[4]);
            Assert.AreEqual(10, entries[5]);
        }
    }
}
