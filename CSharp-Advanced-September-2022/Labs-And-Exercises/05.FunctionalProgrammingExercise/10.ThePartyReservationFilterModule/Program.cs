using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(';');

                if (command[0] == "Print")
                {
                    break;
                }

                string action = command[0];
                string filter = command[1];
                string value = command[2];

                if (action == "Add filter")
                {
                    filters.Add(filter + value, GetPredicate(filter, value));
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            if (filter == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            else if (filter == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            else if (filter == "Length")
            {
                return x => x.Length == int.Parse(value);
            }
            else if (filter == "Contains")
            {
                return x => x.Contains(value);
            }

            return null;
        }
    }
}
