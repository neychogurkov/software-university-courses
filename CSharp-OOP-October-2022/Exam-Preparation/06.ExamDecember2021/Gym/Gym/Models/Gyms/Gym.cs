namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Athletes.Contracts;
    using Equipment.Contracts;
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;
        private ICollection<IAthlete> athletes;
        private ICollection<IEquipment> equipment;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.athletes = new List<IAthlete>();
            this.equipment = new List<IEquipment>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.GetTotalEquipmentWeight();

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {(this.athletes.Any() ? string.Join(", ", this.athletes.Select(a => a.FullName)) : "No athletes")}")
                .AppendLine($"Equipment total count: {this.equipment.Count}")
                .AppendLine($"Equipment total weight: {this.GetTotalEquipmentWeight():f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        private double GetTotalEquipmentWeight() => this.equipment.Sum(e => e.Weight);
    }
}
