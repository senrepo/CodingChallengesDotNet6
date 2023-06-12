using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data
{
    public interface IDeviceDataAdapter
    {
        List<IDeviceData> GetData();
    }
}
