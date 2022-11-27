namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string DEFAULT_MAKE = "Mercedes-Benz";
        private const string DEFAULT_MODEL= "AMG GT 63S";
        private const double DEFAULT_FUEL_CONSUMPTION = 10;
        private const double DEFAULT_FUEL_CAPACITY = 100;
        private const double DEFAULT_FUEL_AMOUNT = 0;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(DEFAULT_MAKE, DEFAULT_MODEL, DEFAULT_FUEL_CONSUMPTION, DEFAULT_FUEL_CAPACITY);
        }

        [Test]
        public void Test_ConstructorShoudInitializeCarWithCorrrectData()
        {
            Assert.AreEqual(DEFAULT_MAKE, car.Make);
            Assert.AreEqual(DEFAULT_MODEL, car.Model);
            Assert.AreEqual(DEFAULT_FUEL_CONSUMPTION, car.FuelConsumption);
            Assert.AreEqual(DEFAULT_FUEL_CAPACITY, car.FuelCapacity);
            Assert.AreEqual(DEFAULT_FUEL_AMOUNT, car.FuelAmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_MakeSetterShouldThrowExceptionIfValueIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, DEFAULT_MODEL, DEFAULT_FUEL_CONSUMPTION, DEFAULT_FUEL_CAPACITY);
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_ModelSetterShouldThrowExceptionIfValueIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(DEFAULT_MAKE, model, DEFAULT_FUEL_CONSUMPTION, DEFAULT_FUEL_CAPACITY);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Test_FuelConsumptionSetterShouldThrowExceptionIfValueIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(DEFAULT_MAKE, DEFAULT_MODEL, fuelConsumption, DEFAULT_FUEL_CAPACITY);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Test_FuelCapacitySetterShouldThrowExceptionIfValueIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(DEFAULT_MAKE, DEFAULT_MODEL, DEFAULT_FUEL_CONSUMPTION, fuelCapacity);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Test_RefuelShouldThrowExceptionIfFuelToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void Test_RefuelShouldIncreaseFuelAmount()
        {
            int expectedFuelAmount = 50;
            car.Refuel(expectedFuelAmount);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void Test_FuelAmountShouldNotExceedFuelCapacityAfterRefuel()
        {
            int fuelToRefuel = 120;
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(DEFAULT_FUEL_CAPACITY, car.FuelAmount);
        }

        [Test]
        public void Test_DriveShouldReduceFuelAmount()
        {
            car.Refuel(100);
            int distanceToTravel = 200;
            double expectedFuelAmount = car.FuelAmount - (distanceToTravel / 100) * car.FuelConsumption;
            car.Drive(distanceToTravel);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void Test_DriveShouldThrowExceptionIfFuelAmountIsNotEnough()
        {
            car.Refuel(100);
            int distanceToTravel = 1500;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distanceToTravel);
            });
        }
    }
}