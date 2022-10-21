using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model) => this.data.Remove(GetCar(manufacturer, model));

        public Car GetLatestCar() => this.data.OrderByDescending(c => c.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model) => this.data.Find(c => c.Manufacturer == manufacturer && c.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
