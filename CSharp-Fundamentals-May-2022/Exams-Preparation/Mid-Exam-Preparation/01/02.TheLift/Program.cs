using System;
using System.Linq;

namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] < 4)
                {
                    if (waitingPeople == 0)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(string.Join(" ", wagons));
                        return;
                    }

                    wagons[i]++;
                    waitingPeople--;
                }
            }

            if (waitingPeople > 0)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
