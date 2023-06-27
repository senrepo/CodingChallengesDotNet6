using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class DeclarationAndInitialization
    {
        [Test]
        public void Test_String_Initialization()
        {
            string[] animals = new string[] { "dog", "cat" };
            var birds = new string[] { "parrot", "crow" };

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("dog");
            stringBuilder.Append("cat");
            stringBuilder.Append(1);
            stringBuilder.Append(true);

            var result = stringBuilder.ToString();
        }

    }
}
