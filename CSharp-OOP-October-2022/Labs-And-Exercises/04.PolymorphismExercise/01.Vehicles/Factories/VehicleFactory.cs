namespace Vehicles.Factories
{
    using Contracts;
    using Models;
    using Models.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle = null;
            if(type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if(type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
