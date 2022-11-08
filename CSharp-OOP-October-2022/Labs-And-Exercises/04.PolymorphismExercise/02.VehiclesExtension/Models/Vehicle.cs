namespace VehiclesExtension.Models
{
    using System;

    using Contracts;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;

            if(this.FuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double fuelLeft = this.FuelQuantity - distance * this.FuelConsumption;

            if (fuelLeft > 0)
            {
                this.FuelQuantity = fuelLeft;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            double totalFuel = this.FuelQuantity + liters;

            if (totalFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity = totalFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
