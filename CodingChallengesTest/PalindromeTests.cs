using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class PalindromeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /* Requirement
         * A palindromic number is a number (in some base ) that is the same when written forwards or backwards
         * 
         * Examples
         * f(1) = 0
         * f(2) = 0,1
         * f(3) = 0,1,2
         * f(5) = 0,1,2,3,4
         * f(10) = 0,1,2..9
         * f(11) = 0,1,2,3,4,5,6,7,8,9,11
         * f(12) = 0,1,2,3,4,5,6,7,8,9,22
         * f(13) = 0,1,2,3,4,5,6,7,8,9,22,33
         */

        [Test]
        public void TestPolindromeWith1()
        {
            //Arrange
            var factorial = new Palindrome(1);

            //Act
            var sequence = factorial.GetSequence();

            //Assert
            Assert.AreEqual(1, sequence.Count, "sequece count");
            Assert.AreEqual(0, sequence[0], "sequence value");
        }

        [Test]
        //[TestCase(2, "0,1")]
        //[TestCase(5, "0,1,2,3,4")]
        //[TestCase(10, "0,1,2,3,4,5,6,7,8,9")]
        [TestCase(11, "0,1,2,3,4,5,6,7,8,9,11")]
        [TestCase(12, "0,1,2,3,4,5,6,7,8,9,11,22")]
        [TestCase(13, "0,1,2,3,4,5,6,7,8,9,11,22,33")]
        public void TestPolindromeWithN(int n, string expected)
        {
            var factorial = new Palindrome(n);
            var outputSequence = expected.Split(",").ToList();

            var sequence = factorial.GetSequence();

            Assert.AreEqual(n, sequence.Count, "sequece count not matched");
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(Convert.ToInt32(outputSequence[i]), sequence[i], $"sequence[{i}] value not matched");
            }
        }

    }
}
