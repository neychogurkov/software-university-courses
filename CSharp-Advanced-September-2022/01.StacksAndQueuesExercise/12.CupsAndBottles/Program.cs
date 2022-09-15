using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initialCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] initialBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(initialCups);
            Stack<int> bottles = new Stack<int>(initialBottles);

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                FillCups(cups, bottles, ref wastedWater);
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        static int FillCups(Queue<int> cups, Stack<int> bottles, ref int wastedWater)
        {
            int currentCup = cups.Peek();

            while (currentCup > 0 && bottles.Count > 0)
            {
                currentCup -= bottles.Pop();
            }

            wastedWater += Math.Abs(currentCup);
            cups.Dequeue();

            return wastedWater;
        }
    }
}
