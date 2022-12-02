namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking booking)
        {
            this.bookings.Add(booking);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return (IReadOnlyCollection<IBooking>)this.bookings;
        }

        public IBooking Select(string bookingNumber)
        {
            return this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumber);
        }
    }
}
