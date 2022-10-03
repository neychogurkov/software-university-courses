using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = GetEnginesInfo();
            List<Car> cars = GetCarsInfo(engines);

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        static List<Engine> GetEnginesInfo()
        {
            List<Engine> engines = new List<Engine>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                switch (engineInfo.Length)
                {
                    case 2:
                        engines.Add(new Engine(model, power));
                        break;
                    case 3:
                        if (int.TryParse(engineInfo[2], out int value))
                        {
                            int displacement = value;
                            engines.Add(new Engine(model, power, displacement));
                        }
                        else
                        {
                            string efficiency = engineInfo[2];
                            engines.Add(new Engine(model, power, efficiency));
                        }
                        break;
                    case 4:
                        {
                            int displacement = int.Parse(engineInfo[2]);
                            string efficiency = engineInfo[3];
                            engines.Add(new Engine(model, power, displacement, efficiency));
                            break;
                        }
                }
            }

            return engines;
        }

        static List<Car> GetCarsInfo(List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInfo[0];
                string engineModel = carInfo[1];
                Engine engine = engines.Find(e => e.Model == engineModel);

                switch (carInfo.Length)
                {
                    case 2:
                        cars.Add(new Car(carModel, engine));
                        break;
                    case 3:
                        if (int.TryParse(carInfo[2], out int value))
                        {
                            int weight = value;
                            cars.Add(new Car(carModel, engine, weight));
                        }
                        else
                        {
                            string color = carInfo[2];
                            cars.Add(new Car(carModel, engine, color));
                        }
                        break;
                    case 4:
                        {
                            int weight = int.Parse(carInfo[2]);
                            string color = carInfo[3];
                            cars.Add(new Car(carModel, engine, weight, color));
                            break;
                        }
                }
            }

            return cars;
        }
    }
}
