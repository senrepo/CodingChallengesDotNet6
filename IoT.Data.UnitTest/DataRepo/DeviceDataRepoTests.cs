using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoT.Data.DeviceFoo2;
using IoT.Data.Repo;
using Moq;

namespace IoT.Data.UnitTest.DataRepo
{
    public class DeviceDataRepoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_DeviceDataRepo_Implements_Interface()
        {
            var repo = new DeviceDataRepo();
            Assert.IsInstanceOf<IDeviceDataRepo>(repo);

        }

        [Test]
        public void Test_DeviceDataRepo_LoadData()
        {
            var adaperMock = new Mock<IDeviceDataAdapter>();
            adaperMock.Setup(x => x.GetData()).Returns(new List<IDeviceData>());

            var repo = new DeviceDataRepo();
            repo.LoadData(adaperMock.Object);

            Assert.That(repo.GetData().Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_DeviceDataRepo_GetData()
        {
            var adaperMock = new Mock<IDeviceDataAdapter>();
            adaperMock.Setup(x => x.GetData()).Returns(()=>
            {
                var data = new List<IDeviceData>();
                data.Add(new DeviceData());
                return data;
            });

            var repo = new DeviceDataRepo();
            repo.LoadData(adaperMock.Object);

            Assert.That(repo.GetData().Count, Is.EqualTo(1));
        }
    }
}