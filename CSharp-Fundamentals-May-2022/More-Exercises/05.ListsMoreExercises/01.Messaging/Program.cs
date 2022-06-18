using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int digitSum = 0;
                int currentNumber = numbers[i];

                while (currentNumber != 0)
                {
                    digitSum += currentNumber % 10;
                    currentNumber /= 10;
                }

                int index = digitSum;

                while (index >= text.Length)
                {
                    index -= text.Length;
                }

                result += text[index];
                text = text.Remove(index, 1);
            }

            Console.WriteLine(result);
        }
    }
}
