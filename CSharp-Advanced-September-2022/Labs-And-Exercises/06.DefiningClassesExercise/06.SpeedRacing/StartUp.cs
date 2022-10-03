using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = GetCarsInfo();
            DriveCars(cars);

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }

        static Dictionary<string, Car> GetCarsInfo()
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car.Model, car);
            }

            return cars;
        }

        static void DriveCars(Dictionary<string, Car> cars)
        {
            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                string model = command[1];
                int distance = int.Parse(command[2]);

                cars[model].Drive(distance);
            }
        }
    }
}
