using System;
using System.Linq;

namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            int[,] matrix = new int[rowsCount, colsCount];
            GetMatrixData(matrix);

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            GetMaxSumAndStartingPosition(matrix, ref maxSum, ref startRow, ref startCol);

            PrintMaxSumAndSquareMatrix(matrix, maxSum, startRow, startCol);
        }

        static void GetMatrixData(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        static void GetMaxSumAndStartingPosition(int[,] matrix, ref int maxSum, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;

                    for (int squareRow = 0; squareRow < 3; squareRow++)
                    {
                        for (int squareCol = 0; squareCol < 3; squareCol++)
                        {
                            sum += matrix[squareRow + row, squareCol + col];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }

        static void PrintMaxSumAndSquareMatrix(int[,] matrix, int maxSum, int startRow, int startCol)
        {
            Console.WriteLine($"Sum = {maxSum}");

            for (int squareRow = 0; squareRow < 3; squareRow++)
            {
                for (int squareCol = 0; squareCol < 3; squareCol++)
                {
                    Console.Write(matrix[squareRow + startRow, squareCol + startCol] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
