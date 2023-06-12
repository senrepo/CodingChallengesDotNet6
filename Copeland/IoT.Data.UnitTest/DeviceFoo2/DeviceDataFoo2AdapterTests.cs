using IoT.Data.DeviceFoo1;
using IoT.Data.DeviceFoo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.UnitTest.DeviceFoo2
{
    public class DeviceDataFoo2AdapterTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test_DeviceDataFoo1Adapter_Implements_Interface()
        {
            var data = new DeviceDataFoo2Adapter(String.Empty);
            Assert.IsInstanceOf<IDeviceDataAdapter>(data);
        }

        [Test]
        public void Test_DeviceDataFoo1Adapter_GetData()
        {
            var foo2Data = new DeviceDataFoo2();
            foo2Data.CompanyId = 1;
            foo2Data.Company = "xyz";
            foo2Data.Devices = new List<Device>()
            {
                new Device{
                    DeviceID = 1,
                    Name = "abc",
                    SensorData = new List<SensorData>()
                    {
                        new SensorData()
                        {
                            SensorType = "TEMP",
                            DateTime = DateTime.Parse("08-17-2020 10:35:00"),
                            Value = 1
                        },
                        new SensorData()
                        {
                            SensorType = "TEMP",
                            DateTime = DateTime.Parse("08-18-2020 10:40:00"),
                            Value = 2
                        },
                        new SensorData()
                        {
                            SensorType = "HUM",
                            DateTime = DateTime.Parse("08-17-2020 10:35:00"),
                            Value = 2
                        },
                        new SensorData()
                        {
                            SensorType = "HUM",
                            DateTime = DateTime.Parse("08-18-2020 10:40:00"),
                            Value = 4
                        },

                    }
                }
            };
            var data = new DeviceDataFoo2Adapter(foo2Data);
            var result = data.GetData();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result[0].CompanyId, Is.EqualTo(foo2Data.CompanyId));
            Assert.That(result[0].CompanyName, Is.EqualTo(foo2Data.Company));
            Assert.That(result[0].DeviceId, Is.EqualTo(foo2Data.Devices[0].DeviceID));
            Assert.That(result[0].DeviceName, Is.EqualTo(foo2Data.Devices[0].Name));

            Assert.That(result[0].FirstReadingDtm, Is.EqualTo(DateTime.Parse("08-17-2020 10:35:00")));
            Assert.That(result[0].LastReadingDtm, Is.EqualTo(DateTime.Parse("08-18-2020 10:40:00")));

            Assert.That(result[0].TemperatureCount, Is.EqualTo(2));
            Assert.That(result[0].AverageTemperature, Is.EqualTo(1.5));
            Assert.That(result[0].HumidityCount, Is.EqualTo(2));
            Assert.That(result[0].AverageHumdity, Is.EqualTo(3));
        }

        [Test]
        public void Test_DeviceDataFoo1Adapter_GetData_Null_Scenarios()
        {
            var foo2Data = new DeviceDataFoo2();

            var data = new DeviceDataFoo2Adapter(foo2Data);
            var result = data.GetData();
            Assert.That(result.Count, Is.EqualTo(0));

            foo2Data.Devices = new List<Device>();
            data = new DeviceDataFoo2Adapter(foo2Data);
            result = data.GetData();
            Assert.That(result.Count, Is.EqualTo(0));

            foo2Data.Devices.Add(new Device());
            data = new DeviceDataFoo2Adapter(foo2Data);
            result = data.GetData();
            Assert.That(result.Count, Is.EqualTo(1));

            Assert.That(result[0].CompanyId, Is.EqualTo(0));
            Assert.True(string.IsNullOrEmpty(result[0].CompanyName));
            Assert.IsNull(result[0].DeviceId);
            Assert.True(string.IsNullOrEmpty(result[0].DeviceName));
            Assert.IsNull(result[0].FirstReadingDtm);
            Assert.IsNull(result[0].LastReadingDtm);
            Assert.IsNull(result[0].TemperatureCount);
            Assert.IsNull(result[0].AverageTemperature);
            Assert.IsNull(result[0].HumidityCount);
            Assert.IsNull(result[0].AverageHumdity);
        }
    }
}
