namespace BookingApp.Models.Hotels
{
    using System;
    using System.Linq;

    using Bookings.Contracts;
    using Rooms.Contracts;
    using Hotels.Contacts;
    using Repositories.Contracts;
    using Utilities.Messages;
    using BookingApp.Repositories;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get { return this.category; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                this.category = value;
            }
        }
        public double Turnover => this.Bookings.All().Sum(b => Math.Round(b.ResidenceDuration * b.Room.PricePerNight, 2));

        public IRepository<IRoom> Rooms => this.rooms;

        public IRepository<IBooking> Bookings => this.bookings;
    }
}
