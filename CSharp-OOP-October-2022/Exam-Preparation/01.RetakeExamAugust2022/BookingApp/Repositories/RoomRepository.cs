namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Rooms.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room)
        {
            this.rooms.Add(room);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return (IReadOnlyCollection<IRoom>)this.rooms;
        }

        public IRoom Select(string roomType)
        {
            return this.rooms.FirstOrDefault(r => r.GetType().Name == roomType);
        }
    }
}
