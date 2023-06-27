using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{

    public class EventsAndDelegatesTests
    {
        private delegate int Calculator(int x, int y);
        private event Calculator? CalculateEvent;

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        [Test]
        public void TestDelegates()
        {
            Calculator calc1 = new Calculator(Add);
            int result1 = calc1(5, 5);
            Console.WriteLine(result1);

            calc1 = new Calculator(Multiply);
            result1 = calc1(5, 5);
            Console.WriteLine(result1);


            //Multicase delete
            Calculator calc2 = new Calculator(Add);
            calc2 += Multiply;

            var result2 = calc2(10, 20);
            Console.WriteLine(result2);

            //anonymous delegate
            Calculator calc3 = new Calculator(delegate (int x, int y)
            {
                return x / y;
            });

            int result3 = calc3(25, 5);
            Console.WriteLine(result3);

        }

        [Test]
        public void TestEvent()
        {
            CalculateEvent += Add;
            CalculateEvent += Multiply;

            var resutl = CalculateEvent.Invoke(10, 20);
            Console.WriteLine(resutl);
        }
    }
}
