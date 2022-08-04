using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _03.Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            while (true)
            {
                string[] command = Console.ReadLine().Split("||");

                if (command[0] == "Sail")
                {
                    break;
                }

                string cityName = command[0];
                int population = int.Parse(command[1]);
                int gold = int.Parse(command[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities[cityName] = new City(population, gold);
                }
                else
                {
                    cities[cityName].Population += population;
                    cities[cityName].Gold += gold;
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split("=>");

                if (command[0] == "End")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Plunder":
                        Plunder(command, cities);
                        break;
                    case "Prosper":
                        Prosper(command, cities);
                        break;
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        static void Plunder(string[] command, Dictionary<string, City> cities)
        {
            string cityName = command[1];
            int people = int.Parse(command[2]);
            int gold = int.Parse(command[3]);

            cities[cityName].Population -= people;
            cities[cityName].Gold -= gold;

            Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");

            if (cities[cityName].Population <= 0 || cities[cityName].Gold <= 0)
            {
                cities.Remove(cityName);
                Console.WriteLine($"{cityName} has been wiped off the map!");
            }
        }

        static void Prosper(string[] command, Dictionary<string, City> cities)
        {
            string cityName = command[1];
            int gold = int.Parse(command[2]);

            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
                return;
            }

            cities[cityName].Gold += gold;

            Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {cities[cityName].Gold} gold.");
        }
    }

    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }
    }
}
