using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class FactorialTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*  Requirement  f(n) = f(n) * f(n-1) * f(n-2)...f(1)
            Examples
                f(0) = 0
                f(1) = 1
                f(2) = 2 = 2 * 1
                f(3) = 6 = 3 * 2 * 1
                f(4) = 24 = 4 * 3 * 2 * 1
        */

        [Test]
        public void TestFactorialWith0()
        {
            //Arrange
            var factorial = new Factorial(0);

            //Act
            var sum = factorial.Sum();

            //Assert
            Assert.AreEqual(0, sum);
        }

        [Test]
        public void TestFactorialWith1()
        {
            //Arrange
            var factorial = new Factorial(1);

            //Act
            var sum = factorial.Sum();

            //Assert
            Assert.AreEqual(1, sum);
        }
        [Test]
        public void TestFactorialWith2()
        {
            //Arrange
            var factorial = new Factorial(2);

            //Act
            var sum = factorial.Sum();

            //Assert
            Assert.AreEqual(2, sum);
        }
        [Test]
        public void TestFactorialWith3()
        {
            //Arrange
            var factorial = new Factorial(3);

            //Act
            var sum = factorial.Sum();

            //Assert
            Assert.AreEqual(6, sum);
        }
        [Test]
        public void TestFactorialWith4()
        {
            //Arrange
            var factorial = new Factorial(4);

            //Act
            var sum = factorial.Sum();

            //Assert
            Assert.AreEqual(24, sum);
        }
        [Test]
        public void TestFactorialWith10()
        {
            //Arrange
            var factorial = new Factorial(10);

            //Act
            var sum = factorial.Sum();

            //Assert
            Assert.AreEqual(3628800, sum);
        }
    }
}
