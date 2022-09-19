using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            char[,] matrix = new char[rowsCount, colsCount];

            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(snake);

            FillMatrix(matrix, snake, queue);

            PrintMatrix(matrix);
        }

        static void FillMatrix(char[,] matrix, string snake, Queue<char> queue)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = queue.Dequeue();

                        if (queue.Count == 0)
                        {
                            queue = new Queue<char>(snake);
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = queue.Dequeue();

                        if (queue.Count == 0)
                        {
                            queue = new Queue<char>(snake);
                        }
                    }
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
