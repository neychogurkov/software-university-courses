using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Vehicle> vehicles = new List<Vehicle>();
            int carHorsePowerSum = 0;
            int truckHorsePowerSum = 0;
            int cars = 0;
            int trucks = 0;

            while (command != "End")
            {
                string[] vehicleInfo = command.Split();
                string type = vehicleInfo[0];
                string model = vehicleInfo[1];
                string color = vehicleInfo[2];
                int horsePower = int.Parse(vehicleInfo[3]);

                type = type[0].ToString().ToUpper() + type.Substring(1);

                if (type == "Car")
                {
                    carHorsePowerSum += horsePower;
                    cars++;
                }
                else if (type == "Truck")
                {
                    truckHorsePowerSum += horsePower;
                    trucks++;
                }

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                vehicles.Add(vehicle);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Close the Catalogue")
            {
                Vehicle currentVehicle = vehicles.Find(v => v.Model == command);

                Console.WriteLine($"Type: {currentVehicle.Type}");
                Console.WriteLine($"Model: {currentVehicle.Model}");
                Console.WriteLine($"Color: {currentVehicle.Color}");
                Console.WriteLine($"Horsepower: {currentVehicle.HorsePower}");

                command = Console.ReadLine();
            }

            if (cars == 0)
            {
                cars = 1;
            }

            if (trucks == 0)
            {
                trucks = 1;
            }

            double carsAverageHorsePower = (double)carHorsePowerSum / cars;
            double trucksAverageHorsePower = (double)truckHorsePowerSum / trucks;
            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsePower:f2}.");
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
    }
}
