namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MilitaryUnits.Contracts;
    using Planets.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;
    using Weapons.Contracts;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;

        private readonly IRepository<IWeapon> weapons;
        private readonly IRepository<IMilitaryUnit> army;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new WeaponRepository();
            this.army = new UnitRepository();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get { return this.budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return CalculateMilitaryPower(); }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var militaryUnit in this.Army)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine("--Forces: " + (this.Army.Count == 0
                ? "No units"
                : string.Join(", ", this.Army.Select(u => u.GetType().Name))))
                .AppendLine("--Combat equipment: " + (this.Weapons.Count == 0
                ? "No weapons"
                : string.Join(", ", this.Weapons.Select(w => w.GetType().Name))))
                .AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double militaryPower = this.Army.Sum(m => m.EnduranceLevel) + this.Weapons.Sum(w => w.DestructionLevel);

            if (this.Army.Any(m => m.GetType().Name == "AnonymousImpactUnit"))
            {
                militaryPower *= 1.3;
            }
            if (this.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                militaryPower *= 1.45;
            }

            return Math.Round(militaryPower, 3);
        }
    }
}
