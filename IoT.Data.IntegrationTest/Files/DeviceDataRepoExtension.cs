using IoT.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.IntegrationTest.Files
{
    public class DeviceDataRepoExtension : DeviceDataRepo
    {
        public override void LoadData(IDeviceDataAdapter adapter)
        {
            base.LoadData(adapter);
        }

        public override List<IDeviceData> GetData()
        {
            return base.GetData();
        }
    }
}
