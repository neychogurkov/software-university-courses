using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int[] warship = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int maxHealthCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Retire")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Fire":
                        {
                            int index = int.Parse(tokens[1]);
                            int damage = int.Parse(tokens[2]);

                            if (CheckIfIndexIsValid(warship, index))
                            {
                                warship[index] -= damage;

                                if (warship[index] <= 0)
                                {
                                    Console.WriteLine("You won! The enemy ship has sunken.");
                                    return;
                                }
                            }

                            break;
                        }
                    case "Defend":
                        {
                            int startIndex = int.Parse(tokens[1]);
                            int endIndex = int.Parse(tokens[2]);
                            int damage = int.Parse(tokens[3]);

                            if (CheckIfIndexIsValid(pirateShip, startIndex) && CheckIfIndexIsValid(pirateShip, endIndex))
                            {
                                for (int i = startIndex; i <= endIndex; i++)
                                {
                                    pirateShip[i] -= damage;

                                    if (pirateShip[i] <= 0)
                                    {
                                        Console.WriteLine("You lost! The pirate ship has sunken.");
                                        return;
                                    }
                                }
                            }
                            break;
                        }
                    case "Repair":
                        {
                            int index = int.Parse(tokens[1]);
                            int health = int.Parse(tokens[2]);

                            if (CheckIfIndexIsValid(pirateShip, index))
                            {
                                pirateShip[index] = Math.Min(pirateShip[index] + health, maxHealthCapacity);
                            }
                            break;
                        }
                    case "Status":
                        {
                            Console.WriteLine($"{pirateShip.Where(x => x < 0.2 * maxHealthCapacity).ToArray().Length} sections need repair.");
                            break;
                        }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }

        static bool CheckIfIndexIsValid(int[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                return false;
            }

            return true;
        }
    }
}
