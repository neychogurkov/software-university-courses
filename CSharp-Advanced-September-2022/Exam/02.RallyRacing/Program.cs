using System;
using System.Linq;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();
            char[,] matrix = GetMatrixData(size);
            (int firstTunnelRow, int firstTunnelCol, int secondTunnelRow, int secondTunnelCol) = GetTunnelsPositions(matrix);
            int carRow = 0;
            int carCol = 0;
            int distanceCovered = 0;
            bool hasFinished = false;

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "End")
                {
                    break;
                }

                switch (direction)
                {
                    case "up":
                        carRow--;
                        break;
                    case "down":
                        carRow++;
                        break;
                    case "left":
                        carCol--;
                        break;
                    case "right":
                        carCol++;
                        break;
                }

                distanceCovered += 10;

                if (matrix[carRow, carCol] == 'T')
                {
                    distanceCovered += 20;
                    matrix[carRow, carCol] = '.';

                    if (carRow == firstTunnelRow && carCol == firstTunnelCol)
                    {
                        carRow = secondTunnelRow;
                        carCol = secondTunnelCol;
                    }
                    else
                    {
                        carRow = firstTunnelRow;
                        carCol = firstTunnelCol;
                    }
                }
                else if (matrix[carRow, carCol] == 'F')
                {
                    hasFinished = true;
                }

                matrix[carRow, carCol] = '.';

                if (hasFinished)
                {
                    break;
                }
            }

            Console.WriteLine(hasFinished
                ? $"Racing car {carNumber} finished the stage!"
                : $"Racing car {carNumber} DNF.");
            Console.WriteLine($"Distance covered {distanceCovered} km.");
            matrix[carRow, carCol] = 'C';
            PrintMatrix(matrix);
        }

        static char[,] GetMatrixData(int size)
        {
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        static (int, int, int, int) GetTunnelsPositions(char[,] matrix)
        {
            bool isFirstTunnel = true;
            int firstTunnelRow = 0;
            int firstTunnelCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T')
                    {
                        if (isFirstTunnel)
                        {
                            firstTunnelRow = row;
                            firstTunnelCol = col;
                            isFirstTunnel = false;
                        }
                        else
                        {
                            return (firstTunnelRow, firstTunnelCol, row, col);
                        }
                    }
                }
            }

            return (0, 0, 0, 0);
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
