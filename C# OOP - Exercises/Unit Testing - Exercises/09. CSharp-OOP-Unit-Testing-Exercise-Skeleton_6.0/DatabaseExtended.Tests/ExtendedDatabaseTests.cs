using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person _person;
        private Database _databaseExtended;
        private Person[] _people;

        [SetUp]
        public void Inital()
        {
            _person = new Person(100, "Ivan");
            _databaseExtended = new Database();
            _people = new Person[16]
            {
                new Person(10, "A"),
                new Person(11, "B"),
                new Person(12, "C"),
                new Person(13, "D"),
                new Person(14, "E"),
                new Person(15, "F"),
                new Person(16,"G"),
                new Person(17,"J"),
                new Person(18, "A1"),
                new Person(19, "B1"),
                new Person(20, "C1"),
                new Person(21, "D1"),
                new Person(22, "E1"),
                new Person(23, "F1"),
                new Person(24,"G1"),
                new Person(25,"J1"),

            };

        }

        [Test]
        public void Test_AddPeople_ShouldAddInDatabase()
        {
            _databaseExtended.Add(_person);

            Assert.AreEqual(1, _databaseExtended.Count); 
        }

        [Test]
        public void Test_AddRangeOfPeople_ShouldAddThem()
        {
            var database = new Database();
            foreach (Person person in _people)
            {
                database.Add(person);
            }

            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void Test_AddMoreThan17Persons_ShouldTrowException()
        {
            var database = new Database();
            foreach (Person person in _people)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(_person));

        }

        [Test]
        public void Test_AddPersonWithExistingName_ShouldTrowException()
        {
            var person = new Person(1010, "Ivan");

            _databaseExtended.Add(_person);

            Assert.Throws<InvalidOperationException>(() => _databaseExtended.Add(person));
        }

        [Test]
        public void Test_AddPersonWithExistingId_ShouldTrowException()
        {
            var person = new Person(100, "Ivan1");

            _databaseExtended.Add(_person);

            Assert.Throws<InvalidOperationException>(() => _databaseExtended.Add(person));
        }

        [Test]
        public void Test_RemovePersonFromDatabase()
        {
            _databaseExtended.Add(_person);
            _databaseExtended.Add(new Person(101010,"FGH"));

            _databaseExtended.Remove();

            Assert.AreEqual(1,_databaseExtended.Count);
        }

        [Test]
        public void Test_RemoveAllPersonsInDatabase_ShouldTrowException()
        {

            Assert.Throws<InvalidOperationException>(() => _databaseExtended.Remove());
        }

        [Test]
        public void Test_FinedUserByUsername_ShouldReturnPerson()
        {
            _databaseExtended.Add(_person);

            Assert.IsNotNull(_databaseExtended.FindByUsername("Ivan"));
        }

        [Test]
        public void Test_FindUserWithNullUsername_ShouldTrowException()
        {
            
            Assert.Throws<ArgumentNullException>(() => _databaseExtended.FindByUsername(null));
        }

        [Test]
        public void Test_FindUsernameWithNotExistUsername_ShouldTrowException()
        {
            _databaseExtended.Add(_person);

            Assert.Throws<InvalidOperationException>(() => _databaseExtended.FindByUsername("Kolio"));
        }

        [Test]
        public void Test_FindUserById()
        {
            _databaseExtended.Add(_person);
            Assert.IsNotNull(_databaseExtended.FindById(100));
        }

        [Test]
        public void Test_FindUserByIdThatIsNegative_ShouldTrowException()
        {
            _databaseExtended.Add(_person);
            Assert.Throws<ArgumentOutOfRangeException>(()=>_databaseExtended.FindById(-100));
        }


        [Test]
        public void Test_FindUserByIdThatIsNotExist_ShouldTrowException()
        {
            _databaseExtended.Add(_person);
            Assert.Throws<InvalidOperationException>(() => _databaseExtended.FindById(10000000));
        }
    }

}