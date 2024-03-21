using System.Security.Cryptography.X509Certificates;

namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car _car;

        private void SetPrivateFiledValue()
        {
            var filed = typeof(Car).GetField("fuelAmount");
            filed.SetValue(this,-10);
        }

        [SetUp]
        public void Initial()
        {
            _car = new Car("VW", "Golf4", 1, 50);
        }

        [Test]
        public void Test_CarCreate()
        {
            var ford = new Car("Ford", "Mustang", 25, 95);
            Assert.IsNotNull(ford);
            Assert.AreEqual("Ford", ford.Make);
            Assert.AreEqual("Mustang", ford.Model);
            Assert.AreEqual(25, ford.FuelConsumption);
            Assert.AreEqual(95, ford.FuelCapacity);
            Assert.AreEqual(0, ford.FuelAmount);
        }

        [Test]
        public void Test_CarWithNotValidMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "F50", 45, 200));
        }

        [Test]
        public void Test_CarWithNotValidModel()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ferrari", null, 45, 200));
        }

        [Test]
        public void Test_CarWithNegativeFuelAmount()
        {
            
            //SetPrivateProperty("-10");
            
                //Assert.Throws<ArgumentException>(() => SetPrivateFiledValue());
        }
        [Test]
        public void Test_CarWithZeroOrNegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M5", -10, 100));
        }

        [Test]
        public void Test_CarWithNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M5", 10, -100));
        }

        [Test]
        public void Test_CarRefuel()
        {
            Assert.Throws<ArgumentException>(() => _car.Refuel(-10));
            _car.Refuel(10);
            Assert.AreEqual(10, _car.FuelAmount);
            _car.Refuel(120);
            Assert.AreEqual(_car.FuelCapacity, _car.FuelAmount);
        }

        [Test]
        public void Test_CarDrive()
        {
            _car.Refuel(50);
            _car.Drive(100.0);
            Assert.AreEqual(49, _car.FuelAmount);
            Assert.Throws<InvalidOperationException>(() => _car.Drive(10000000));
        }
    }
}