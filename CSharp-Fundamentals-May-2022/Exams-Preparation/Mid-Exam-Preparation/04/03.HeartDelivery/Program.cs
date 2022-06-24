using System;
using System.Linq;

namespace _03.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            int houseIndex = 0;

            while (command != "Love!")
            {
                string[] tokens = command.Split();
                int jumpLength = int.Parse(tokens[1]);

                if (houseIndex + jumpLength < houses.Length)
                {
                    houseIndex += jumpLength;
                }
                else
                {
                    houseIndex = 0;
                }

                if (houses[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                }
                else
                {
                    houses[houseIndex] -= 2;

                    if (houses[houseIndex] == 0)
                    {
                        Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {houseIndex}.");

            int failedHouses = houses.Where(x => x != 0).ToList().Count;

            if (failedHouses > 0)
            {
                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
