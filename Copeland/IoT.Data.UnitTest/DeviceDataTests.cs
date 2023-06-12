namespace IoT.Data.UnitTest
{
    public class DeviceDataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_DeviceData_Implements_Interface()
        {
            var data = new DeviceData();
            Assert.IsInstanceOf<IDeviceData>(data);
        }
    }
}