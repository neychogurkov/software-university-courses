using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                string nameOfGuest = command.Split()[0];

                if (command == $"{nameOfGuest} is going!")
                {
                    if (guests.Contains(nameOfGuest))
                    {
                        Console.WriteLine($"{nameOfGuest} is already in the list!");
                    }
                    else
                    {
                        guests.Add(nameOfGuest);
                    }
                }
                else
                {
                    if (guests.Contains(nameOfGuest))
                    {
                        guests.Remove(nameOfGuest);
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfGuest} is not in the list!");
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
