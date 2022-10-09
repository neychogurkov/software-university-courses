using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => this.Renovators.Count;
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Renovators = new List<Renovator>();
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = this.Renovators.Find(r => r.Name == name);

            if (renovatorToRemove != null)
            {
                this.Renovators.Remove(renovatorToRemove);
            }

            return renovatorToRemove != null;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovators = this.Renovators.RemoveAll(r => r.Type == type);
            return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = this.Renovators.Find(r => r.Name == name);

            if (renovatorToHire != null)
            {
                renovatorToHire.Hired = true;
            }

            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return this.Renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in this.Renovators.Where(r => !r.Hired))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
