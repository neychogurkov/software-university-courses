using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int longestSequence = 0;
            int bestStartingIndex = int.MaxValue;
            int[] bestSequence = new int[length];
            int bestSum = 0;
            int bestSequenceIndex = 0;
            int count = 0;

            while (command != "Clone them!")
            {
                int[] sequence = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentSequenceLength = 1;
                int bestCurrentSequenceLength = 1;
                int startingIndex = 0;
                int sum = 0;
                bool isCurrentDNABetter = false;
                count++;

                for (int i = 0; i < sequence.Length - 1; i++)
                {
                    if (sequence[i] == 1 && sequence[i + 1] == 1)
                    {
                        currentSequenceLength++;
                    }
                    else
                    {
                        currentSequenceLength = 1;
                    }
                    if (currentSequenceLength > bestCurrentSequenceLength)
                    {
                        bestCurrentSequenceLength = currentSequenceLength;
                        startingIndex = i;
                    }
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    sum += sequence[i];
                }

                if (bestCurrentSequenceLength > longestSequence)
                {
                    isCurrentDNABetter = true;
                }
                else if (bestCurrentSequenceLength == longestSequence)
                {
                    if (startingIndex < bestStartingIndex)
                    {
                        isCurrentDNABetter = true;

                    }
                    else if (startingIndex == bestStartingIndex)
                    {
                        if (sum > bestSum)
                        {
                            isCurrentDNABetter = true;
                        }
                    }
                }

                if (isCurrentDNABetter)
                {
                    longestSequence = bestCurrentSequenceLength;
                    bestSequence = sequence;
                    bestSum = sum;
                    bestSequenceIndex = count;
                    bestStartingIndex = startingIndex;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
