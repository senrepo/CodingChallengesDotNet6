using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class PrimeNumberTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /* Requirement
         * a whole number greater than 1 that cannot be exactly divided by any whole number other than itself and 1 
         * Examples 2, 3, 5, 7, 11
         * 
         * f(1) = 2
         * f(2) = 2,3
         * f(3) = 2, 3, 5
         * f(4) = 2, 3, 5, 7
         * f(5) = 2, 3, 5, 7, 11
         * f(100) = 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
         */

        [Test]
        public void TestPrimeNumberWithN1()
        {
            var primeNumber = new PrimeNumber(1);
            var list = primeNumber.GetSequence();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(2, list[0]);
        }

        [Test]
        public void TestPrimeNumberWithN2()
        {
            var primeNumber = new PrimeNumber(2);
            var list = primeNumber.GetSequence();

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [Test]
        public void TestPrimeNumberWithN3()
        {
            var primeNumber = new PrimeNumber(3);
            var list = primeNumber.GetSequence();

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(5, list[2]);
        }

        [Test]
        [TestCase(5, 11)]
        [TestCase(6, 13)]
        [TestCase(7, 17)]
        [TestCase(8, 19)]
        public void TestPrimeNumberWithN(int n, int expected)
        {
            var primeNumber = new PrimeNumber(n);
            var list = primeNumber.GetSequence();

            Assert.AreEqual(n, list.Count);
            Assert.AreEqual(expected, list[n-1]);

        }

    }
}
