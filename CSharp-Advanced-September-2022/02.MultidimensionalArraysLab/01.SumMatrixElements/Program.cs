using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            int[,] matrix = new int[rowsCount, colsCount];
            int sum = GetMatrixDataAndGetSum(rowsCount, colsCount, matrix);

            Console.WriteLine(rowsCount);
            Console.WriteLine(colsCount);
            Console.WriteLine(sum);
        }

        static int GetMatrixDataAndGetSum(int rowsCount, int colsCount, int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                    sum += matrix[row, col];
                }
            }

            return sum;
        }
    }
}
