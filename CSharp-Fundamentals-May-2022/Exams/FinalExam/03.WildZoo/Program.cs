using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WildZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Animal> animals = new Dictionary<string, Animal>();
            Dictionary<string, int> areas = new Dictionary<string, int>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(new string[] { ": ", "-" }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "EndDay")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    AddAnimal(command, animals, areas);
                }
                else if (command[0] == "Feed")
                {
                    FeedAnimal(command, animals, areas);
                }
            }

            PrintAnimalsAndAreas(animals, areas);
        }

        static void AddAnimal(string[] command, Dictionary<string, Animal> animals, Dictionary<string, int> areas)
        {
            string animalName = command[1];
            int neededFoodQuantity = int.Parse(command[2]);
            string area = command[3];

            if (animals.ContainsKey(animalName))
            {
                animals[animalName].NeededFood += neededFoodQuantity;
            }
            else
            {
                animals[animalName] = new Animal(neededFoodQuantity, area);

                if (!areas.ContainsKey(area))
                {
                    areas[area] = 0;
                }

                areas[area]++;
            }
        }

        static void FeedAnimal(string[] command, Dictionary<string, Animal> animals, Dictionary<string, int> areas)
        {
            string animalName = command[1];
            int food = int.Parse(command[2]);

            if (animals.ContainsKey(animalName))
            {
                animals[animalName].NeededFood -= food;

                if (animals[animalName].NeededFood <= 0)
                {
                    areas[animals[animalName].Area]--;
                    animals.Remove(animalName);
                    Console.WriteLine($"{animalName} was successfully fed");
                }
            }
        }

        static void PrintAnimalsAndAreas(Dictionary<string, Animal> animals, Dictionary<string, int> areas)
        {
            Console.WriteLine("Animals:");

            foreach (var animal in animals)
            {
                Console.WriteLine($" {animal.Key} -> {animal.Value.NeededFood}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var area in areas.Where(a => a.Value > 0))
            {
                Console.WriteLine($" {area.Key}: {area.Value}");
            }
        }
    }

    class Animal
    {
        public int NeededFood { get; set; }
        public string Area { get; set; }

        public Animal(int neededFood, string area)
        {
            NeededFood = neededFood;
            Area = area;
        }
    }
}
