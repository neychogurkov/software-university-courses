using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            GetMatrixData(matrix);

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primaryDiagonalSum += matrix[row, row];
                secondaryDiagonalSum+= matrix[row, matrix.GetLength(0) - 1 - row];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum-secondaryDiagonalSum));
        }

        static void GetMatrixData(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}
