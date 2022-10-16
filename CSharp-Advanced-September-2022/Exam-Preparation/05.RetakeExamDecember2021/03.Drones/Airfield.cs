using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Drones = new List<Drone>();
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
        }

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (this.Drones.Count == this.Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                this.Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name) => this.Drones.Remove(this.Drones.Find(d => d.Name == name));

        public int RemoveDroneByBrand(string brand) => this.Drones.RemoveAll(d => d.Brand == brand);

        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.Find(d => d.Name == name);

            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = this.Drones.FindAll(d => d.Range >= range);
            drones.ForEach(d => d.Available = false);
            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in this.Drones.FindAll(d=>d.Available))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
