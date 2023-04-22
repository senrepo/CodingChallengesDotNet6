using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class LINQ
    {
        [Test]
        public void Select()
        {
            //select used for transformation scenarios

            string[] animals = { "cat", "dog", "mouse" };
            var result = animals.Select(item => item.ToUpper());
            Console.WriteLine(result);

            var employees = new List<Employee>() {
                new Employee() { ID= 1, FirstName = "Raj", LastName = "Kumar"},
                new Employee() { ID= 2, FirstName = "Palani", LastName = "Swamy"},
            };

            var dtoList = employees.Select(emp =>
            {
                return new EmployeeDTO { ID = emp.ID, FullName = String.Join(" ", emp.FirstName, emp.LastName) };
            });

            Console.WriteLine(dtoList);
        }

        [Test]
        public void Sum()
        {
            var employees = new List<Employee>() {
                new Employee() { ID= 1, FirstName = "Raj", LastName = "Kumar", EmploymentType = EmploymentType.FullTime, Age=45},
                new Employee() { ID= 2, FirstName = "Palani", LastName = "Swamy", EmploymentType = EmploymentType.PartTime, Age=55},
                new Employee() { ID= 2, FirstName = "Kumaravel", LastName = "Arumugam", EmploymentType = EmploymentType.FullTime, Age=40},
                new Employee() { ID= 2, FirstName = "Ganesh", LastName = "Chella", EmploymentType = EmploymentType.Contract, Age=25},
            };

            //find the average age of Fulltime employees
            var sum = employees.Sum(emp =>
            {
                if (emp.EmploymentType == EmploymentType.FullTime) return emp.Age;
                else return 0;
            });

            Console.WriteLine(sum);
        }

        [Test]
        public void Aggregate()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int result = array.Aggregate((a, b) => b + a);
            // 1 + 2 = 3
            // 3 + 3 = 6
            // 6 + 4 = 10
            // 10 + 5 = 15
            Console.WriteLine(result);
        }


        public enum EmploymentType
        {
            FullTime,
            PartTime,
            Contract
        }

        public class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public EmploymentType EmploymentType { get; set; }
            public int Age { get; set; }

        }

        public class EmployeeDTO
        {
            public int ID { get; set; }
            public string FullName { get; set; }
        }

        

    }
}
