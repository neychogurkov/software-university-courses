using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            SetPlants(plants);

            while (true)
            {
                string[] command = Console.ReadLine().Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);


                if (command[0] == "Exhibition")
                {
                    break;
                }

                string plant = command[1];

                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (command[0])
                {
                    case "Rate":
                        int rating = int.Parse(command[2]);
                        plants[plant].Ratings.Add(rating);
                        break;
                    case "Update":
                        int newRarity = int.Parse(command[2]);
                        plants[plant].Rarity = newRarity;
                        break;
                    case "Reset":
                        plants[plant].Ratings.Clear();
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            PrintPlants(plants);
        }

        static void PrintPlants(Dictionary<string, Plant> plants)
        {
            foreach (var plant in plants)
            {
                string plantName = plant.Key;
                int rarity = plant.Value.Rarity;
                double averageRating = 0;

                if (plant.Value.Ratings.Count > 0)
                {
                    averageRating = plant.Value.Ratings.Average();
                }

                Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {averageRating:f2}");
            }
        }

        static void SetPlants(Dictionary<string, Plant> plants)
        {
            int countOfPlants = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPlants; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->");

                string plant = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants[plant] = new Plant();
                }

                plants[plant].Rarity = rarity;
            }
        }
    }

    class Plant
    {
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }

        public Plant()
        {
            Ratings = new List<int>();
        }
    }
}
