using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.IntegrationTest
{
    public class TestAdapter : IDeviceDataAdapter
    {
        public List<IDeviceData> GetData()
        {
            return new List<IDeviceData>()
            {
                new DeviceData()
                {
                    CompanyId = 3
                }
            };
        }
    }
}
