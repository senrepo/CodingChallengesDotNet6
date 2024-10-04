using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    public class ByteTests
    {

        [Test]
        [TestCase(25)]
        [TestCase(-25)]
        public void Test_BitConverter_Bytes_Int32(int input)
        {
            byte[] bytes = BitConverter.GetBytes(input);
            var output = BitConverter.ToInt32(bytes, 0);
            Assert.That(output, Is.EqualTo(input));
        }

        [Test]
        //[TestCase(25)]
        [TestCase(-25)]
        public void Test_Convert_Int_Hex(int input)
        {
            var bytes = BitConverter.GetBytes(input);
            var output1 = BitConverter.ToInt32(bytes);
            Assert.AreEqual(input, output1);

            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            var hex = Convert.ToHexString(bytes);
            var output2 = Int32.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);
            Assert.AreEqual(input, output2);
        }


        [Test]
        [TestCase("hellow")]
        [TestCase("hello world 2023!")]
        public void Test_Convert_String_Hex(string input)
        {
            char[] values = input.ToCharArray();
            string[] hexValues = new string[values.Length];
            var i = 0;
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the integer value to a hexadecimal value in string form.
                hexValues[i++] += $"{value:X}";
            }

            var output = string.Empty;
            foreach (string hex in hexValues)
            {
                // Convert the number expressed in base-16 to an integer.
                int value = Convert.ToInt32(hex, 16);
                // Get the character corresponding to the integral value.
                output += Char.ConvertFromUtf32(value);
            }

            Assert.AreEqual(input, output);
        }


        [Test]
        [TestCase(new byte[] {25, 0, 0, 0})] //25
        [TestCase(new byte[] { 231, 255, 255, 255 })] //-25
        public void Test_Convert_Byte_Hex(byte[] input)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(input);
            string hex = BitConverter.ToString(input).Replace("-","");
            var output = Convert.FromHexString(hex);
            Assert.AreEqual(input, output);
        }

        [Test]
        public void Test_Array_Reference()
        {
            byte[] input = { 1, 2, 3, 4, };
            ProcessArray(input);
            Console.WriteLine(input);
        }

        private void ProcessArray(byte[] input)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(input);
        }

    }
}
