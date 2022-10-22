using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Multiprocessor = new List<CPU>();
            this.Model = model;
            this.Capacity = capacity;
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => this.Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand) => this.Multiprocessor.Remove(GetCPU(brand));

        public CPU MostPowerful() => this.Multiprocessor.OrderByDescending(p => p.Frequency).FirstOrDefault();

        public CPU GetCPU(string brand) => this.Multiprocessor.Find(p => p.Brand == brand);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var CPU in this.Multiprocessor)
            {
                sb.AppendLine(CPU.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
