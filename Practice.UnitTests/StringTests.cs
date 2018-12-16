using NUnit.Framework;
using System;
namespace Practice.UnitTests
{
    [TestFixture()]
    public class StringTests
    {
        [TestCase("thisIsAString")]
        [TestCase("soIsThis")]
        public void StringConstructor(string s)
        {
            var sb = new StringBuilder(s);
            Assert.AreEqual(sb.ToString(), s);
        }
       
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
        [TestCase(4, 'r')]
        public void InsertGreaterThanLength(int num, char c)
        {
            var sb = new StringBuilder();
            sb.Append('c');
            sb.Append('h');
            sb.Append('o');
            Assert.Throws<IndexOutOfRangeException>(() => sb.Insert(num, c));
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
        [TestCase("AppendOver",'j')]
        public void AppendOverCapacity(string s, char c)
        {
            var sb = new StringBuilder();
            sb.Append(c);
            Assert.AreEqual(c, sb[0]);
        }

        [Test]
        public void ToStringReturnsEmptyString()
        {
            var sb = new StringBuilder();
            var s = sb.ToString();
            Assert.AreEqual("", s);
        }
        [TestCase(2, 3, 's')]
        [TestCase(2, 2, 'e')]
        public void RemoveCharacters(int index, int length, char ans)
        {
            var sb = new StringBuilder();
            var initialLength = 6;
            sb.Append('c');
            sb.Append('h');
            sb.Append('o');
            sb.Append('r');
            sb.Append('e');
            sb.Append('s');
            sb.Remove(index, length);
            Assert.AreEqual(ans, sb[index]);
            Assert.AreEqual(initialLength - length, sb.Length);
        }
        [TestCase(5, 1, 'e', "chores")]
        public void RemoveLastCharacter(int index, int length, char ans, string s)
        {
            var sb = new StringBuilder(s);
            var initialLength = 6;
            sb.Remove(index, length);
            Assert.AreEqual(ans, sb[4]);
            Assert.AreEqual(initialLength - length, sb.Length);
        }
        [TestCase(2, 9)]
        public void RemoveLengthGreaterThrowsException(int index, int length)
        {
            var sb = new StringBuilder();
            sb.Append('c');
            sb.Append('h');
            sb.Append('o');
            sb.Append('r');
            sb.Append('e');
            sb.Append('s');
            
           Assert.Throws<IndexOutOfRangeException>(() => sb.Remove(index, length));
           
        }
    }
}
