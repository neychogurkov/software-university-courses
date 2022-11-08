namespace VehiclesExtension.Core
{
    using System;

    using Contracts;
    using Factories.Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private IVehicle car;
        private IVehicle truck;
        private IVehicle bus;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            this.car = BuildVehicleUsingFactory();
            this.truck = BuildVehicleUsingFactory();
            this.bus = BuildVehicleUsingFactory();

            int commandsCount = int.Parse(reader.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                ProcessCommand();
            }

            this.writer.WriteLine(this.car.ToString());
            this.writer.WriteLine(this.truck.ToString());
            this.writer.WriteLine(this.bus.ToString());
        }

        private IVehicle BuildVehicleUsingFactory()
        {
            string[] vehicleInfo = this.reader.ReadLine().Split();
            string vehicleType = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

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
            else if (vehicleType == "Bus")
            {
                vehicle = this.bus;
            }

            if (action == "Drive")
            {
                this.writer.WriteLine(vehicle.Drive(value));
            }
            else if (action == "DriveEmpty")
            {
                Console.WriteLine((this.bus as Bus).DriveEmpty(value));
            }
            else if (action == "Refuel")
            {
                try
                {
                    vehicle.Refuel(value);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
