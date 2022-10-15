using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Fish = new List<Fish>(); ;
            this.Material = material;
            this.Capacity = capacity;
        }

        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (this.Fish.Count == this.Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                this.Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight) => this.Fish.Remove(this.Fish.Find(f => f.Weight == weight));

        public Fish GetFish(string fishType) => this.Fish.Find(f => f.FishType == fishType);

        public Fish GetBiggestFish() => this.Fish.Find(f => f.Length == this.Fish.Max(fish => fish.Length));

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
