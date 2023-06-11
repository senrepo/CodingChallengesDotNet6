using IoT.Data.DeviceFoo1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.DeviceFoo2
{
    public class DeviceDataFoo2Adapter : IDeviceDataAdapter
    {
        private readonly DeviceDataFoo2? _deviceDataFoo2;
        public DeviceDataFoo2Adapter(DeviceDataFoo2 deviceDataFoo2)
        {
            _deviceDataFoo2 = deviceDataFoo2;
        }

        public DeviceDataFoo2Adapter(string json)
        {
            _deviceDataFoo2 = JsonConvert.DeserializeObject<DeviceDataFoo2>(json);
        }

        public virtual List<IDeviceData> GetData()
        {
            var list = new List<IDeviceData>();
            _deviceDataFoo2?.Devices?.ForEach(device =>
            {
                var data = new DeviceData();
                data.CompanyId = _deviceDataFoo2.CompanyId;
                data.CompanyName = _deviceDataFoo2.Company;
                data.DeviceId = device.DeviceID;
                data.DeviceName = device.Name;

                var sensorData = device.SensorData;
                sensorData?.Sort((x, y) => {
                    return DateTime.Compare(x.DateTime, y.DateTime);
                });

                data.FirstReadingDtm = sensorData?.FirstOrDefault()?.DateTime;
                data.LastReadingDtm = sensorData?.LastOrDefault()?.DateTime;

                var temperatureSensors = sensorData?.Where(x => x.SensorType == "TEMP");
                data.TemperatureCount = temperatureSensors?.Count();
                data.AverageTemperature = temperatureSensors?.Select(x => x.Value).Average();

                var humidtySensors = sensorData?.Where(x => x.SensorType == "HUM");
                data.HumidityCount = humidtySensors?.Count();
                data.AverageHumdity = humidtySensors?.Select(x => x.Value).Average();

                list.Add(data);
            });
            return list;

        }
    }
}
