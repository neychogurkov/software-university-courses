using System;
using System.Collections.Generic;
using System.Security;

namespace _05.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> usersLicensePlates = new Dictionary<string, string>();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string username = command[1];

                if (command[0] == "register")
                {
                    string licensePlateNumber = command[2];

                    if (usersLicensePlates.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        usersLicensePlates[username] = licensePlateNumber;
                        
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command[0] == "unregister")
                {
                    if (usersLicensePlates.ContainsKey(username))
                    {
                        usersLicensePlates.Remove(username);

                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var kvp in usersLicensePlates)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
