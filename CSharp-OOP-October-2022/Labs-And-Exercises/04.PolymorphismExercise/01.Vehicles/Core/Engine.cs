namespace Vehicles.Core
{
    using Contracts;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private IVehicle car;
        private IVehicle truck;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            this.car = this.BuildVehicleUsingFactory();
            this.truck = this.BuildVehicleUsingFactory();

            int commandsCount = int.Parse(this.reader.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                ProcessCommand();
            }

            this.writer.WriteLine(this.car.ToString());
            this.writer.WriteLine(this.truck.ToString());
        }

        private IVehicle BuildVehicleUsingFactory()
        {
            string[] vehicleInfo = this.reader.ReadLine().Split();
            string vehicleType = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] command = this.reader.ReadLine().Split();
            string action = command[0];
            string vehicleType = command[1];
            double value = double.Parse(command[2]);

            IVehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = this.car;
            }
            else if (vehicleType == "Truck")
            {
                vehicle = this.truck;
            }

            if (action == "Drive")
            {
                this.writer.WriteLine(vehicle.Drive(value));
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(value);
            }
        }
    }
}
