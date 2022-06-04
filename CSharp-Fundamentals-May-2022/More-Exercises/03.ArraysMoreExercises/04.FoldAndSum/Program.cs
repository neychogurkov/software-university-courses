using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Channels;

namespace _04.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] leftNumbers = new int[inputArray.Length / 4];
            int[] rightNumbers = new int[inputArray.Length / 4];
            int[] secondRow = new int[inputArray.Length / 2];

            for (int i = 0; i < leftNumbers.Length; i++)
            {
                leftNumbers[i] = inputArray[i];
            }
            for (int i = 0; i < leftNumbers.Length/2; i++)
            {
                int swap = leftNumbers[i];
                leftNumbers[i] = leftNumbers[leftNumbers.Length - 1 - i];
                leftNumbers[leftNumbers.Length - 1 - i] = swap;
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondRow[i] = inputArray[i + leftNumbers.Length];
            }

            for (int i = 0; i < rightNumbers.Length; i++)
            {
                rightNumbers[i] = inputArray[i + leftNumbers.Length + secondRow.Length];
            }
            for (int i = 0; i < rightNumbers.Length/2; i++)
            {
                int swap = rightNumbers[i];
                rightNumbers[i] = rightNumbers[rightNumbers.Length - 1 - i];
                rightNumbers[rightNumbers.Length - 1 - i] = swap;
            }
            
            int[] firstRow = new int[leftNumbers.Length + rightNumbers.Length];

            for (int i = 0; i < firstRow.Length; i++)
            {
                if (i < leftNumbers.Length)
                {
                    firstRow[i] = leftNumbers[i];
                }
                else
                {
                    firstRow[i] = rightNumbers[i - rightNumbers.Length];
                }
            }

            int[] sumArray = new int[firstRow.Length];

            for (int i = 0; i < firstRow.Length; i++)
            {
                sumArray[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(" ", sumArray));
        }

    }
}
