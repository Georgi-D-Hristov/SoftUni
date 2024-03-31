namespace Television.Tests
{
    using NUnit.Framework;
    public class Tests
    {
        private const string Brand = "JVC";
        private const double Price = 1000;
        private const int ScreenWidth = 1200;
        private const int ScreenHeigth = 800;
        private  string Sound = "On";

        private TelevisionDevice jvc;

        [SetUp]
        public void Setup()
        { 
            jvc = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeigth);
        }

        [Test]
        public void Test_Constructor()
        {
            var television = new TelevisionDevice("Sony", 1000, 1200, 800);

            Assert.IsNotNull(television);
            Assert.That(television.Brand, Is.EqualTo("Sony"));
            Assert.That(television.Price, Is.EqualTo(1000));
            Assert.That(television.ScreenWidth, Is.EqualTo(1200));
            Assert.That(television.ScreenHeigth, Is.EqualTo(800));
        }

        [Test]
        public void Test_TostringMethod()
        {
            Assert.That(jvc.ToString(), Is.EqualTo($"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeigth}, Price {Price}$"));
        }

        
        [Test]
        public void VolumeChange()
        {
            var volume = jvc.Volume;
            Assert.AreEqual(13, volume);
            jvc.VolumeChange("UP", 17);
            Assert.AreEqual(30, jvc.Volume);
            jvc.VolumeChange("UP", 100);
            Assert.AreEqual(100, jvc.Volume);
            jvc.VolumeChange("DOWN", 50);
            Assert.AreEqual(50,jvc.Volume);
            jvc.VolumeChange("DOWN", 100);
            Assert.AreEqual(0, jvc.Volume);
            //Assert.That(jvc.VolumeChange("UP", 50), Is.EqualTo($"Volume: {50}"));
        }

        [Test]
        public void Test_MuteDevice()
        {
            Assert.AreEqual(false, jvc.IsMuted);
            jvc.MuteDevice();
            Assert.AreEqual(true, jvc.IsMuted);
            jvc.MuteDevice();
            Assert.AreEqual(false, jvc.IsMuted);
        }

        [Test]
        public void Test_ChangeChanel()
        {
            Assert.AreEqual(0, jvc.CurrentChannel);
            jvc.ChangeChannel(10);
            Assert.AreEqual(10, jvc.CurrentChannel);
           var ae = Assert.Throws<ArgumentException>(() => jvc.ChangeChannel(-10));
           Assert.AreEqual(ae.Message, "Invalid key!");
        }

        [Test]
        public void Test_SwitchOn()
        {
            //jvc.SwitchOn();
            
            Assert.AreEqual($"Cahnnel {jvc.CurrentChannel} - Volume {jvc.Volume} - Sound On", jvc.SwitchOn());
            jvc.MuteDevice();
            Assert.AreEqual($"Cahnnel {jvc.CurrentChannel} - Volume {jvc.Volume} - Sound Off", jvc.SwitchOn());
        }
    }
}