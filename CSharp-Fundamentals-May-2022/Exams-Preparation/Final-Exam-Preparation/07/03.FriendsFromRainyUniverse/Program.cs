using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FriendsFromRainyUniverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> peoplesLiquids =
                new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                string personName = input[0];
                string liquidName = input[1];
                int jarsCount = int.Parse(input[2]);

                if (!peoplesLiquids.ContainsKey(personName))
                {
                    peoplesLiquids[personName] = new Dictionary<string, int>();
                }

                if (!peoplesLiquids[personName].ContainsKey(liquidName))
                {
                    peoplesLiquids[personName][liquidName] = 0;
                }

                peoplesLiquids[personName][liquidName] += jarsCount;

            }

            foreach (var person in peoplesLiquids.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{person.Key} Liquids:");

                foreach (var liquid in person.Value.OrderBy(l => l.Value))
                {
                    Console.WriteLine($"--- {liquid.Key}: {liquid.Value}");
                }
            }
        }
    }
}
