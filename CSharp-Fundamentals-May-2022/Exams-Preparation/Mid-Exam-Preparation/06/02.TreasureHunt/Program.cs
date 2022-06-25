using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine().Split('|').ToList();
            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Loot":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            if (!treasureChest.Contains(tokens[i]))
                            {
                                treasureChest.Insert(0, tokens[i]);
                            }
                        }
                        break;
                    case "Drop":
                        int index = int.Parse(tokens[1]);

                        if (index >= 0 && index < treasureChest.Count)
                        {
                            treasureChest.Add(treasureChest[index]);
                            treasureChest.RemoveAt(index);
                        }
                        break;
                    case "Steal":
                        int count = int.Parse(tokens[1]);
                        List<string> stolenItems = new List<string>();

                        for (int i = 0; i < count; i++)
                        {
                            if (treasureChest.Count == 0)
                            {
                                break;
                            }

                            stolenItems.Add(treasureChest[treasureChest.Count - 1]);
                            treasureChest.RemoveAt(treasureChest.Count - 1);
                        }
                        stolenItems.Reverse();

                        Console.WriteLine(string.Join(", ", stolenItems));
                        break;
                }

                input = Console.ReadLine();
            }

            double treasureGain = 0;
            foreach (var item in treasureChest)
            {
                treasureGain += item.Length;
            }

            Console.WriteLine(treasureChest.Count > 0 ? $"Average treasure gain: {treasureGain / treasureChest.Count:f2} pirate credits." : "Failed treasure hunt.");
        }
    }
}
