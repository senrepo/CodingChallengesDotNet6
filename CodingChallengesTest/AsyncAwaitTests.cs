using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class AsyncAwaitTests
    {

        /*  
            Key pieces to understand
            Async code can be used for both I/O-bound and CPU-bound code, but differently for each scenario.
            Async code uses Task<T> and Task, which are constructs used to model work being done in the background.
            The async keyword turns a method into an async method, which allows you to use the await keyword in its body.
            When the await keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete.
            await can only be used inside an async method.
         * 
         * 
         * Here are two questions you should ask before you write any code:
            Will your code be "waiting" for something, such as data from a database?
                If your answer is "yes", then your work is I/O-bound.
            Will your code be performing an expensive computation?
                If you answered "yes", then your work is CPU-bound.
            If the work you have is I/O-bound, use async and await without Task.Run. You should not use the Task Parallel Library.
            If the work you have is CPU-bound and you care about responsiveness, 
                use async and await, but spawn off the work on another thread with Task.Run. 
                If the work is appropriate for concurrency and parallelism, also consider using the Task Parallel Library.
         * 
         *  In Nutshell, 
         *      await return/yields the control to caller with a Task and promise it will result result once its completes
         *      Result retuns the result to the caller
         */

        [Test]
        public async Task TestAsync()
        {
            var client = new HttpClient();

            //Option 1
            Task<string> getStringTask =  client.GetStringAsync("https://dummyjson.com/products");
            DoIndependentWork();
            string contents = await getStringTask;

            Assert.True(contents.Length > 0);
            Console.WriteLine("Completed...");


            //Option 2
            var response = await client.GetAsync("https://dummyjson.com/products");
            DoIndependentWork(); //the above code returns yield the control to caller, so it will be executed once the above task complete
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Assert.True(contents.Length > 0);
        }
        
        private void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }

        [Test]
        public async Task TaskRun()
        {
            //create 20 random rumbers from 1-20 and calculate the factorial
            //CPU bound operation

            var factorialList = new List<Factorial>();
            var random = new Random();
            int number = 0;
            for(int i = 1; i <= 10; i++)
            {
                number = random.Next(1, 10);
                factorialList.Add(new Factorial { Number = number});
            }

            var tasks = new List<Task>();
            foreach(var item in factorialList)
            {
                var task = Task.Factory.StartNew((obj) =>
                {
                    var factorial = obj as Factorial;
                    factorial!.Value = RecursiveFactorial(factorial.Number);

                }, item);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            foreach(var item in factorialList)
            {
                Console.WriteLine($"{item.Number} factorial value is {item.Value}");
            }
        }

        [Test]
        public async Task TaskRun1()
        {
            //create 20 random rumbers from 1-20 and calculate the factorial
            //CPU bound operation

            var factorialList = new List<KeyValuePair<int, Task<int>>>();
            var random = new Random();
            int number = 0;
            for (int i = 1; i <= 10; i++)
            {
                number = random.Next(1, 10);
                var task = Task<int>.Factory.StartNew((obj) =>
                {
                    var factorialNumber = Convert.ToInt32(obj);

                    return RecursiveFactorial(factorialNumber);

                },number);
                factorialList.Add(new KeyValuePair<int, Task<int>>(number, task));
            }

            foreach (var item in factorialList)
            {
                Console.WriteLine($"{item.Key} factorial value is {item.Value.Result}");
            }
        }

        private int RecursiveFactorial(int n)
        {
            if (n == 1) return 1;
            else return n * RecursiveFactorial(n - 1);
        }

        private class Factorial
        {
            public int Number { get; set; }
            public int Value { get; set; }

        }

        [Test]
        public async Task TaskParallell()
        {
            /* Concurrency 
             *  Consider two tasks, T1 and T2, that have to be executed by an application. 
             *  if one is in an execution state while the other is waiting for its turn.
             *  As a result, one of the tasks completes ahead of the other.
             */


            /* Parallelism 
             *  Consider two tasks, T1 and T2, that have to be executed by an application. 
             *  the two tasks are in parallel execution if both execute simultaneously. 
             *  To achieve task parallelism, the program must run on a CPU with multiple cores.
             */

            Func<int, bool> IsPrime = delegate (int integer)
            {
                if (integer <= 1) return false;
                if (integer == 2) return true;
                var limit = Math.Ceiling(Math.Sqrt(integer));
                for (int i = 2; i <= limit; ++i)
                    if (integer % i == 0)
                        return false;
                return true;
            };

            var list = new List<int>();
            for(var i = 1; i < 100; ++i)
            {
                list.Add(i);
            }

            var concurrentList = new ConcurrentBag<int>();
            Parallel.ForEach(list, number =>
            {
                if (IsPrime(number)) concurrentList.Add(number);
            });

            Console.WriteLine("Prime number list between 1 to 100");
            foreach(var item in concurrentList)
            {
                Console.WriteLine(item);
            }
        }


    }
}
