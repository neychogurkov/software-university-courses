using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = GetCarsInfo();

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                PrintCars(cars, c => c.Cargo.Type == type && c.Tires.Any(t => t.Pressure < 1));
            }
            else if (type == "flammable")
            {
                PrintCars(cars, c => c.Cargo.Type == type && c.Engine.Power > 250);
            }
        }

        static List<Car> GetCarsInfo()
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                List<Tire> tires = new List<Tire>();

                for (int j = 5; j < carInfo.Length; j += 2)
                {
                    double tirePressure = double.Parse(carInfo[j]);
                    int tireAge = int.Parse(carInfo[j + 1]);

                    tires.Add(new Tire(tireAge, tirePressure));
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            return cars;
        }

        static void PrintCars(List<Car> cars, Predicate<Car> filter)
        {
            foreach (var car in cars.FindAll(filter))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
