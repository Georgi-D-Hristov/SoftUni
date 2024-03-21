namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior _warriorAtacker;
        private Warrior _warriorDifencer;

        [SetUp]
        public void Initial()
        {
            _warriorAtacker = new Warrior("Atacker", 10, 100);
            _warriorDifencer = new Warrior("Difender", 10, 100);
        }

        [Test]
        public void Test_CreateWarrior_ShouldBeCreateWithCorrectProperties()
        {
            var warrior = new Warrior("Go", 10, 100);

            Assert.AreEqual("Go", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void Test_CreateWarriorWithNullOrWhiteSpaceName_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 10, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 100));
        }

        [Test]
        public void Test_CreateWarriorWithNegativeDamage_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Go", -10, 100));
        }

        [Test]
        public void Test_CreateWarriorWithNegativeHP_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Go", 10, -100));
        }

        [Test]
        public void Test_AtackAction_ShouldDecriseHP_ofDifender()
        {
            _warriorAtacker.Attack(_warriorDifencer);

            Assert.AreEqual(90, _warriorDifencer.HP);
        }

        [Test]
        public void Test_AtackWithHP_LowerThen30_ShouldTrow()
        {
            var warrior = new Warrior("Lo", 10, 29);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(_warriorAtacker));
        }

        [Test]
        public void Test_AtackWarriorWithHP_LowerThen30_ShouldTrow()
        {
            var warrior = new Warrior("Lo", 10, 29);

            Assert.Throws<InvalidOperationException>(() => _warriorAtacker.Attack(warrior));
        }

        [Test]
        public void Test_AtackTooPowerfullWarrior__ShouldTrow()
        {
            var warrior = new Warrior("Lo", 200, 200);

            Assert.Throws<InvalidOperationException>(() => _warriorAtacker.Attack(warrior));
        }

        [Test]
        public void Test_AtackAction_ShouldDecriseHPtoZero_ofDifender()
        {
            var attacker = new Warrior("God", 1000, 1000);
            attacker.Attack(_warriorDifencer);

            Assert.AreEqual(0, _warriorDifencer.HP);
        }
    }
}