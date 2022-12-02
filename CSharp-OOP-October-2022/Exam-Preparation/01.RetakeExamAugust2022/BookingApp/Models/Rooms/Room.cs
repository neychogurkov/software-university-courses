namespace BookingApp.Models.Rooms
{
    using System;

    using Rooms.Contracts;
    using Utilities.Messages;

    public abstract class Room : IRoom
    {
        private double pricePerNight;

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }

        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get
            {
                return this.pricePerNight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
