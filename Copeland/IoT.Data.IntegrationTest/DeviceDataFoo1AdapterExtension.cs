using IoT.Data.DeviceFoo1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.IntegrationTest
{
    public class DeviceDataFoo1AdapterExtension : DeviceDataFoo1Adapter
    {
        public DeviceDataFoo1AdapterExtension() : base(String.Empty)
        {
        }

        public override List<IDeviceData> GetData()
        {
            return new List<IDeviceData>()
            {
                new DeviceData()
                {
                    CompanyId = 1
                }
            };
        }

    }
}
