using NUnit.Framework;
using Restaurant365Test;

namespace Tests
{
    public class Tests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void NoDelimiter()
        {
            Assert.AreEqual(_calculator.Add("1\n2,3"), 6);
        }

        [Test]
        public void SingleOneCharDelim()
        {
            Assert.AreEqual(_calculator.Add("//[;]\n1;2;3;4;10000"), 10);
        }

        [Test]
        public void MultOneCharDelim()
        {
            Assert.AreEqual(_calculator.Add("//[;][*]\n1;2**3**4**10000"), 10);
        }

        [Test]
        public void SingleMultCharDelim()
        {
            Assert.AreEqual(_calculator.Add("//[**]\n1**2**3**4**10000"), 10);
        }

        [Test]
        public void MultMultCharDelim()
        {
            Assert.AreEqual(_calculator.Add("//[;;][**]\n1;;2**3**4**10000"), 10);
        }
    }
}