using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] vehicleInfo = command.Split('/');
                string type = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(vehicleInfo[3]);

                    Car car = new Car(brand, model, horsePower);
                    catalogue.Cars.Add(car);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(vehicleInfo[3]);

                    Truck truck = new Truck(brand, model, weight);
                    catalogue.Trucks.Add(truck);
                }

                command = Console.ReadLine();
            }

            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in catalogue.Cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalogue.Trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
    }

    class Catalogue
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }

        public Catalogue()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
    }
}
