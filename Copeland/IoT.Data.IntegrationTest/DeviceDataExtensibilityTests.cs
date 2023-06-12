using IoT.Data.DeviceFoo1;
using IoT.Data.IntegrationTest.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Data.IntegrationTest
{
    public class DeviceDataExtensibilityTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Test_DeviceData_Extensibility()
        {
            var repo = new DeviceDataRepoExtension();

            var deviceFoo1AdapterExention = new DeviceDataFoo1AdapterExtension();
            var testAdapter = new TestAdapter();

            repo.LoadData(deviceFoo1AdapterExention);
            repo.LoadData(testAdapter);

            var result = repo.GetData();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Where(x => x.CompanyId == 1).Count, Is.EqualTo(1));
            Assert.That(result.Where(x => x.CompanyId == 3).Count, Is.EqualTo(1));
        }
    }
}
