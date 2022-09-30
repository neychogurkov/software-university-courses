using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tiresList = GetTiresInfo();
            List<Engine> engines = GetEnginesInfo();
            List<Car> cars = GetCarsInfo(tiresList, engines);

            Predicate<Car> filterCars = FilterCars();

            List<Car> specialCars = cars
                .FindAll(filterCars)
                .ToList();

            PrintSpecialCars(specialCars);
        }

        static List<Tire[]> GetTiresInfo()
        {
            List<Tire[]> tiresList = new List<Tire[]>();

            while (true)
            {
                string[] tireInfo = Console.ReadLine().Split();

                if (tireInfo[0] == "No")
                {
                    break;
                }

                Tire[] tires = new Tire[4];

                for (int i = 0; i < 4; i++)
                {
                    int year = int.Parse(tireInfo[i * 2]);
                    double pressure = double.Parse(tireInfo[i * 2 + 1]);

                    tires[i] = new Tire(year, pressure);
                }

                tiresList.Add(tires);
            }

            return tiresList;
        }

        static List<Engine> GetEnginesInfo()
        {
            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string[] engineInfo = Console.ReadLine().Split();

                if (engineInfo[0] == "Engines")
                {
                    break;
                }

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            return engines;
        }

        static List<Car> GetCarsInfo(List<Tire[]> tiresList, List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            while (true)
            {
                string[] carInfo = Console.ReadLine().Split();

                if (carInfo[0] == "Show")
                {
                    break;
                }

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tiresList[tiresIndex]);
                cars.Add(car);
            }

            return cars;
        }

        static Predicate<Car> FilterCars() => c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10;

        static void PrintSpecialCars(List<Car> specialCars)
        {
            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine(specialCar.WhoAmI());
            }
        }
    }
}