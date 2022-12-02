namespace BookingApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Bookings;
    using Models.Bookings.Contracts;
    using Models.Hotels;
    using Models.Hotels.Contacts;
    using Models.Rooms;
    using Models.Rooms.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (this.hotels.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            this.hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = this.hotels.All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName)
                .ToList();

            if (orderedHotels.Count == 0)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            ICollection<IRoom> rooms = new List<IRoom>();

            foreach (var hotel in orderedHotels)
            {
                foreach (var room in hotel.Rooms.All().Where(r => r.PricePerNight > 0))
                {
                    rooms.Add(room);
                }
            }

            rooms = rooms.OrderBy(r => r.BedCapacity).ToList();

            IRoom appropriateRoom = rooms.Where(r => r.BedCapacity >= adults + children).FirstOrDefault();
            if (appropriateRoom == null)
            {
                return OutputMessages.RoomNotAppropriate;
            }

            IHotel appropriateHotel = orderedHotels.FirstOrDefault(h => h.Rooms.All().Contains(appropriateRoom));
            int bookingNumber = appropriateHotel.Bookings.All().Count + 1;
            IBooking booking = new Booking(appropriateRoom, duration, adults, children, bookingNumber);
            appropriateHotel.Bookings.AddNew(booking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, appropriateHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}")
                .AppendLine($"--{hotel.Category} star hotel")
                .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
                .AppendLine("--Bookings:")
                .AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }
            if (hotel.Rooms.Select(roomTypeName).PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            foreach (var room in hotel.Rooms.All().Where(r => r.GetType().Name == roomTypeName))
            {
                room.SetPrice(price);
            }

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }
            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;
            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}