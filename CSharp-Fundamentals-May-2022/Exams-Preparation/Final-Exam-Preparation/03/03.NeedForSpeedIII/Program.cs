using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _03.NeedForSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            SetCars(cars);

            while (true)
            {
                string[] command = Console.ReadLine().Split(" : ");

                if (command[0] == "Stop")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Drive":
                        DriveCar(command, cars);
                        break;
                    case "Refuel":
                        RefuelCar(command, cars);
                        break;
                    case "Revert":
                        RevertCar(command, cars);
                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }

        static void SetCars(Dictionary<string, Car> cars)
        {
            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|');

                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                cars[carName] = new Car(mileage, fuel);
            }
        }

        static void DriveCar(string[] command, Dictionary<string, Car> cars)
        {
            string carName = command[1];
            int distance = int.Parse(command[2]);
            int fuel = int.Parse(command[3]);

            if (cars[carName].Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }

            cars[carName].Mileage += distance;
            cars[carName].Fuel -= fuel;

            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

            if (cars[carName].Mileage >= 100000)
            {
                cars.Remove(carName);
                Console.WriteLine($"Time to sell the {carName}!");
            }
        }

        static void RefuelCar(string[] command, Dictionary<string, Car> cars)
        {
            string carName = command[1];
            int fuel = int.Parse(command[2]);

            int initialFuel = cars[carName].Fuel;
            cars[carName].Fuel = Math.Min(cars[carName].Fuel + fuel, 75);

            Console.WriteLine($"{carName} refueled with {cars[carName].Fuel - initialFuel} liters");
        }

        static void RevertCar(string[] command, Dictionary<string, Car> cars)
        {
            string carName = command[1];
            int kilometers = int.Parse(command[2]);

            cars[carName].Mileage -= kilometers;

            if (cars[carName].Mileage < 10000)
            {
                cars[carName].Mileage = 10000;
            }
            else
            {
                Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
            }
        }
    }

    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
    }
}
