using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    public class Palindrome
    {
        private readonly int sequenceCount;
        private readonly List<int> sequence;
        public Palindrome(int n)
        {
            sequenceCount = n - 1;
            sequence = new List<int>();
        }

        //public List<int> GetSequence()
        //{
        //    CalculateSequence();
        //    return sequence;
        //}

        public List<int> GetSequence()
        {
            CalculateSequence();
            return sequence;
        }


        public void CalculateSequence()
        {
            for (int i = 0, countIndex=0; countIndex <= sequenceCount; i++)
            {
               if(i<=9)
                {
                    sequence.Add(i);
                    countIndex++;
                }
                else
                {
                    if (i == Reverse(i))
                    {
                        sequence.Add(i);
                        countIndex++;
                    }
                }
            }
        }

        public int Reverse(int number)
        {
            var resultBuilder = new StringBuilder();
            var reverseNumber = number.ToString().Reverse().ToList();

            foreach(var digit in reverseNumber)
            {
                resultBuilder.Append(digit.ToString());
            }

            var result = Convert.ToInt32(resultBuilder.ToString());
            return result;
            
        }

        //public void CalculateSequence()
        //{
        //    if (sequenceCount == 0)
        //    {
        //        sequence.Add(0);
        //    }
        //}
    }
}
