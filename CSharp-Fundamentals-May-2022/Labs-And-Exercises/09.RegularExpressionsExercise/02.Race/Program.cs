using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ");

            Dictionary<string, int> participantsByDistanceRan = new Dictionary<string, int>();

            foreach (var participant in participants)
            {
                participantsByDistanceRan[participant] = 0;
            }

            string letterPattern = @"[A-Za-z]";
            string digitPattern = @"[0-9]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection letters = Regex.Matches(input, letterPattern);
                MatchCollection digits = Regex.Matches(input, digitPattern);

                string name = string.Join("", letters);

                if (participantsByDistanceRan.ContainsKey(name))
                {
                    int distanceRan = digits.Select(d => int.Parse(d.Value)).Sum();
                    participantsByDistanceRan[name] += distanceRan;
                }

                input = Console.ReadLine();
            }

            participantsByDistanceRan = participantsByDistanceRan
                .OrderByDescending(p => p.Value)
                .Take(3)
                .ToDictionary(p => p.Key, p => p.Value);

            int index = 1;

            foreach (var kvp in participantsByDistanceRan)
            {
                if (index == 1)
                {
                    Console.WriteLine($"1st place: {kvp.Key}");
                }
                else if (index == 2)
                {
                    Console.WriteLine($"2nd place: {kvp.Key}");
                }
                else
                {
                    Console.WriteLine($"3rd place: {kvp.Key}");
                }
                index++;
            }
        }
    }
}
