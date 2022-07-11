using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _03.LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materialsQuantities = new Dictionary<string, int>();
            string winningMaterial = string.Empty;
            string legendaryItem = string.Empty;
            int shardsCount = 0;
            int fragmentsCount = 0;
            int motesCount = 0;
            bool flag = false;

            while (true)
            {
                string[] materialsInfo = Console.ReadLine().Split();

                for (int i = 0; i < materialsInfo.Length; i += 2)
                {
                    int quantity = int.Parse(materialsInfo[i]);
                    string currentMaterial = materialsInfo[i + 1].ToLower();

                    if (currentMaterial == "shards")
                    {
                        shardsCount += quantity;
                    }
                    else if (currentMaterial == "fragments")
                    {
                        fragmentsCount += quantity;
                    }
                    else if (currentMaterial == "motes")
                    {
                        motesCount += quantity;
                    }

                    if (!materialsQuantities.ContainsKey(currentMaterial))
                    {
                        materialsQuantities[currentMaterial] = 0;
                    }

                    materialsQuantities[currentMaterial] += quantity;

                    if (shardsCount >= 250)
                    {
                        winningMaterial = "shards";
                        legendaryItem = "Shadowmourne";
                        flag = true;
                        break;
                    }
                    if (fragmentsCount >= 250)
                    {
                        winningMaterial = "fragments";
                        legendaryItem = "Valanyr";
                        flag = true;
                        break;
                    }
                    if (motesCount >= 250)
                    {
                        winningMaterial = "motes";
                        legendaryItem = "Dragonwrath";
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            Dictionary<string, int> keyMaterialsQuantities = materialsQuantities
                .Where(m => m.Key == "shards" || m.Key == "fragments" || m.Key == "motes")
                .ToDictionary(m => m.Key, m => m.Value);

            Dictionary<string,int> junkMaterialsQuantities = materialsQuantities
                .Where(m => m.Key != "shards" && m.Key != "fragments" && m.Key != "motes")
                .ToDictionary(m => m.Key, m => m.Value);

            keyMaterialsQuantities[winningMaterial] -= 250;

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var kvp in keyMaterialsQuantities)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterialsQuantities)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
