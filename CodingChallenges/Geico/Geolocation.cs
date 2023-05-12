using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Geico
{
    public class Geolocation
    {
        public int Xcoordinate { get; set; }   
        public int Ycoordinate { get; set; }

        public Geolocation(int x, int y)
        {
            this.Xcoordinate = x;
            this.Ycoordinate = y;
        }
    }
}
