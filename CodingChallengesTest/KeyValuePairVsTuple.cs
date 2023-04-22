using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class KeyValuePairVsTuple
    {

        [Test]
        public void TestKeyValuePair()
        {
            // KeyValuePair is readonly and its a value type, stored in stack memory, and memory efficient
            // commonly used for 
            //  iterate the dictionary object
            //  return more than only value from a function

            //iterate the dictionary
            var animals = new Dictionary<string, int>()
            {
                { "cat", 2 }, { "dog", 1 }
            };

            foreach (KeyValuePair<string, int> animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        [Test]
        public void TestTuple()
        {
            //Tuple is a reference type and stored in heap memory.
            //Heap-> dynamic memory allocation/deallocation, stack -> static memory allocation

            //Once we create the Tuple, we cannot change the values of its fields.
            var tuple1 = new Tuple<int, string>(1, "cat");
            var tuple2 = Tuple.Create<int, string>(2, "dog");

            Console.WriteLine(tuple1);
            Console.WriteLine($"{tuple1.Item1} {tuple1.Item2}");
            Console.WriteLine(tuple2);
            Console.WriteLine($"{tuple2.Item1} {tuple2.Item2}");

        }



    }
}
