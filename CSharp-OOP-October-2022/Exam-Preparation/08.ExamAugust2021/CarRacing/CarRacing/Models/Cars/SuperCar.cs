namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double DEFAULT_FUEL_AVAILABLE = 80;
        private const double DEFAULT_FUEL_CONSUMPTION_PER_RACE = 10;


        public SuperCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, DEFAULT_FUEL_AVAILABLE, DEFAULT_FUEL_CONSUMPTION_PER_RACE)
        {
        }
    }
}
