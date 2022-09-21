using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            int clothesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < clothesCount; i++)
            {
                string[] clothesInfo = Console.ReadLine().Split(" -> ");

                AddClothes(clothesByColor, clothesInfo);
            }

            string[] clothesToLookFor = Console.ReadLine().Split();
            string colorToLookFor = clothesToLookFor[0];
            string clothingToLookFor = clothesToLookFor[1];

            PrintClothes(clothesByColor, colorToLookFor, clothingToLookFor);
        }

        static void AddClothes(Dictionary<string, Dictionary<string, int>> clothesByColor, string[] clothesInfo)
        {
            string color = clothesInfo[0];
            string[] clothes = clothesInfo[1].Split(',');

            if (!clothesByColor.ContainsKey(color))
            {
                clothesByColor[color] = new Dictionary<string, int>();
            }

            foreach (var item in clothes)
            {
                if (!clothesByColor[color].ContainsKey(item))
                {
                    clothesByColor[color][item] = 0;
                }

                clothesByColor[color][item]++;
            }
        }

        static void PrintClothes(Dictionary<string, Dictionary<string, int>> clothesByColor, string colorToLookFor, string clothingToLookFor)
        {
            foreach (var (color, clothes) in clothesByColor)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (clothing, count) in clothes)
                {
                    Console.Write($"* {clothing} - {count}");

                    if (color == colorToLookFor && clothing == clothingToLookFor)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
