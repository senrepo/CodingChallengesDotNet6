namespace CodingChallenges
{
    public class Fibonacci
    {
        private int sequenceCount { get; set; }
        private List<int> sequence = new List<int>();
        public Fibonacci(int n)
        {
            this.sequenceCount = n;
        }

        public List<int> GetSequence()
        {
            //0, 1, 1, 2
            var i = 0;
            while(i<= sequenceCount)
            {
                sequence.Add(calculateSequence(i));
                i++;
            }
          
            return sequence;
        }

        private int calculateSequence(int index)
        {
            int val = 0;

            if (index == 0)
            {
                val = 0;
            }
            if (index == 1)
            {
                val = 1;
            }
            if (index >=2)
            {
                var item = sequence[index - 2] + sequence[index - 1];
                val = item;
            }
            return val;
        }

        //private void calculateSequence()
        //{

        //    if(sequenceCount == 0)
        //    {
        //        sequence.Add(0);
        //    }
        //    if (sequenceCount == 1)
        //    {
        //        sequence.Add(0);
        //        sequence.Add(1);
        //    }
        //    if (sequenceCount == 2)
        //    {
        //        sequence.Add(0);
        //        sequence.Add(1);

        //        var item3 = sequence[sequenceCount - 2] + sequence[sequenceCount - 1];
        //        sequence.Add(item3);
        //    }

        //}
    }
}