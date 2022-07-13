using System;
using System.Linq;

namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startOfRange = char.Parse(Console.ReadLine());
            char endOfRange = char.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int sum = 0;

            foreach (var character in text)
            {
                if (character > startOfRange && character < endOfRange)
                {
                    sum+=character;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
