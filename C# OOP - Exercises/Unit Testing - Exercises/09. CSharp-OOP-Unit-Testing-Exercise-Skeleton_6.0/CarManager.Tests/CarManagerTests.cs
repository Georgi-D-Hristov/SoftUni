namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car _car;

        [SetUp]
        public void Initial()
        {
            _car = new Car("VW", "Golf4", 6, 55);

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
            Assert.Throws<ArgumentException>(() => _car.FuelAmount=1);
        }
        [Test]
        public void Test_CarWithZeroOrNegatoveFuelConsumption()
        {

        }
    }
}