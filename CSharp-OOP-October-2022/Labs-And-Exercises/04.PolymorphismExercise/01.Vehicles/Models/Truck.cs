namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + FuelConsumptionIncrement)
        {

        }

        public override void Refuel(double liters)
        {
            base.Refuel(0.95 * liters);
        }
    }
}
