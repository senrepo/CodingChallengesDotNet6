using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class VolatileTest
    {
        public volatile bool IsOccupied;


        public void TestVolatile()
        {
            /*  non-volatile memory access
             *      When your program executes, the processor may cache the data and then access this data from the cache
             *      Updates and reads of this data might run against the cached version of the data, while the main memory is updated at a later point in time. 
             *      When one thread is interacting with the data in the cache, and a second thread tries to read the same data concurrently, 
             *      the second thread might read an outdated version of the data from the main memory. 
             *      This is because when the value of a non-volatile object is updated, the change is made in the cache of the executing thread and not in the main memory. 
             *      
             *  volatile 
             *      Volatile keyword in C# is used to inform the JIT compiler that the value of the variable should never be cached
             *      When you mark an object or a variable as volatile, it becomes a candidate for volatile reads and writes.
             *      If the object is volatile, the thread always gets the most up-to-date value.
             *      volatile keyword used with reference and value types
             *      local variables cannot be declared as volatile. 
             *      
             *      volatile keyword can help you in thread safety in certain situations, it is not a solution to all of your thread concurrency issues.
             *      marking a variable or an object as volatile does not mean you don’t need to use the lock keyword.
             * 
             * 
             * 
             */
        }
    }
}
