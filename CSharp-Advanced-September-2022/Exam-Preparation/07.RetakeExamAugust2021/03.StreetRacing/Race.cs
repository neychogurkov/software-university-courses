using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Participants = new List<Car>();
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.Any(c => c.LicensePlate == car.LicensePlate) && this.Participants.Count < this.Capacity && car.HorsePower <= MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate) => this.Participants.Remove(FindParticipant(licensePlate));

        public Car FindParticipant(string licensePlate) => this.Participants.Find(c => c.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar() => this.Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
