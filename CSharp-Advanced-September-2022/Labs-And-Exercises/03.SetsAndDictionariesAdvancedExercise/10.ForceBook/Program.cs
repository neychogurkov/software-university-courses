using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> forceBook = new Dictionary<string, string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.Contains(" | "))
                {
                    string forceSide = command.Split(" | ")[0];
                    string forceUser = command.Split(" | ")[1];

                    if (!forceBook.ContainsKey(forceUser))
                    {
                        forceBook[forceUser] = forceSide;
                    }
                }
                else if (command.Contains(" -> "))
                {
                    string forceUser = command.Split(" -> ")[0];
                    string forceSide = command.Split(" -> ")[1];

                    forceBook[forceUser] = forceSide;

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            Dictionary<string, List<string>> forceUsersByForceSide = new Dictionary<string, List<string>>();

            foreach (var (forceUser, forceSide) in forceBook)
            {
                if (!forceUsersByForceSide.ContainsKey(forceSide))
                {
                    forceUsersByForceSide[forceSide] = new List<string>();
                }

                forceUsersByForceSide[forceSide].Add(forceUser);
            }

            foreach (var (forceSide, forceUsers) in forceUsersByForceSide.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
            {
                if (forceUsers.Count > 0)
                {
                    Console.WriteLine($"Side: {forceSide}, Members: {forceUsers.Count}");

                    foreach (var forceUser in forceUsers.OrderBy(f => f))
                    {
                        Console.WriteLine($"! {forceUser}");
                    }
                }
            }
        }
    }
}
