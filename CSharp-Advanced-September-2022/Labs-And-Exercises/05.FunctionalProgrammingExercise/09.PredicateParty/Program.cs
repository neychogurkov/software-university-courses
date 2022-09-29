using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Party!")
                {
                    break;
                }

                string action = command[0];
                string condition = command[1];
                string value = command[2];

                Predicate<string> filter = GetPredicate(condition, value);
                ExecuteCommand(action, filter, guests);
            }

            Console.WriteLine(guests.Count > 0
                ? $"{string.Join(", ", guests)} are going to the party!"
                : "Nobody is going to the party!");
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            if (filter == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            else if (filter == "EndsWith")
            {
                return x => x.EndsWith(value);
            }
            else if (filter == "Length")
            {
                return x => x.Length == int.Parse(value);
            }

            return null;
        }

        static void ExecuteCommand(string action, Predicate<string> filter, List<string> guests)
        {
            if (action == "Double")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (filter(guests[i]))
                    {
                        guests.Insert(guests.IndexOf(guests[i]), guests[i]);
                        i++;
                    }
                }
            }
            else if (action == "Remove")
            {
                guests.RemoveAll(n => filter(n));
            }
        }
    }
}
