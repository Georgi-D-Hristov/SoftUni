namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_CtorInitialObjectCorrect()
        {
            var station = new RailwayStation("Garata");
            Assert.NotNull(station);
            Assert.AreEqual("Garata", station.Name);
            Assert.IsEmpty(station.ArrivalTrains);
            Assert.IsEmpty(station.DepartureTrains);
        }
    }
}