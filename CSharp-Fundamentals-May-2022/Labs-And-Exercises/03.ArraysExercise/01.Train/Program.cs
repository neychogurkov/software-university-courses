using System;
using System.Runtime.InteropServices;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numberOfWagons];
            int totalPassengers = 0;

            for (int i = 0; i < numberOfWagons; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                totalPassengers += wagons[i];
            }

            Console.WriteLine(string.Join(" ", wagons));
            Console.WriteLine(totalPassengers);
        }
    }
}
