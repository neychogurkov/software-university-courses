namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class RobotsTests
    {
        private const int CAPACITY = 5;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(CAPACITY);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            Assert.AreEqual(CAPACITY, robotManager.Capacity);
            Assert.DoesNotThrow(() =>
            {
                int count = robotManager.Count;
            });
        }

        [TestCase(-1)]
        [TestCase(-7)]
        [TestCase(-15)]
        public void CapacitySetterShouldThrowExceptionIfValueIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            });
        }

        [Test]
        public void AddShouldAddRobotsToACollection()
        {
            int expectedCount = 5;

            for (int i = 1; i <= expectedCount; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            Assert.AreEqual(expectedCount, robotManager.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfRobotWithTheSameNameExists()
        {
            for (int i = 1; i <= 4; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Robot robot = new Robot("Robot2", 20);
                robotManager.Add(robot);
            });
        }

        [Test]
        public void AddShouldThrowExceptionIfCapacityIsNotEnough()
        {
            for (int i = 1; i <= 5; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Robot robot = new Robot("Robot", 100);
                robotManager.Add(robot);
            });
        }

        [Test]
        public void RemoveShouldRemoveRobotsFromTheCollection()
        {
            int addedRobots = 5;

            for (int i = 1; i <= addedRobots; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            int removedRobots = 3;

            for (int i = removedRobots; i <= removedRobots + 2; i++)
            {
                robotManager.Remove($"Robot{i}");
            }

            Assert.AreEqual(addedRobots - removedRobots, robotManager.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfNameDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Robot");
            });
        }

        [Test]
        public void WorkShouldReduceRobotBattery()
        {
            List<Robot> robots = new List<Robot>();

            for (int i = 1; i <= 5; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robots.Add(robot);
                robotManager.Add(robot);
            }

            Robot workingRobot = robots.Last();
            int initialBattery = workingRobot.Battery;
            int batteryUsage = 50;
            robotManager.Work("Robot5", "Programmer", batteryUsage);

            Assert.AreEqual(initialBattery - batteryUsage, workingRobot.Battery);
        }

        [Test]
        public void WorkShouldThrowExceptionIfNameDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robot", "Job", 20);
            });
        }

        [Test]
        public void WorkShouldThrowExceptionIfBatteryIsNotEnough()
        {
            Robot robot = new Robot($"Robot", 50);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robot", "Job", 100);
            });
        }

        [Test]
        public void ChargeShouldSetRobotBatteryToMaximumBattery()
        {
            int maximumBattery = 100;
            Robot robot = new Robot($"Robot", maximumBattery);
            robotManager.Add(robot);
            int batteryUsage = 80;
            robotManager.Work("Robot", "Job", batteryUsage);

            robotManager.Charge("Robot");
            
            Assert.AreEqual(maximumBattery, robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowExceptionIfNameDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Robot robot = new Robot($"Robot{i}", i * 25);
                robotManager.Add(robot);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Robot");
            });
        }
    }
}
