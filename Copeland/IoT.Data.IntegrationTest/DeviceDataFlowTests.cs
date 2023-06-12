using IoT.Data.DeviceFoo1;
using IoT.Data.DeviceFoo2;
using IoT.Data.Repo;
using Newtonsoft.Json;
using System.Diagnostics;

namespace IoT.Data.IntegrationTest
{
    public class DeviceDataFlowTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_DeviceData_Flow_JsonFile()
        {
            /* Steps
             *  Create a Repo
             *  Create a adapter with Device Foo1 json file
             *  Create a adapter with Device Foo2 json file
             *  Load Device Foo1 data to Repo
             *  Load Device Foo2 data to Repo
             *  Write the merged data to a json file
             */

            var repo = new DeviceDataRepo();

            string foo1Json = File.ReadAllText(@".\Files\DeviceDataFoo1.json");
            var deviceFoo1Adapter = new DeviceDataFoo1Adapter(foo1Json);

            string foo2Json = File.ReadAllText(@".\Files\DeviceDataFoo2.json");
            var deviceFoo2Adapter = new DeviceDataFoo2Adapter(foo2Json);

            repo.LoadData(deviceFoo1Adapter);
            repo.LoadData(deviceFoo2Adapter);

            var result = repo.GetData();
            Assert_DeviceData(result);

            var resultJson = JsonConvert.SerializeObject(result);
            var fileName = $"{new StackTrace()?.GetFrame(0)?.GetMethod()?.Name}.json";
            File.WriteAllText($".\\Files\\{fileName}", resultJson);

        }

        [Test]
        public void Test_DeviceData_Flow()
        {
            /* Steps
             *  Create a Repo
             *  Create a adapter with Device Foo1 object
             *  Create a adapter with Device Foo1 object
             *  Load Device Foo1 data to Repo
             *  Load Device Foo2 data to Repo
             *  Write the merged data to a json file
             */

            var repo = new DeviceDataRepo();

            string foo1Json = File.ReadAllText(@".\Files\DeviceDataFoo1.json");
            var deviceFoo1 = JsonConvert.DeserializeObject<DeviceDataFoo1>(foo1Json);
            var deviceFoo1Adapter = new DeviceDataFoo1Adapter(deviceFoo1);

            string foo2Json = File.ReadAllText(@".\Files\DeviceDataFoo2.json");
            var deviceFoo2 = JsonConvert.DeserializeObject<DeviceDataFoo2>(foo2Json);
            var deviceFoo2Adapter = new DeviceDataFoo2Adapter(deviceFoo2);

            repo.LoadData(deviceFoo1Adapter);
            repo.LoadData(deviceFoo2Adapter);

            var result = repo.GetData();
            Assert_DeviceData(result);

            var resultJson = JsonConvert.SerializeObject(result);
            var fileName = $"{new StackTrace()?.GetFrame(0)?.GetMethod()?.Name}.json";
            File.WriteAllText($".\\Files\\{fileName}", resultJson);
        }

        private void Assert_DeviceData(List<IDeviceData> result)
        {
            Assert.That(result.Count(), Is.EqualTo(4));

            Assert.That(result.Where(x => x.CompanyId == 1).Count, Is.EqualTo(2));
            var foo1Device1 = result.Where(x => x.CompanyId == 1 && x.DeviceId == 1).FirstOrDefault();
            Assert.That(foo1Device1?.TemperatureCount, Is.EqualTo(3));
            Assert.That(foo1Device1?.AverageTemperature, Is.EqualTo((22.15 + 23.15 + 24.15) / 3));
            var foo1Device2 = result.Where(x => x.CompanyId == 1 && x.DeviceId == 2).FirstOrDefault();
            Assert.That(foo1Device2?.HumidityCount, Is.EqualTo(3));
            Assert.That(foo1Device2?.AverageHumdity, Is.EqualTo((81.5 + 82.5 + 83.5) / 3));

            Assert.That(result.Where(x => x.CompanyId == 1).Count, Is.EqualTo(2));
            var foo2Device1 = result.Where(x => x.CompanyId == 2 && x.DeviceId == 1).FirstOrDefault();
            Assert.That(foo2Device1?.TemperatureCount, Is.EqualTo(3));
            Assert.That(foo2Device1?.AverageTemperature, Is.EqualTo((32.15 + 33.15 + 34.15) / 3));
            var foo2Device2 = result.Where(x => x.CompanyId == 2 && x.DeviceId == 2).FirstOrDefault();
            Assert.That(foo2Device2?.HumidityCount, Is.EqualTo(3));
            Assert.That(foo2Device2?.AverageHumdity, Is.EqualTo((91.5 + 92.5 + 93.5) / 3));
        }
    }
}