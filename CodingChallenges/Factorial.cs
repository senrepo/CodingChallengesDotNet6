using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    public class Factorial
    {
        private readonly int factorialNumber;

        public Factorial(int n)
        {
            this.factorialNumber = n;
        }

        public int Sum()
        {
            var sum = CalculateSum();
            return sum;
        }

        private int CalculateSum()
        {
            int sum = 0;
            if (factorialNumber == 0)
            {
                sum = 0;
            } 
            else
            {
                sum = 1;
                for(int i = factorialNumber; i >= 1; i--)
                {
                    sum = sum * i;
                }
            }
            return sum;

        }

        //private int CalculateSum()
        //{
        //    int sum = 0;
        //    if(factorialNumber ==0)
        //    {
        //        sum = 0;
        //    }
        //    if (factorialNumber == 1)
        //    {
        //        sum = 1;
        //    }

        //    return sum;
        //}

        public int RecursiveFactorial(int n)
        {
            if (n == 1) return 1;
            else return n * RecursiveFactorial(n - 1);
        }
    }
}
