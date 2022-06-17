using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Add")
                {
                    wagons.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int passengers = int.Parse(tokens[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (passengers + wagons[i] <= capacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
