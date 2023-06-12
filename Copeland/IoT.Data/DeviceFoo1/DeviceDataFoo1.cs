using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.DeviceFoo1
{
    public class DeviceDataFoo1 
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public List<Tracker> Trackers { get; set; }

    }

    public class Tracker 
    {
        public int? Id { get; set; }
        public string Model { get; set; }
        public List<Sensor> Sensors { get; set; }
    }

    public class Sensor
    { 
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Crumb> Crumbs { get; set; }
    }

    public class Crumb 
    {
        public DateTime CreatedDtm { get; set; }
        public double? Value { get; set; }
    }
}
