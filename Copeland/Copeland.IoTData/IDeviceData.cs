using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data
{
    public interface IDeviceData
    {
        int CompanyId { get; set; } // Foo1: PartnerId, Foo2: CompanyId
        string CompanyName { get; set; } // Foo1: PartnerName, Foo2: Company
        int? DeviceId { get; set; } // Foo1: Id, Foo2: DeviceID
        string DeviceName { get; set; } // Foo1: Model, Foo2: Name
        DateTime? FirstReadingDtm { get; set; } // Foo1: Trackers.Sensors.Crumbs, Foo2: Devices.SensorData
        DateTime? LastReadingDtm { get; set; }
        int? TemperatureCount { get; set; }
        double? AverageTemperature { get; set; }
        int? HumidityCount { get; set; }
        double? AverageHumdity { get; set; }
    }
}
