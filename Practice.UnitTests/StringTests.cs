using NUnit.Framework;
using System;
namespace Practice.UnitTests
{
    [TestFixture()]
    public class StringTests
    {
        [TestCase(2, 'r')]
        public void Insert(int num, char c)
        {
            var sb = new StringBuilder();
            sb.Append('c');
            sb.Append('h');
            sb.Append('o');
            sb.Insert(num, c);
            Assert.AreEqual('r', sb[2]);
        }
        [TestCase(2, 'e')]
        public void InsertOverCapacity(int num, char c)
        {
            var sb = new StringBuilder();
            sb.Append('c');
            sb.Append('h');
            sb.Append('o');
            sb.Append('r');
            sb.Append('e');
            sb.Append('s');
            sb.Append('a');
            sb.Append('b');
            sb.Append('o');
            sb.Append('r');
            sb.Insert(num, c);
            Assert.AreEqual('e', sb[2]);
            Assert.AreEqual('r', sb[10]);
        }
        [TestCase('j')]
        public void AppendToEmpty(char c)
        {
            var sb = new StringBuilder();
            sb.Append(c);
            Assert.AreEqual(c, sb[0]);
        }
        [TestCase('j')]
        public void Append(char c)
        {
            var sb = new StringBuilder();
            sb.Append('o');
            sb.Append(c);
            Assert.AreEqual(c, sb[1]);
        }
        [Test]
        public void ToStringReturnsString()
        {
            var sb = new StringBuilder();
             sb.Append('c');
            sb.Append('h');
            sb.Append('o');
            sb.Append('r');
            sb.Append('e');
            var s = sb.ToString();
            Assert.AreEqual("chore", s);
        }
    }
}
