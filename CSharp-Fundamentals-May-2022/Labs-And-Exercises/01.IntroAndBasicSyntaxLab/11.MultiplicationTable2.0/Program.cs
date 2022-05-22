using System;

namespace _11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier > 10)
            {
                Console.WriteLine($"{number} X {multiplier} = {number * multiplier}");
            }

            for (int i = multiplier; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number*i}");
            }

        }
    }
}
