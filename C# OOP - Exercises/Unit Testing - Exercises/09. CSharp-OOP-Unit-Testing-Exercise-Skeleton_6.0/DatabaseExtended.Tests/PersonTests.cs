using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PersonTests
    {
        private Person person;
        [SetUp]
        public void InitialPerson()
        {
            person = new Person(5, "Ivan");
        }

        [Test]
        public void TestPerson()
        {
            Assert.AreEqual(5,person.Id);
            Assert.AreEqual("Ivan", person.UserName);
        }

    }
}
