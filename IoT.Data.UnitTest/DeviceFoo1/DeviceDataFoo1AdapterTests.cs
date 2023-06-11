using IoT.Data.DeviceFoo1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.UnitTest.DeviceFoo1
{
    public class DeviceDataFoo1AdapterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_DeviceDataFoo1Adapter_Interface()
        {
            var data = new DeviceDataFoo1Adapter(String.Empty);
            Assert.IsInstanceOf<IDeviceDataAdapter>(data);
        }

        [Test]
        public void Test_DeviceDataFoo1Adapter_GetData()
        {
            var foo1Data = new DeviceDataFoo1();
            foo1Data.PartnerId = 1;
            foo1Data.PartnerName = "xyz";
            foo1Data.Trackers = new List<Tracker>()
            {
                new Tracker{
                    Id = 1,
                    Model = "abc",
                    Sensors = new List<Sensor>()
                    {
                        new Sensor()
                        {
                            Id = 1,
                            Name = "Temperature",
                            Crumbs = new List<Crumb>()
                            {
                               new Crumb()
                               {
                                   CreatedDtm = DateTime.Parse("08-17-2020 10:35:00"),
                                   Value = 1
                               },
                               new Crumb()
                               {
                                   CreatedDtm = DateTime.Parse("08-17-2020 10:40:00"),
                                   Value = 2
                               }
                            }
                        },
                        new Sensor()
                        {
                            Id = 1,
                            Name = "Humidty",
                            Crumbs = new List<Crumb>()
                            {
                               new Crumb()
                               {
                                   CreatedDtm = DateTime.Parse("08-17-2020 10:35:00"),
                                   Value =  2
                               },
                               new Crumb()
                               {
                                   CreatedDtm = DateTime.Parse("08-17-2020 10:40:00"),
                                   Value = 4
                               }
                            }
                        }
                    }
                }
            };
            var data = new DeviceDataFoo1Adapter(foo1Data);
            var result = data.GetData();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result[0].CompanyId, Is.EqualTo(foo1Data.PartnerId));
            Assert.That(result[0].CompanyName, Is.EqualTo(foo1Data.PartnerName));
            Assert.That(result[0].DeviceId, Is.EqualTo(foo1Data.Trackers[0].Id));
            Assert.That(result[0].DeviceName, Is.EqualTo(foo1Data.Trackers[0].Model));

            Assert.That(result[0].FirstReadingDtm, Is.EqualTo(DateTime.Parse("08-17-2020 10:35:00")));
            Assert.That(result[0].LastReadingDtm, Is.EqualTo(DateTime.Parse("08-17-2020 10:40:00")));

            Assert.That(result[0].TemperatureCount, Is.EqualTo(2));
            Assert.That(result[0].AverageTemperature, Is.EqualTo(1.5));
            Assert.That(result[0].HumidityCount, Is.EqualTo(2));
            Assert.That(result[0].AverageHumdity, Is.EqualTo(3));
        }

        [Test]
        public void Test_DeviceDataFoo1Adapter_GetData_Null_Scenarios()
        {
            var foo1Data = new DeviceDataFoo1();

            var data = new DeviceDataFoo1Adapter(foo1Data);
            var result = data.GetData();
            Assert.That(result.Count, Is.EqualTo(0));

            foo1Data.Trackers = new List<Tracker>();
            data = new DeviceDataFoo1Adapter(foo1Data);
            result = data.GetData();
            Assert.That(result.Count, Is.EqualTo(0));

            foo1Data.Trackers.Add(new Tracker());
            data = new DeviceDataFoo1Adapter(foo1Data);
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
