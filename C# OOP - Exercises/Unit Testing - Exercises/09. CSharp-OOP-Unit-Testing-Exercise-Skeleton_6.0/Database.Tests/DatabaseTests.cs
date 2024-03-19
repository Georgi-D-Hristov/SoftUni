using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void TestInitialize()
        {
            database = new Database();
        }

        [Test]
        public void Test_AddElement_ShouldIncreaseCount()
        {
            database.Add(1);
            database.Add(2);

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void Test_AddSeventeenElements_ShouldTrowExeption()
        {
            for (int i = 1; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
                database.Add(17)
                );
        }

        [Test]
        public void Test_RemoveElement_ShouldDecreaseCount()
        {
            database.Add(1);
            database.Add(2);

            database.Remove();

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void Test_RemoveTheLastElement_ShouldTrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove()
            );
        }

        [Test]
        public void Test_Constructor_ShouldCreateDatabase_WithElements()
        {
            var initialDatabase = new Database(1, 2, 3);

            Assert.AreEqual(3, initialDatabase.Count);
        }

        [Test]
        public void Test_Fech_ShouldReturn_DatabaseCopy()
        {
            var currebtDatabase = new Database(1, 2, 100, 300, -10);
            var data = new int[] { 1, 2, 100, 300, -10 };

            var fechDatabase = currebtDatabase.Fetch();

            Assert.IsNotNull(fechDatabase);
            Assert.AreNotSame(currebtDatabase, fechDatabase);

            Assert.AreEqual(fechDatabase, data);
        }
    }
}