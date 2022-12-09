using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.UnitTests
{
    [TestFixture]
    public class HashtableTests
    {
        [Test]
        public void Set_ReturnedByGet()
        {
            var table = new Hashtable<string, int>();
            table["test1"] = 1;

            Assert.AreEqual(1, table["test1"]);
        }

        [Test]
        public void SetTwice_SecondValueReturnedByGet()
        {
            var table = new Hashtable<string, int>();
            table["test1"] = 1;
            table["test1"] = 5;

            Assert.AreEqual(5, table["test1"]);
        }

        [Test]
        public void ManySet_AllReturnedByGet()
        {
            // Should be enough to trigger rebuilding the buckets
            var table = new Hashtable<int, int>();

            for (var i = 0; i < 1000; i++)
            {
                table[i] = 1000 - i;
            }

            for (var i = 0; i < 1000; i++)
            {
                Assert.AreEqual(1000 - i, table[i]);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(27)]
        public void ManySet_CountIsCorrect(int number)
        {
            var table = new Hashtable<int, int>();

            for (var i = 0; i < number; i++)
            {
                table[i] = i;
            }

            Assert.AreEqual(number, table.Count);
        }

        [Test]
        public void Empty_CountIsZero()
        {
            var table = new Hashtable<string, int>();

            Assert.AreEqual(0, table.Count);
        }
    }
}
