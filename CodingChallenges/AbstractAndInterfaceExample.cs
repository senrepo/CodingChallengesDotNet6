using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    /*
     * 	All interface class and method access modifiers are public, either explictly mentioned or not mentioned.
	    The derived class should have equal or less scope modifiers than base class
	    There is no rule that Abstract class should have a abstract method, 
            however, the abstract method can be placed inside a Abstract class
     * 
     */

    public interface ExampleInterface1
    {
        public void ExampleMethod1();
    }

    interface ExampleInterface2
    {
        void ExampleMethod2();
    }


    public abstract class AbstractAndInterfaceExample : ExampleInterface1, ExampleInterface2
    {
        public void ExampleMethod1()
        {
            throw new NotImplementedException();
        }

        public void ExampleMethod2()
        {
            throw new NotImplementedException();
        }
    }

    internal class DeriveAbstract : AbstractAndInterfaceExample
    {
        public string Test()
        {
            return "test message";
        }
    }

}
