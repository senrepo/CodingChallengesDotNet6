using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DocumentService.Tests
{
    public class TravelersCodingChallengeTests
    {
        [Fact]
        public async Task Test_Obsolete()
        {

            var message = DoTask();
            //message = DoTaskOld();

        }

        [Obsolete("This method is deprecated, recommand to use DoTaskNew",true)]
        private string DoTaskOld()
        {
            return "DoTask completed";
        }

        [Obsolete("This method is deprecated, recommand to use DoTaskNew")]
        private string DoTask()
        {
            return "DoTask completed";
        }

        private string DoTaskNew()
        {
            return "DoTaskNew completed";
        }

        [Fact]
        public async Task Test_MatrixIndexer()
        {
            var matrix = new Matrix();
            matrix[0, 2] = 10;
            Assert.Equal(10, matrix[0,2]);
        }

        [Fact]
        public async Task Test_Decimal()
        {
            var val1 = (decimal)8 / 3;
            var val2 = 8 / (decimal)3;
            var val3 = (decimal)(8 / 3);
            Assert.Equal(2.6666666666666666666666666667M, val1);
            Assert.Equal(2.6666666666666666666666666667M, val2);
        }

    }

    public class Matrix
    {
        private int[,] _matrix = new int[5, 5];

        public int this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }

    }
}
