namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;

    using Bookings.Contracts;
    using Rooms.Contracts;
    using Utilities.Messages;

    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return this.residenceDuration; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return this.adultsCount; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return this.childrenCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                this.childrenCount = value;
            }
        }
        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Booking number: {this.BookingNumber}")
                .AppendLine($"Room type: {this.Room.GetType().Name}")
                .AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}")
                .AppendLine($"Total amount paid: {this.TotalPaid():F2} $");

            return sb.ToString();
        }

        private double TotalPaid()
        {
            return Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
        }
    }
}
