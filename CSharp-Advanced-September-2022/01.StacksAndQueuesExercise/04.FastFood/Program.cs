using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (queue.Peek() > foodQuantity)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }

                foodQuantity -= queue.Dequeue();
            }

            Console.WriteLine("Orders complete");
        }
    }
}
