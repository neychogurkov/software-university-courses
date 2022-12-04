using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private const string GARAGE_NAME = "My Garage";
            private const int COUNT_OF_MECHANICS_AVAILABLE = 5;
            private Garage garage;

            [SetUp]
            public void Setup()
            {
                garage = new Garage(GARAGE_NAME, COUNT_OF_MECHANICS_AVAILABLE);
            }

            [Test] 
            public void ConstructorShouldInitializeData()
            {
                Assert.AreEqual(GARAGE_NAME, garage.Name);
                Assert.AreEqual(COUNT_OF_MECHANICS_AVAILABLE, garage.MechanicsAvailable);
                Assert.IsNotNull(garage.CarsInGarage);
            }

            [TestCase("")]
            [TestCase(null)]
            public void GarageNameSetterShouldThrowExceptionIfValueIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, COUNT_OF_MECHANICS_AVAILABLE);
                });
            }

            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-5)]
            public void MechanicsAvailableSetterShouldThrowExceptionIsZeroOrNegative(int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage(GARAGE_NAME, mechanicsAvailable);
                });
            }

            [Test]
            public void AddCarShouldAddCarsToACollection()
            {
                int expectedCount = 4;

                for (int i = 1; i <= expectedCount; i++)
                {
                    Car car = new Car($"Car{i}", i);
                    garage.AddCar(car);
                }

                Assert.AreEqual(expectedCount, garage.CarsInGarage);
            }

            [Test]
            public void AddCarShouldThrowExceptionIfThereIsNotAnAvailableMechanic()
            {
                for (int i = 1; i <= COUNT_OF_MECHANICS_AVAILABLE; i++)
                {
                    Car car = new Car($"Car{i}", i);
                    garage.AddCar(car);
                }

                Assert.Throws<InvalidOperationException>(() =>
                {
                    Car car = new Car("MyCar", 2);
                    garage.AddCar(car);
                });
            }

            [Test]
            public void CarFixShouldSetNumberOfIssuesTo0()
            {
                Car car = new Car("MyCar", 2);
                garage.AddCar(car);

                Assert.AreEqual(0, garage.FixCar("MyCar").NumberOfIssues);
            }

            [Test]
            public void CarFixShouldThrowExceptionIfTheCarDoesNotExist()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Car");
                });
            }

            [Test]
            public void RemoveFixedCarShouldRemoveAllFixedCarsFromTheCollection()
            {
                List<Car> cars = new List<Car>();

                for (int i = 1; i <= 3; i++)
                {
                    Car car = new Car($"Car{i}", 0);
                    garage.AddCar(car);
                    cars.Add(car);
                }
                for (int i = 1; i <= 2; i++)
                {
                    Car car = new Car($"Car{i}", i);
                    garage.AddCar(car);
                    cars.Add(car);
                }

                int carsToRemove = cars.Count(c => c.IsFixed);

                Assert.AreEqual(carsToRemove, garage.RemoveFixedCar());
            }

            [Test]
            public void RemoveFixedCarShouldThrowExceptionIfThereAreNotFixedCars()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Car car = new Car($"Car{i}", i);
                    garage.AddCar(car);
                }

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void ReportShouldReturnCorrectMessage()
            {
                List<string> models = new List<string>();

                for (int i = 1; i <= 3; i++)
                {
                    Car car = new Car($"Car{i}", i);
                    models.Add(car.CarModel);
                    garage.AddCar(car);
                }
                for (int i = 1; i <= 2; i++)
                {
                    Car car = new Car($"Car{i}", 0);
                    models.Add(car.CarModel);
                    garage.AddCar(car);
                }
                var notFixedModels = models.Take(3).ToList();
                string expectedMessage = $"There are {notFixedModels.Count} which are not fixed: {string.Join(", ", models.Take(3))}.";
                Assert.AreEqual(expectedMessage, garage.Report());
            }
        }
    }
}