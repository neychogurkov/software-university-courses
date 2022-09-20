using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string guest = Console.ReadLine();

            while (guest != "PARTY")
            {
                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    regularGuests.Add(guest);
                }

                guest = Console.ReadLine();
            }

            while (guest != "END")
            {
                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Remove(guest);
                }
                else
                {
                    regularGuests.Remove(guest);
                }

                guest = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            foreach (var vipGuest in vipGuests)
            {
                Console.WriteLine(vipGuest);
            }

            foreach (var regularGuest in regularGuests)
            {
                Console.WriteLine(regularGuest);
            }
        }
    }
}
