using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class ReflectionTests
    {
        [Test]
        public void Test_Reflection_Invoke_Method()
        {
            var emp = new Employee();
            MethodInfo? method = emp.GetType().GetMethod("GetName");
            var result = method.Invoke(emp, null);
        }

    }


    public class Employee
    {
        public string GetName()
        {
            return "Ravindra";
        }
    }

}
