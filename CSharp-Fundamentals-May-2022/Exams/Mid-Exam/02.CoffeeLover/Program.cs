using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace _02.CoffeeLover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "Include":
                        coffees.Add(command[1]);
                        break;
                    case "Remove":
                        string direction = command[1];
                        int count = int.Parse(command[2]);

                        if (count <= coffees.Count)
                        {
                            if (direction == "first")
                            {
                                for (int j = 0; j < count; j++)
                                {
                                    coffees.RemoveAt(0);
                                }
                            }
                            else if (direction == "last")
                            {
                                for (int j = 0; j < count; j++)
                                {
                                    coffees.RemoveAt(coffees.Count - 1);
                                }
                            }
                        }
                        break;
                    case "Prefer":
                        int firstCoffeeIndex = int.Parse(command[1]);
                        int secondCoffeeIndex = int.Parse(command[2]);

                        if (firstCoffeeIndex >= 0 && firstCoffeeIndex < coffees.Count && secondCoffeeIndex >= 0 &&
                            secondCoffeeIndex < coffees.Count)
                        {
                            string temp = coffees[firstCoffeeIndex];
                            coffees[firstCoffeeIndex] = coffees[secondCoffeeIndex];
                            coffees[secondCoffeeIndex] = temp;
                        }
                        break;
                    case "Reverse":
                        coffees.Reverse();
                        break;
                }
            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }
    }
}
