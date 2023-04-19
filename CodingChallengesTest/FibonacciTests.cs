namespace CodingChallengesTest
{
    [TestFixture]
    public class FibonacciTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFibonacciWith0()
        {
            var fibonacci = new Fibonacci(0);
            var sequence = fibonacci.GetSequence(); //0

            Assert.AreEqual(1, sequence.Count);
            Assert.AreEqual(0,sequence[0]);
        }

        [Test]
        public void TestFibonacciWith1()
        {
            var fibonacci = new Fibonacci(1);
            var sequence = fibonacci.GetSequence(); //0,1

            Assert.AreEqual(2, sequence.Count);
            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
        }

        [Test]
        public void TestFibonacciWith2()
        {
            var fibonacci = new Fibonacci(2);
            var sequence = fibonacci.GetSequence(); //0,1,1

            Assert.AreEqual(3, sequence.Count);
            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
        }

        [Test]
        public void TestFibonacciWith3()
        {
            var fibonacci = new Fibonacci(3);
            var sequence = fibonacci.GetSequence(); //0,1,1,2

            Assert.AreEqual(4, sequence.Count);
            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
        }

        [Test]
        public void TestFibonacciWith4()
        {
            var fibonacci = new Fibonacci(4);
            var sequence = fibonacci.GetSequence(); //0,1,1,2,3

            Assert.AreEqual(5,sequence.Count);
            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
        }

        [Test]
        public void TestFibonacciWith7()
        {
            var fibonacci = new Fibonacci(7);
            var sequence = fibonacci.GetSequence(); //0,1,1,2,3,5,8,13

            Assert.AreEqual(8, sequence.Count);
            Assert.AreEqual(13, sequence[7]);
        }
    }
}