using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena _arena;
        private Warrior _attacker;
        private Warrior _attacker2;
        private Warrior _difendder;
        private Warrior _difender2;

        [SetUp]
        public void Initial()
        {
            _arena = new Arena();
            _attacker = new Warrior("atack", 10, 100);
            _attacker2 = new Warrior("atack1", 10, 100);
            _difendder = new Warrior("difen", 10, 100);
            _difender2 = new Warrior("difen1", 10, 100);
        }

        [Test]
        public void Test_ArenaEnrollWarriars()
        {
            _arena.Enroll(_attacker);

            Assert.AreEqual(1, _arena.Count);
            Assert.Throws<InvalidOperationException>(() => _arena.Enroll(_attacker));
        }

        [Test]
        public void Test_ArenaFight()
        {
            _arena.Enroll(_attacker);
            _arena.Enroll(_difendder);
            _arena.Fight(_attacker.Name, _difendder.Name);

            Assert.Throws<InvalidOperationException>(() => _arena.Fight(_attacker.Name, _difender2.Name));
        }

        [Test]
        public void Test_ArenaWarriarsList()
        {
            _arena.Enroll(_attacker);
            _arena.Enroll(_attacker2);
            _arena.Enroll(_difendder);
            _arena.Enroll(_difender2);

            Assert.AreEqual(4, _arena.Warriors.Count);
        }
    }
}