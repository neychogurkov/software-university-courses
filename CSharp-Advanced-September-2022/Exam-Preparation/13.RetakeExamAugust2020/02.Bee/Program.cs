using System;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = GetMatrixData(size);
            (int beeRow, int beeCol) = GetBeePosition(matrix);
            int pollinatedFlowers = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "End")
                {
                    break;
                }

                if (!MoveBee(matrix, direction, ref beeRow, ref beeCol, ref pollinatedFlowers))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }

            Console.WriteLine(pollinatedFlowers >= 5
                ? $"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");

            PrintMatrix(matrix);
        }

        static char[,] GetMatrixData(int size)
        {
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        static (int, int) GetBeePosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static bool IsValidIndex(char[,] matrix, int beeRow, int beeCol)
        {
            if (beeRow < 0 || beeRow >= matrix.GetLength(0) || beeCol < 0 || beeCol >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static bool MoveBee(char[,] matrix, string direction, ref int beeRow, ref int beeCol, ref int pollinatedFlowers)
        {
            matrix[beeRow, beeCol] = '.';

            switch (direction)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "left":
                    beeCol--;
                    break;
                case "right":
                    beeCol++;
                    break;
            }


            if (IsValidIndex(matrix, beeRow, beeCol))
            {
                if (matrix[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    MoveBee(matrix, direction, ref beeRow, ref beeCol, ref pollinatedFlowers);
                }

                matrix[beeRow, beeCol] = 'B';
            }
            else
            {
                return false;
            }

            return true;
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
