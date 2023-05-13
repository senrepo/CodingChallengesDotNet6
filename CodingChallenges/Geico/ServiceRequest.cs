using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Geico
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ProblemDescription { get; set; }
        public Vehicle DisabledVehicle { get; set; }
        public List<string> StatusLog { get; set; }

        public ServiceRequest()
        {
            StatusLog = new List<string>();
        }
    }
}
