using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            int[,] matrix = new int[rowsCount, colsCount];
            GetMatrixData(matrix);

            int maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            GetMaxSumAndStartingPosition(matrix, ref maxSum, ref bestRow, ref bestCol);

            PrintBestSquareAndMaxSum(matrix, maxSum, bestRow, bestCol);
        }

        static void GetMatrixData(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
        
        static void GetMaxSumAndStartingPosition(int[,] matrix, ref int maxSum, ref int bestRow, ref int bestCol)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSquareSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSquareSum > maxSum)
                    {
                        maxSum = currentSquareSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
        }

        static void PrintBestSquareAndMaxSum(int[,] matrix, int maxSum, int bestRow, int bestCol)
        {
            for (int row = bestRow; row < bestRow + 2; row++)
            {
                for (int col = bestCol; col < bestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
