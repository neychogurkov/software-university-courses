using System;
using System.Collections.Generic;

namespace _03.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ');
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');

                if (command[0] == "End")
                {
                    break;
                }

                string model = command[1];
                int distanceToTravel = int.Parse(command[2]);

                Car car = cars.Find(c => c.Model == model);
                car.CheckIfFuelIsEnough(distanceToTravel);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public int TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TraveledDistance = 0;
        }

        public void CheckIfFuelIsEnough(int distanceToTravel)
        {
            double fuelNeeded = distanceToTravel * FuelConsumptionPerKilometer;

            if (fuelNeeded <= FuelAmount)
            {
                FuelAmount -= fuelNeeded;
                TraveledDistance += distanceToTravel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
