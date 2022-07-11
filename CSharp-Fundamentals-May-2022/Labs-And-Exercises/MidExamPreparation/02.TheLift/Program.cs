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
            bool isFull = true;

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    int peopleToJoin = Math.Min(Math.Min(waitingPeople, 4), 4 - wagons[i]);
                    wagons[i] += peopleToJoin;
                    waitingPeople -= peopleToJoin;
                }
            }

            if (wagons[wagons.Length - 1] < 4)
            {
                isFull = false;
            }

            if (waitingPeople == 0 && isFull == false)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (isFull && waitingPeople > 0)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
