using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private const string PLANET_NAME = "Venus";
            private const double PLANET_BUDGET = 200.5;

            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet(PLANET_NAME, PLANET_BUDGET);
            }

            [Test]
            public void WeaponConstructorShouldInitializeData()
            {
                string name = "Excalibur";
                double price = 100;
                int destructionLevel = 5;

                Weapon weapon = new Weapon(name, price, destructionLevel);

                Assert.AreEqual(name, weapon.Name);
                Assert.AreEqual(price, weapon.Price);
                Assert.AreEqual(destructionLevel, weapon.DestructionLevel);
            }

            [TestCase(-1)]
            [TestCase(-5)]
            [TestCase(-20)]
            public void WeaponPriceSetterShouldThrowExceptionIfValueIsNegative(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Excalibur", price, 5);
                });
            }

            [Test]
            public void IncreaseDestructionLevelShouldAdd1ToTheDestructionLevel()
            {
                Weapon weapon = new Weapon("Excalibur", 100, 5);

                for (int i = 0; i < 10; i++)
                {
                    weapon.IncreaseDestructionLevel();
                }

                Assert.AreEqual(15, weapon.DestructionLevel);
            }

            [TestCase(6)]
            [TestCase(10)]
            [TestCase(15)]
            public void IsNuclearShouldReturnTrueIfDestructionLevelIsMoreThanOrEqualTo10(int destructionLevel)
            {
                bool expected = destructionLevel >= 10;

                Weapon weapon = new Weapon("Excalibur", 100, destructionLevel);

                Assert.AreEqual(expected, weapon.IsNuclear);
            }

            [Test]
            public void PlanetConstructorShouldInitializeData()
            {
                Assert.AreEqual(PLANET_NAME, planet.Name);
                Assert.AreEqual(PLANET_BUDGET, planet.Budget);
                Assert.IsNotNull(planet.Weapons);
            }

            [TestCase("")]
            [TestCase(null)]
            public void PlanetNameSetterShouldThrowExceptionIfValueIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, PLANET_BUDGET);
                });
            }

            [TestCase(-1)]
            [TestCase(-5)]
            [TestCase(-12)]
            public void PlanetBudgetSetterShouldThrowExceptionIfValueIsNegative(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(PLANET_NAME, budget);
                });
            }

            [Test]
            public void MilitaryPowerRatioShouldReturnTheSumOfWeaponsDestructionLevel()
            {
                int expectedDestructionLevel = 0;
                for (int i = 1; i <= 5; i++)
                {
                    expectedDestructionLevel += i * 2 - 1;
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    planet.AddWeapon(weapon);
                }

                Assert.AreEqual(expectedDestructionLevel, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitShouldIncreasePlanetBudget()
            {
                double increaseAmount = 20.5;
                double expectedBudget = planet.Budget + increaseAmount;
                planet.Profit(increaseAmount);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldDescreasePlanetBudget()
            {
                double spendAmount = 20.5;
                double expectedBudget = planet.Budget - spendAmount;
                planet.SpendFunds(spendAmount);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldThrowExceptionIfBudgetIsNotEnough()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(250);
                });
            }

            [Test]
            public void AddWeaponShouldAddWeaponsToACollection()
            {
                List<Weapon> weapons = new List<Weapon>();

                for (int i = 1; i <= 5; i++)
                {
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    weapons.Add(weapon);
                    planet.AddWeapon(weapon);
                }

                CollectionAssert.AreEqual(weapons, planet.Weapons);
            }

            [Test]
            public void AddWeaponShouldThrowExceptionIfWeaponWithTheSameNameAlreadyExists()
            {
                List<Weapon> weapons = new List<Weapon>();

                for (int i = 1; i <= 5; i++)
                {
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    weapons.Add(weapon);
                    planet.AddWeapon(weapon);
                }

                Assert.Throws<InvalidOperationException>(() =>
                {
                    Weapon weapon = new Weapon("Weapon4", 50, 100);
                    planet.AddWeapon(weapon);
                });
            }

            [Test]
            public void RemoveWeaponShouldRemoveTheWeaponFromTheCollection()
            {
                List<Weapon> weapons = new List<Weapon>();
               
                for (int i = 1; i <= 5; i++)
                {
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    weapons.Add(weapon);
                    planet.AddWeapon(weapon);
                }

                planet.RemoveWeapon("Weapon2");
                weapons.RemoveAt(1);

                CollectionAssert.AreEqual(weapons, planet.Weapons);
            }

            [Test]
            public void UpgradeWeaponShouldIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("Excalibur", 100, 5);
                planet.AddWeapon(weapon);

                for (int i = 0; i < 5; i++)
                {
                    planet.UpgradeWeapon(weapon.Name);
                }

                Assert.AreEqual(10, weapon.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponShouldThrowExceptionIfWeaponNameDoesNotExist()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    planet.AddWeapon(weapon);
                }

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Weapon6");
                });
            }

            [Test]
            public void DestructOpponentShouldReturnCorrectMessage()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    planet.AddWeapon(weapon);
                }

                Planet opponent = new Planet("Opponent", 100);

                Assert.AreEqual($"{opponent.Name} is destructed!", planet.DestructOpponent(opponent));
            }

            [Test]
            public void DestructOpponentShouldThrowExceptionIfOpponentMilitaryPowerIsMoreThanOrEqual()
            {
                Planet opponent = new Planet("Opponent", 100);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponent);
                });

                List<Weapon> weapons = new List<Weapon>();

                for (int i = 1; i <= 5; i++)
                {
                    Weapon weapon = new Weapon($"Weapon{i}", i * 5, i * 2 - 1);
                    weapons.Add(weapon);
                    opponent.AddWeapon(weapon);
                }

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponent);
                });
            }
        }
    }
}
