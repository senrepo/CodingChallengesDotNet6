using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class CollectionTests
    {

        /* Non Generic Type - takes object type, so need to typecast when reading out the values
			    HashTable
			    ArrayList
		    Generic Type
			    List<T> - size grow dynamically, good for perform add, delete operations at the middle
			    Dictionary<Tkey, Tvalue>
			    HashSet - represent a mathematical set { 1, 2, 3 } - elimiate the duplicates
                SortedSet - remove the duplicates, for class type, need to provide the comparer
			    Stack<T> - LIFO - Last in First out
			    Queue<T> - FIFO - First in First out
         */

        [Test]
        public void TestHashSet()
        {
            var line = "HashSet.This is an optimized C# set collection.  It helps eliminates duplicate strings or elements in an array. It is a set that hashes its contents.";

            var distinctWords = new DistinctWords(line);
            var words = distinctWords.GetWords();

            Console.WriteLine(String.Join(" ", words));
        }

        [Test]
        public void Test_String_Join_Collections()
        {
            var list = new List<Employee>() {
                new Employee
                {
                    Id = 1,
                    Name = "Raj"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Muthu"
                }
            };

            var result = string.Join(",", list);
            Console.WriteLine(result);

            List<Employee> list2 = null;
            result = string.Join(",", list2 ?? new List<Employee>());
            Console.WriteLine(result);
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}";
            }
        }

    } 
}
