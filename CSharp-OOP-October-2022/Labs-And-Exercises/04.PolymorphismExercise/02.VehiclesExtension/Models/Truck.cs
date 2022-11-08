namespace VehiclesExtension.Models
{
    using System;

    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + FuelConsumptionIncrement, tankCapacity)
        {

        }

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            base.Refuel(0.95 * liters);
        }
    }
}
