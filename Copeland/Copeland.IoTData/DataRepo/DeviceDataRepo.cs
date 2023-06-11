using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.Repo
{
    public class DeviceDataRepo : IDeviceDataRepo
    {
        private readonly List<IDeviceData> _deviceData;

        public DeviceDataRepo()
        {
            _deviceData = new List<IDeviceData>();
        }

        public virtual void LoadData(IDeviceDataAdapter adapter)
        {
            var data = adapter.GetData();
            _deviceData.AddRange(data);
        }

        public virtual List<IDeviceData> GetData()
        {
            return _deviceData;
        }
    }
}
