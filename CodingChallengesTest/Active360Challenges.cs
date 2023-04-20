using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class Active360Challenges
    {
        // Initialize a Dictionary of key{long} and value{objects}, convert it to a list based on any condition and thenfilter the list by multiple properties and then sort them
        // Use arrow inline function 1. takes in 2 number and return the sum, 2. takes the sum and print it to the console= 
        // Recursive function to find a factorial of a number  

        [Test]
        public void DictonaryChallenge()
        {
            //Initialize a Dictionary of key{long} and value{objects},
            //convert it to a list based on any condition
            // and thenfilter the list by multiple properties and then sort them

            //Initialize a Dictionary of key{long} and value{objects},
            var employeeDict = new Dictionary<string, Employee>()
            {
                { "1", new Employee { ID = 1, FirstName = "sujith", LastName = "kumar", YearsOfExp = 1} },
                { "2", new Employee { ID = 1, FirstName = "sujith", LastName = "nakulla", YearsOfExp = 2} },
                { "3", new Employee { ID = 1, FirstName = "muthu", LastName = "kumar", YearsOfExp = 3} }
            };

            // and thenfilter the list by multiple properties
            var result = employeeDict.Where(employee => employee.Value.LastName == "kumar").ToList();

            result.Sort((x, y) => {
                // return x.Value.FirstName.CompareTo(y.Value.FirstName);
                //return x.Value.YearsOfExp.CompareTo(y.Value.YearsOfExp); //asc
                return y.Value.YearsOfExp.CompareTo(x.Value.YearsOfExp); //desc
            });

            foreach(var employee in result)
            {
                Console.WriteLine(employee.Value.FirstName);
            }
        }

        public class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int YearsOfExp { get; set; }
        }
    }
}
