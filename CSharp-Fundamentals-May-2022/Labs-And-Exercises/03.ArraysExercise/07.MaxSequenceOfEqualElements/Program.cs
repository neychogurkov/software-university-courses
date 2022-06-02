using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string longestSequence = string.Empty;
            string currentSequence = string.Empty;
            int longestSequenceCount = 0;
            int currentSequenceCount = 1;

            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    if (currentSequenceCount == 1)
                    {
                        currentSequence = numbers[i].ToString() + " ";
                    }

                    currentSequenceCount++;
                    currentSequence += numbers[i] + " ";
                }
                else
                {
                    currentSequenceCount = 1;
                    currentSequence = numbers[i].ToString() + " ";
                }

                if (currentSequenceCount > longestSequenceCount)
                {
                    longestSequenceCount = currentSequenceCount;
                    longestSequence = currentSequence;
                }
            }

            Console.WriteLine(longestSequence);
        }
    }
}
