namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public void AddNew(IHotel hotel)
        {
            this.hotels.Add(hotel);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return (IReadOnlyCollection<IHotel>)hotels;
        }

        public IHotel Select(string hotelName)
        {
            return this.hotels.FirstOrDefault(h => h.FullName == hotelName);
        }
    }
}
