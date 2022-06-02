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
            int longestSubsequence = 0;
            int bestStartingIndex = int.MaxValue;
            int[] bestSequence = new int[length];
            int bestSum = 0;
            int bestSequenceIndex = 0;
            int count = 0;
            while (command != "Clone them!")
            {
                int[] sequence = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentSequenceLength = 0;
                int startingIndex = 0;
                int sum = 0;
                count++;

                for (int i = 0; i < sequence.Length; i++)
                {
                    sum += sequence[i];
                }

                for (int i = 0; i < sequence.Length - 1; i++)
                {
                    if (sequence[i] == 1 && sequence[i + 1] == 1)
                    {
                        currentSequenceLength++;
                    }
                    else
                    {
                        currentSequenceLength = 1;
                        startingIndex = i + 1;
                    }

                    if (currentSequenceLength > longestSubsequence)
                    {
                        bestStartingIndex = startingIndex;
                        if (i == 0)
                        {
                            bestSum = sum;
                        }
                        else
                        {
                            bestSum = currentSequenceLength;
                        }
                        longestSubsequence = currentSequenceLength;
                        bestSequence = sequence;
                        bestSequenceIndex = count;
                    }
                    else if (currentSequenceLength == longestSubsequence)
                    {
                        if (startingIndex < bestStartingIndex)
                        {
                            bestSequence = sequence;
                            bestStartingIndex = startingIndex;
                            bestSum = currentSequenceLength;
                            bestSequenceIndex = count;
                        }
                        else if (startingIndex == bestStartingIndex)
                        {
                            if (sum > bestSum)
                            {
                                bestSum = sum;
                                bestSequence = sequence;
                                bestSequenceIndex = count;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
