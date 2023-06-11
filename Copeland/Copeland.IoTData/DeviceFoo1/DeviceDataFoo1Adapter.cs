using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.DeviceFoo1
{

    public class DeviceDataFoo1Adapter : IDeviceDataAdapter
    {
        private readonly DeviceDataFoo1? _deviceDataFoo1;

        public DeviceDataFoo1Adapter(DeviceDataFoo1 deviceDataFoo1)
        {
            _deviceDataFoo1 = deviceDataFoo1;
        }

        public DeviceDataFoo1Adapter(string json)
        {
           
            _deviceDataFoo1 = JsonConvert.DeserializeObject<DeviceDataFoo1>(json);
        }

        public virtual List<IDeviceData> GetData()
        {
            var list = new List<IDeviceData>();
           _deviceDataFoo1?.Trackers?.ForEach(device =>
           {
                var data = new DeviceData();
                data.CompanyId = _deviceDataFoo1.PartnerId;
                data.CompanyName = _deviceDataFoo1.PartnerName;
                data.DeviceId = device.Id;
                data.DeviceName = device.Model;

                var crumbs = device.Sensors?.SelectMany(sensor => sensor.Crumbs).ToList();
                crumbs?.Sort((x, y) => {
                    return DateTime.Compare(x.CreatedDtm, y.CreatedDtm);
                });

                data.FirstReadingDtm = crumbs?.FirstOrDefault()?.CreatedDtm;
                data.LastReadingDtm = crumbs?.LastOrDefault()?.CreatedDtm;

                var temperatureSensors = device.Sensors?.Where(x => x.Name == "Temperature").SelectMany(y => y.Crumbs);
                data.TemperatureCount = temperatureSensors?.Count();
                data.AverageTemperature = temperatureSensors?.Select(z => z.Value).Average();

                var humidtySensors = device.Sensors?.Where(x => x.Name == "Humidty")?.SelectMany(y => y.Crumbs);
                data.HumidityCount = humidtySensors?.Count();
                data.AverageHumdity = humidtySensors?.Select(z => z.Value).Average();

                list.Add(data);
           });
            return list;
        }
    }
}
