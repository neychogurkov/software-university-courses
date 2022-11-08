namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.4;

        private bool isEmpty;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.isEmpty = true;
        }

        public override string Drive(double distance)
        {
            if (this.isEmpty)
            {
                this.FuelConsumption += FuelConsumptionIncrement;
                this.isEmpty = false;
            }

            return base.Drive(distance);
        }

        public string DriveEmpty(double distance)
        {
            if (!this.isEmpty)
            {
                this.FuelConsumption -= FuelConsumptionIncrement;
                this.isEmpty = true;
            }

            return base.Drive(distance);
        }
    }
}
