namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_ConstructorShouldInitializeWarriorsCollection()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_CountGetterShouldReturnTheCorrectCountOfWarriors()
        {
            int warriorsCount = 5;

            for (int i = 1; i <= warriorsCount; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", 15 * i, 31 * i);
                arena.Enroll(warrior);
            }

            Assert.AreEqual(warriorsCount, arena.Count);
        }

        [Test]
        public void Test_EnrollShouldAddWarriorsToACollection()
        {
            List<Warrior> warriors = new List<Warrior>();

            for (int i = 1; i <= 5; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", 15 * i, 31 * i);
                warriors.Add(warrior);
                arena.Enroll(warrior);
            }

            CollectionAssert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void Test_EnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            for (int i = 1; i <= 5; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", 15 * i, 31 * i);
                arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Warrior warrior = new Warrior("Warrior3", 50, 100);
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void Test_FightShouldThrowExceptionIfTheAttackerDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", 15 * i, 31 * i);
                arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Warrior", "Warrior1");
            });
        }

        [Test]
        public void Test_FightShouldThrowExceptionIfTheDefenderDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Warrior warrior = new Warrior($"Warrior{i}", 15 * i, 31 * i);
                arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Warrior3", "Warrior");
            });
        }

        [Test]
        public void Test_AttackerShouldAttackDefender()
        {
            Warrior warrior2 = new Warrior("Warrior1", 45, 90);
            arena.Enroll(warrior2);
            Warrior warrior1 = new Warrior("Warrior2", 30, 60);
            arena.Enroll(warrior1);
            int expectedAttackerHP = warrior2.HP - warrior1.Damage;
            int expectedDefenderHP = warrior1.HP - warrior2.Damage;

            arena.Fight("Warrior2", "Warrior1");

            Assert.AreEqual(expectedAttackerHP, warrior2.HP);
            Assert.AreEqual(expectedDefenderHP, warrior1.HP);
        }
    }
}
