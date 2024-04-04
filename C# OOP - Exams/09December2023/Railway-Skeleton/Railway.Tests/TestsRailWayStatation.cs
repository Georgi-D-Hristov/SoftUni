namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestsRailWayStatation

    {
        [Test]
        public void Test_CtorInitialObjectCorrect()
        {
            var station = new RailwayStation("Garata");
            Assert.NotNull(station);
            Assert.AreEqual("Garata", station.Name);
            Assert.IsEmpty(station.ArrivalTrains);
            Assert.IsEmpty(station.DepartureTrains);
        }

        [Test]
        public void Test_CreateStationWithNOKName()
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(null));
            Assert.Throws<ArgumentException>(() => new RailwayStation(""));
        }
        [Test]
        public void Test_AddingTrain ()
        {
            var station = new RailwayStation("Garata");
            station.NewArrivalOnBoard("ZaPernik");

            Assert.AreEqual(1, station.ArrivalTrains.Count);
        }

        [Test]
        public void Test_TrainHasArrived()
        {
            var station = new RailwayStation("Garata");
            station.NewArrivalOnBoard("ZaPernik");
            //station.TrainHasArrived("ZaPernik");

            Assert.AreEqual("ZaPernik", station.ArrivalTrains.Peek());
            Assert.AreNotEqual($"There are other trains to arrive before {"ZaPernik"}.", station.TrainHasArrived("ZaPernik"));
        //    Assert.AreNotEqual("ZaPernik is on the platform and will leave in 5 minutes.", station.TrainHasArrived("ZaPernik"));
        }
    }
}
