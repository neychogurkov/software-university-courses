using System;

namespace _02.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] previousRow = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] currentRow = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        currentRow[j] = 1;
                    }
                    else
                    {
                        currentRow[j] = previousRow[j - 1] + previousRow[j];
                    }
                    Console.Write(currentRow[j] + " ");
                }

                previousRow = currentRow;
                Console.WriteLine();
            }
        }
    }
}
