using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Practice.UnitTests
{
    [TestFixture]
    public class SorterTests
    {
        // Pre-randomized list of integers from 1 through 50
        private readonly static List<int> Numbers = new List<int>
        {
            17, 8, 48, 46, 30, 31, 18, 33, 20, 22,
            34, 3, 50, 42, 27, 38, 9, 19, 35, 4,
            11, 37, 29, 14, 15, 24, 44, 7, 26, 1,
            43, 32, 13, 21, 16, 12, 5, 41, 6, 45,
            49, 47, 10, 2, 36, 23, 40, 28, 25, 39
        };

        [Test]
        public void ReturnsNumbersInOrder()
        {
            var sortedNumbers = Sorter.Sort(Numbers);

            Assert.AreEqual(50, sortedNumbers.Count);

            for (var i = 0; i < sortedNumbers.Count; i++)
            {
                Assert.AreEqual(i + 1, sortedNumbers[i]);
            }
        }

        [Test]
        public void ReturnsScrambedNumbersInOrder()
        {
            const int TestCount = 100;
            var rand = new Random();

            for (var test = 0; test < TestCount; test++)
            {
                var scrambedNumbers = Numbers.OrderBy(n => rand.Next()).ToList();

                var sortedNumbers = Sorter.Sort(scrambedNumbers);

                Assert.AreEqual(50, sortedNumbers.Count);

                for (var i = 0; i < sortedNumbers.Count; i++)
                {
                    Assert.AreEqual(i + 1, sortedNumbers[i]);
                }
            }
        }
    }
}
