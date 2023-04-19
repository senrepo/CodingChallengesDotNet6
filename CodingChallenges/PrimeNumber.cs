using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    public class PrimeNumber
    {
        private readonly int sequenceCount;
        private List<int> sequence = new List<int>();

        public PrimeNumber(int n)
        {
            this.sequenceCount = n;
        }

        public List<int> GetSequence()
        {
            CalculateSequence();
            return sequence;
        }

        private void CalculateSequence()
        {
            int number = 0;
            while (sequence.Count < sequenceCount)
            {
                //call a method to check if the number is prime number
                //if prime number
                //  then add that number to squencelist
                //  else increment the number and continue the process

                var isPrimeNumber = CheckPrimeNumber(number);
                if(isPrimeNumber)
                {
                    sequence.Add(number);
                }
                number++;
            }
        }

        private bool CheckPrimeNumber(int number)
        {
            var isPrime = false;
            var remainderExecuted = false;
            if(number > 1)
            {
                isPrime = true;
                for (int i = 1; i <= number; i++)
                {
                    if(i != 1 && i != number)
                    {
                        var remainder = number % i;
                        if (remainder == 0) isPrime = false;
                        remainderExecuted = true;
                    }
                }

                if (!remainderExecuted) isPrime = true;
            }
            return isPrime;
        }

    }
}
