using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedFood = 0;

            while (guests.Any() && plates.Any())
            {
                int currentGuest = guests.Dequeue();
                int currentPlate = plates.Pop();

                while(currentGuest > currentPlate)
                {
                    currentGuest -= currentPlate;

                    if (!plates.Any())
                    {
                        break;
                    }

                    currentPlate = plates.Pop();
                }

                wastedFood += Math.Abs(currentGuest - currentPlate);
                currentGuest -= currentPlate;
            }

            if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
