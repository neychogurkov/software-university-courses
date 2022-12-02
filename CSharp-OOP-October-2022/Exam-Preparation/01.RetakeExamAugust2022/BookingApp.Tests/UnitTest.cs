using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class Tests
    {
        private const string DEFAULT_FULL_NAME = "InterContinental Sofia";
        private const int DEFAULT_CATEGORY = 5;

        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel(DEFAULT_FULL_NAME, DEFAULT_CATEGORY);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            Assert.AreEqual(DEFAULT_FULL_NAME, hotel.FullName);
            Assert.AreEqual(DEFAULT_CATEGORY, hotel.Category);
            Assert.NotNull(hotel.Rooms);
            Assert.NotNull(hotel.Bookings);
        }

        [TestCase("")]
        [TestCase("             ")]
        [TestCase(null)]
        public void FullNameSetterShouldThrowExceptionIfValueIsNullOrWhitespace(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(fullName, DEFAULT_CATEGORY);
            });
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(6)]
        [TestCase(15)]
        public void CategorySetterShouldThrowExceptionIfValueIsLessThan1OrMoreThan5(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel(DEFAULT_FULL_NAME, category);
            });
        }

        [Test]
        public void TurnoverGetterShouldReturnZeroIfItIsNotSet()
        {
            Assert.AreEqual(0, hotel.Turnover);
        }
        [Test]
        public void TurnoverShouldIncreaseIfNewBookingIsAdded()
        {
            Assert.AreEqual(0, hotel.Turnover);
            hotel.AddRoom(new Room(6, 300));
            hotel.BookRoom(3, 2, 5, 2000);
            Assert.AreEqual(1500, hotel.Turnover);
        }

        [Test]
        public void AddRoomsShouldAddRoomsToACollection()
        {
            List<Room> rooms = new List<Room>();

            for (int i = 1; i <= 6; i++)
            {
                Room room = new Room(i * 2, i * 80);
                rooms.Add(room);
                hotel.AddRoom(room);
            }

            CollectionAssert.AreEqual(rooms, hotel.Rooms);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-7)]
        public void BookRoomShouldThrowExceptionIfAdultsCountIsZeroOrNegative(int adultsCount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adultsCount, 5, 3, 1000);
            });
        }

        [TestCase(-1)]
        [TestCase(-7)]
        public void BookRoomShouldThrowExceptionIfChildrenCountIsNegative(int childrenCount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, childrenCount, 3, 1000);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-7)]
        public void BookRoomShouldThrowExceptionIfResidenceDurationIsLessThan1(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 1, residenceDuration, 1000);
            });
        }

        [Test]
        public void BookRoomShouldAddNewBookingIfItIsSuccessful()
        {
            hotel.AddRoom(new Room(6, 250));
            hotel.AddRoom(new Room(2, 100));
            hotel.AddRoom(new Room(4, 170));

            hotel.BookRoom(3, 2, 5, 2000);
            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void BookingShouldFailIfBudgetIsNotEnough()
        {
            hotel.AddRoom(new Room(6, 400));

            hotel.BookRoom(3, 2, 5, 1500);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }
    }
}