namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const string DEFAULT_NAME = "Sam";
        private const int DEFAULT_DAMAGE = 40;
        private const int DEFAULT_HP = 100;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(DEFAULT_NAME, DEFAULT_DAMAGE, DEFAULT_HP);
        }

        [Test]
        public void Test_ConstructorShouldSetCorrectValues()
        {
            Assert.AreEqual(DEFAULT_NAME, warrior.Name);
            Assert.AreEqual(DEFAULT_DAMAGE, warrior.Damage);
            Assert.AreEqual(DEFAULT_HP, warrior.HP);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_NameSetterShouldThrowExceptionIfValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, DEFAULT_DAMAGE, DEFAULT_HP);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Test_DamageSetterShouldThrowExceptionIfValueIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(DEFAULT_NAME, damage, DEFAULT_HP);
            });
        }

        [Test]
        public void Test_HPSetterShouldThrowExceptionIfValueIsNegative()
        {
            int hp = -5;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(DEFAULT_NAME, DEFAULT_DAMAGE, hp);
            });
        }

        [Test]
        public void Test_WarriorWithLowHPCannotAttackOtherWarriors()
        {
            int warriorHP = 20;
            Warrior warrior = new Warrior(DEFAULT_NAME, DEFAULT_DAMAGE, warriorHP);
            Warrior defender = new Warrior("John", 10, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            });
        }

        [Test]
        public void Test_DefenderWithLowHPCannotBeAttacked()
        {
            Warrior defender = new Warrior("John", 10, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            });
        }

        [Test]
        public void Test_WarriorCannotAttackStrongerWarriors()
        {
            Warrior defender = new Warrior("John", 120, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            });
        }

        [Test]
        public void Test_WarriorHPShouldBeReducedAfterSuccessfulAttack()
        {
            Warrior defender = new Warrior("John", 60, 50);
            int expectedHP = warrior.HP - defender.Damage;
            warrior.Attack(defender);

            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [Test]
        public void Test_DefenderHPShouldBecomeZeroIfHisHPIsLessThanAttackerDamage()
        {
            Warrior defender = new Warrior("John", 10, 35);
            int expectedHP = 0;
            warrior.Attack(defender);

            Assert.AreEqual(expectedHP, defender.HP);
        }

        [Test]
        public void Test_DefenderHPShouldBeReducedAfterAttack()
        {
            Warrior defender = new Warrior("John", 20, 60);
            int expectedHP = defender.HP - warrior.Damage;
            warrior.Attack(defender);

            Assert.AreEqual(expectedHP, defender.HP);
        }
    }
}