using Humanizer;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public static class DateExtentions
    {
        public static DateTime LastDayOfMonth(this DateTime candidate)
        {
            var today = DateTime.Today;
            DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            return endOfMonth;
        }

        public static bool IsLastDayOfMonth(this DateTime candidate)
        {
            return candidate == candidate.LastDayOfMonth();
        }
    }

    public class CsharpTipsTests
    {
        public class SmartCity
        {
            public string StateCode { get; set; }
            public List<string> Cities { get; set; }
        }

        [Test]
        public void Test_Csharp_FlattenLists()
        {
            var stateTN = new SmartCity { StateCode = "TN", Cities = new List<string> { "Chennai", "Coimbatore", "Madurai", "Trichy" } };
            var stateKA = new SmartCity { StateCode = "KA", Cities = new List<string> { "Bangaluru", "Mysore" } };

            List<SmartCity> cities = new List<SmartCity>();
            cities.Add(stateTN);
            cities.Add(stateKA);

            List<string> list = cities.SelectMany(x => x.Cities).ToList();
            foreach (var city in list)
            {
                Console.WriteLine(city);
            }

            Assert.AreEqual(6, list.Count());
        }

        [Test]
        public void Test_Csharp_DateOnly_TimeOnly()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Today is {today}");
            Console.WriteLine($"Is Last Day of Monthy {DateTime.Now.IsLastDayOfMonth()}");

            var now = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"It is {now} right now");
        }

        [Test]
        public void Test_Csharp_Humanize()
        {
            //Humanizer nuget package is developed by DotNet foundation
            //Date humanize
            var now = DateTime.Now;
            Console.WriteLine(now.ToShortTimeString());
            Console.WriteLine(now.AddMonths(-5).Humanize());
            Console.WriteLine(now.AddMinutes(12).Humanize());

            //Int humanize 
            Console.WriteLine(1695.ToWords());
        }

        [Test]
        public void Test_Csharp_ReadonlyCollection()
        {
            var flowers = new List<string>() { "Rose", "Jasmine", "Lotus" };
            IReadOnlyCollection<string> flowersSold1 = flowers.AsReadOnly();
            IReadOnlyCollection<string> flowersSold2 = new ReadOnlyCollection<string>(flowers);
            IEnumerable<string> flowersEnumerable = flowers.AsEnumerable();
            IEnumerator<string> flowersEnumerator = flowers.GetEnumerator();
            // IEnumerable is sugarcoat for IEnumerator, IEnumerator use the Current, Next, Previous, Count methods explicitly for iteration
        }

        [Test]
        public void Test_Csharp_Path_CrossPlatform()
        {
            var currentDir = Environment.CurrentDirectory;
            var filePath = Path.Join(currentDir, "bin"); //create the path string based on OS
            Console.WriteLine(filePath); 

        }


        public class Package
        {
            public string Company { get; set; }
            public double Weight { get; set; }
            public long TrackingNumber { get; set; }
        }

        [Test]
        public void Test_Csharp_ToLookup()
        {
            //ToLookup() - immediate execution but may not fit for larger dataset
            List<Package> packages = new List<Package>  { 
                new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                new Package { Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L },
                new Package { Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L } 
            };

            //Create the lookup to use the first character of Company as the key value.
            var lookup1 = packages.ToLookup(p => p.Company[0]);
            var lookup2 = packages.ToLookup(p => p.Company[0], p => string.Join(", ", p.Company, p.Weight, p.TrackingNumber));

            Console.WriteLine(lookup1);
            Console.WriteLine(lookup2);
        }

        [Test]
        public void Test_Csharp_GroupBy()
        {
            //GroupBy() - deferred execution, grouping is reevaluated each time when group is iterated over, might have some performance impact
            List <Package> packages = new List<Package>  {
                new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                new Package { Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L },
                new Package { Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L }
            };

            //Create the lookup to use the first character of Company as the key value.
            var list = packages.GroupBy(p => p.Company[0]).ToList();
        }
    }
}
