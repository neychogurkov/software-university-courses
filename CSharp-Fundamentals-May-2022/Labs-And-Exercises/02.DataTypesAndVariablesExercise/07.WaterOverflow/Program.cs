using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            for (int i = 0; i < n; i++)
            {
                int waterQuantity = int.Parse(Console.ReadLine());
                if (capacity - waterQuantity < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity -= waterQuantity;
                }
            }

            Console.WriteLine(255 - capacity);
        }
    }
}
