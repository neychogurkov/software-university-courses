using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bombElements[0];
            int bombPower = bombElements[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int startingIndex = 0;
                    if (i - bombPower >= 0)
                    {
                        startingIndex = i - bombPower;
                    }
                    else
                    {
                        startingIndex = 0;
                    }

                    int count = 2 * bombPower + 1;

                    if (startingIndex + count >= numbers.Count)
                    {
                        count = numbers.Count - startingIndex;
                    }

                    numbers.RemoveRange(startingIndex, count);
                    
                    i--;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
