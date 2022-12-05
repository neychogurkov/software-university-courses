using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private const string GYM_NAME = "My Gym";
        private const int GYM_CAPACITY = 5;

        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym(GYM_NAME, GYM_CAPACITY);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            Assert.AreEqual(GYM_NAME, gym.Name);
            Assert.AreEqual(GYM_CAPACITY, gym.Capacity);

            Assert.DoesNotThrow(() =>
            {
                int count = gym.Count;
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void GymNameSetterShouldThrowExceptionIfValueIsNullOrEmoty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, GYM_CAPACITY);
            });
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-15)]
        public void GymCapacitySetterShouldThrowExceptionIfValueIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym(GYM_NAME, capacity);
            });
        }

        [Test]
        public void AddAthleteShouldAddAthletesToACollection()
        {
            int expectedCount = 5;

            for (int i = 1; i <= expectedCount; i++)
            {
                Athlete athlete = new Athlete($"Athlete{i}");
                gym.AddAthlete(athlete);
            }

            Assert.AreEqual(expectedCount, gym.Count);
        }

        [Test]
        public void AddAthleteShouldThrowExceptionIfGymIsFull()
        {
            for (int i = 1; i <= 5; i++)
            {
                Athlete athlete = new Athlete($"Athlete{i}");
                gym.AddAthlete(athlete);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Athlete athlete = new Athlete("Athlete6");
                gym.AddAthlete(athlete);
            });
        }

        [Test]
        public void RemoveAthleteShouldRemoveAthletesFromTheCollection()
        {
            int addedAthletes = 5;

            for (int i = 1; i <= addedAthletes; i++)
            {
                Athlete athlete = new Athlete($"Athlete{i}");
                gym.AddAthlete(athlete);
            }

            int removedAthletes = 4;

            for (int i = 1; i <= removedAthletes; i++)
            {
                gym.RemoveAthlete($"Athlete{i}");
            }

            Assert.AreEqual(addedAthletes - removedAthletes, gym.Count);
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionIfAthleteDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Athlete athlete = new Athlete($"Athlete{i}");
                gym.AddAthlete(athlete);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Athlete6");
            });
        }

        [Test]
        public void InjureAthleteShouldSetIsInjuredPropertyToTrue()
        {
            Athlete athlete = new Athlete($"Athlete");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Athlete");

            Assert.AreEqual(athlete.IsInjured, gym.InjureAthlete("Athlete").IsInjured);
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionIfAthleteDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                Athlete athlete = new Athlete($"Athlete{i}");
                gym.AddAthlete(athlete);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Athlete6");
            });
        }

        [Test]
        public void ReportShouldReturnCorrectMessage()
        {
            List<Athlete> athletes = new List<Athlete>();

            for (int i = 1; i <= 5; i++)
            {
                Athlete athlete = new Athlete($"Athlete{i}");
                gym.AddAthlete(athlete);
                athletes.Add(athlete);
            }

            for (int i = 1; i >= 3; i++)
            {
                gym.InjureAthlete($"Athlete{i}");
                athletes.Remove(athletes.FirstOrDefault(a=> a.FullName == $"Athlete{i}"));
            }

            var athletesNames = athletes.Select(a => a.FullName).ToList();

            string expectedMessage = $"Active athletes at {gym.Name}: {string.Join(", ", athletesNames)}";

            Assert.AreEqual(expectedMessage, gym.Report());
        }
    }
}
