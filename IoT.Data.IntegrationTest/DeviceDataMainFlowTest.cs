using IoT.Data.DeviceFoo1;
using IoT.Data.DeviceFoo2;
using IoT.Data.Repo;
using Newtonsoft.Json;
using System.Diagnostics;

namespace IoT.Data.IntegrationTest
{
    public class DeviceDataMainFlowTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MainFlowTests()
        {
            var repo = new DeviceDataRepo();

            string foo1Json = File.ReadAllText(@".\Files\DeviceDataFoo1.json");
            var deviceFoo1Adapter = new DeviceDataFoo1Adapter(foo1Json);

            string foo2Json = File.ReadAllText(@".\Files\DeviceDataFoo2.json");
            var deviceFoo2Adapter = new DeviceDataFoo2Adapter(foo2Json);

            repo.LoadData(deviceFoo1Adapter);
            repo.LoadData(deviceFoo2Adapter);

            var data = repo.GetData();
            Assert.IsTrue(data.Count > 0);

            var resultJson = JsonConvert.SerializeObject(data);
            var fileName = $"{new StackTrace()?.GetFrame(0)?.GetMethod()?.Name}.json";
            File.WriteAllText($".\\Files\\{fileName}", resultJson);

        }
    }
}