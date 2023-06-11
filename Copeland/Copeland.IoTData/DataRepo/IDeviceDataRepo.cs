using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.Repo
{
    public interface IDeviceDataRepo
    {
        void LoadData(IDeviceDataAdapter adapter);
        List<IDeviceData> GetData();
    }
}
