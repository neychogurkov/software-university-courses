using System;

namespace _01.PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double volume = double.Parse(Console.ReadLine());
            double p1 = double.Parse(Console.ReadLine());
            double p2 = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double poolOccupancy = p1 * hours + p2 * hours;

            if (poolOccupancy > volume)
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {poolOccupancy-volume:f2} liters.");
            }
            else
            {
                Console.WriteLine($"The pool is {poolOccupancy/volume*100:f2}% full. Pipe 1: {p1*hours/poolOccupancy*100:f2}%. Pipe 2: {p2 * hours / poolOccupancy * 100:f2}%.");
            }
        }
    }
}
