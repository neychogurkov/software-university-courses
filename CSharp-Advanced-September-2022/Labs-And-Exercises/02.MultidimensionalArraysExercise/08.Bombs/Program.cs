using System;
using System.Linq;

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            GetMatrixData(matrix);

            string[] bombsCoordinates = Console.ReadLine().Split();

            ExplodeBombs(matrix, bombsCoordinates);

            PrintCountAndSumOfAliveCells(matrix);

            PrintMatrix(matrix);
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

        static void ExplodeBombs(int[,] matrix, string[] bombsCoordinates)
        {
            foreach (var bombCoordinates in bombsCoordinates)
            {
                int bombRow = int.Parse(bombCoordinates.Split(',')[0]);
                int bombCol = int.Parse(bombCoordinates.Split(',')[1]);
                int bombPower = matrix[bombRow, bombCol];

                if (bombPower <= 0)
                {
                    continue;
                }

                int startRow = Math.Max(bombRow - 1, 0);
                int endRow = Math.Min(bombRow + 1, matrix.GetLength(0) - 1);
                int startCol = Math.Max(bombCol - 1, 0);
                int endCol = Math.Min(bombCol + 1, matrix.GetLength(1) - 1);

                for (int row = startRow; row <= endRow; row++)
                {
                    for (int col = startCol; col <= endCol; col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= bombPower;
                        }
                    }
                }
            }
        }

        static void PrintCountAndSumOfAliveCells(int[,] matrix)
        {
            int countOfAliveCells = 0;
            int sumOfAliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countOfAliveCells++;
                        sumOfAliveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
