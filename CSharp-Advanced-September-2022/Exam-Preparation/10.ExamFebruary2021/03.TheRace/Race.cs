using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.data = new List<Racer>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Racer Racer)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(Racer);
            }
        }

        public bool Remove(string name) => this.data.Remove(GetRacer(name));

        public Racer GetOldestRacer() => this.data.OrderByDescending(r => r.Age).FirstOrDefault();

        public Racer GetRacer(string name) => this.data.Find(r => r.Name == name);

        public Racer GetFastestRacer() => this.data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in this.data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
