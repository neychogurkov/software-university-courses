using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int index = int.Parse(tokens[1]);
                int value = int.Parse(tokens[2]);

                switch (command)
                {
                    case "Shoot":
                        Shoot(targets, index, value);
                        break;
                    case "Add":
                        Add(targets, index, value);
                        break;
                    case "Strike":
                        Strike(targets, index, value);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join('|', targets));
        }

        static void Shoot(List<int> targets, int index, int power)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets[index] -= power;

                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
        }

        static void Add(List<int> targets, int index, int value)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        static void Strike(List<int> targets, int index, int radius)
        {
            if (index - radius >= 0 && index + radius < targets.Count)
            {
                targets.RemoveRange(index - radius, radius * 2 + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }
}
