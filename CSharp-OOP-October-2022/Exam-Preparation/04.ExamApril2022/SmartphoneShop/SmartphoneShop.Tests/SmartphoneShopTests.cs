using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private const int CAPACITY = 5;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            shop = new Shop(CAPACITY);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            Assert.AreEqual(CAPACITY, shop.Capacity);
            Assert.DoesNotThrow(() =>
            {
                int capacity = shop.Count;
            });
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-15)]
        public void CapacitySetterShouldThrowExceptionIfValueIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            });
        }

        [Test]
        public void AddShouldAddSmartphonesToACollection()
        {
            int expectedCount = 5;

            for (int i = 1; i <= expectedCount; i++)
            {
                Smartphone smartphone = new Smartphone($"Smartphone{i}", i * 5);
                shop.Add(smartphone);
            }

            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfModelAlreadyExists()
        {
            for (int i = 1; i <= 3; i++)
            {
                Smartphone smartphone = new Smartphone($"Smartphone{i}", i * 20);
                shop.Add(smartphone);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Smartphone2", 50));
            });
        }

        [Test]
        public void AddShouldThrowExceptionIfShopIsFull()
        {
            for (int i = 1; i <= 5; i++)
            {
                Smartphone smartphone = new Smartphone($"Smartphone{i}", i * 20);
                shop.Add(smartphone);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Smartphone6", 120));
            });
        }

        [Test]
        public void RemoveShouldRemoveSmartphoneFromTheCollection()
        {
            int addCount = 5;
            for (int i = 1; i <= addCount; i++)
            {
                Smartphone smartphone = new Smartphone($"Smartphone{i}", i * 20);
                shop.Add(smartphone);
            }

            int removeCount = 3;
            for (int i = 1; i <= removeCount; i++)
            {
                shop.Remove($"Smartphone{i}");
            }

            Assert.AreEqual(addCount - removeCount, shop.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfModelDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove($"Smartphone");
            });
        }

        [Test]
        public void TestPhoneShouldReducePhoneBatteryCharge()
        {
            int batteryCharge = 100;
            Smartphone smartphone = new Smartphone("iPhone 14 Pro Max", batteryCharge);
            shop.Add(smartphone);

            int batteryUsage = 25;
            shop.TestPhone("iPhone 14 Pro Max", batteryUsage);

            Assert.AreEqual(batteryCharge - batteryUsage, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneShouldThrowExceptionIfPhoneModelDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("iPhone 14 Pro Max", 25);
            });
        }

        [Test]
        public void TestPhoneShouldThrowExceptionIfBatteryIsNotEnough()
        {
            int batteryCharge = 100;
            Smartphone smartphone = new Smartphone("iPhone 14 Pro Max", batteryCharge);
            shop.Add(smartphone);

            int batteryUsage = 110;
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("iPhone 14 Pro Max", batteryUsage);
            });
        }

        [Test]
        public void ChargePhoneShouldSetBatteryChargeToMaximum()
        {
            int batteryCharge = 100;
            Smartphone smartphone = new Smartphone("iPhone 14 Pro Max", batteryCharge);
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 25);
            shop.ChargePhone(smartphone.ModelName);

            Assert.AreEqual(batteryCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneShouldThrowExceptionIfPhoneModelDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("iPhone 14 Pro Max");
            });
        }
    }
}