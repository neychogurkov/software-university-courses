namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double DEFAULT_FUEL_AVAILABLE = 65;
        private const double DEFAULT_FUEL_CONSUMPTION_PER_RACE = 7.5;


        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, DEFAULT_FUEL_AVAILABLE, DEFAULT_FUEL_CONSUMPTION_PER_RACE)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)Math.Round(this.HorsePower - 0.03 * HorsePower);
        }
    }
}
