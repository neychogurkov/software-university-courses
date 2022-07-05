using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
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
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile").Where(c => c.Cargo.Weight < 1000))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (type == "flamable")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "flamable").Where(c => c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Car(string model, int speed, int power, int weight, string type)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(weight, type);
        }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}
