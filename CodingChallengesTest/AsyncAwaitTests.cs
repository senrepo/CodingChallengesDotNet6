using System;
using System.Collections.Generic;
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


    }
}
