namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device nokia;
        [SetUp]
        public void Setup()
        {
            nokia = new Device(1024);
        }

        [Test]
        public void Test_CtorInitialObjects()
        {
            var phone = new Device(1024);
            Assert.IsNotNull(phone);
            Assert.AreEqual(1024, phone.MemoryCapacity);
            Assert.AreEqual(0, phone.Photos);
            Assert.AreEqual(0, phone.Applications.Count);

        }

        [Test]
        public void Test_TakePhoto()
        {
            nokia.TakePhoto(100);
            Assert.AreEqual(1, nokia.Photos);
            Assert.AreEqual(924, nokia.AvailableMemory);
            Assert.IsTrue(nokia.TakePhoto(24));
            Assert.IsFalse(nokia.TakePhoto(1024));
        }

        [Test]
        public void Test_InstallApp()
        {
            nokia.InstallApp("Snake", 24);
            Assert.AreEqual(1000, nokia.AvailableMemory);
            Assert.IsTrue(nokia.Applications.Contains("Snake"));
            Assert.Throws<InvalidOperationException>(() => nokia.InstallApp("FIFA", 5000));
        }

        [Test]
        public void Test_FormatDevice()
        {
            nokia.TakePhoto(10);
            nokia.InstallApp("hitman", 14);
            nokia.FormatDevice();
            Assert.AreEqual(0, nokia.Photos);
            Assert.AreEqual(nokia.MemoryCapacity, nokia.AvailableMemory);
            Assert.IsEmpty(nokia.Applications);
        }

        [Test]
        public void Test_GetStatus()
        {
            nokia.TakePhoto(24);
            nokia.InstallApp("Snake", 500);
            var sb = new StringBuilder();

            sb.AppendLine($"Memory Capacity: 1024 MB, Available Memory: 500 MB");
            sb.AppendLine($"Photos Count: 1");
            sb.AppendLine($"Applications Installed: Snake");

            Assert.AreEqual(sb.ToString().TrimEnd(), nokia.GetDeviceStatus());
        }
    }
}