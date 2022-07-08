using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> participantsPoints = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                if (input[0] == "no more time")
                {
                    break;
                }

                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].Keys.Contains(username))
                    {
                        if (contests[contest][username] < points)
                        {
                            contests[contest][username] = points;
                        }
                    }
                    else
                    {
                        contests[contest].Add(username, points);
                    }
                }
                else
                {
                    contests[contest] = new Dictionary<string, int> { { username, points } };
                }
            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Keys.Count} participants");

                int counter = 0;
                foreach (var participant in contest.Value.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {participant.Key} <::> {participant.Value}");
                }
            }

            foreach (var contest in contests)
            {
                foreach (var participant in contest.Value)
                {
                    if (!participantsPoints.ContainsKey(participant.Key))
                    {
                        participantsPoints[participant.Key] = 0;
                    }

                    participantsPoints[participant.Key] += participant.Value;
                }
            }

            Console.WriteLine("Individual standings:");

            int position = 0;
            foreach (var participant in participantsPoints.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                position++;

                Console.WriteLine($"{position}. {participant.Key} -> {participant.Value}");
            }
        }
    }
}
