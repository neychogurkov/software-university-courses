using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.data = new List<Pet>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name) => this.data.Remove(this.data.Find(p => p.Name == name));
    
        public Pet GetPet(string name, string owner) => this.data.Find(p => p.Name == name && p.Owner == owner);

        public Pet GetOldestPet() => this.data.OrderByDescending(p => p.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
