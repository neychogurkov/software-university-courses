using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
            }

            Console.WriteLine(evenSum);

            //Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).ToArray().Where(n => n % 2 == 0).Sum());
        }
    }
}
