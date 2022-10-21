using System;

namespace _02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = GetMatrixData(size);
            (int snakeRow, int snakeCol) = GetSnakePosition(matrix);
            (int firstBurrowRow, int firstBurrowCol, int secondBurrowRow, int secondBurrowCol) = GetBurrowsPositions(matrix);

            int foodQuantity = 0;

            while (foodQuantity < 10)
            {
                string direction = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.';

                switch (direction)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                }

                if (snakeRow < 0 || snakeRow >= matrix.GetLength(0) || snakeCol < 0 || snakeCol >= matrix.GetLength(1))
                {
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }

                matrix[snakeRow, snakeCol] = 'S';
            }

            if (foodQuantity == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
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

        static (int, int, int, int) GetBurrowsPositions(char[,] matrix)
        {
            bool isFirstBurrow = true;
            int firstBurrowRow = 0;
            int firstBurrowCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (isFirstBurrow)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                            isFirstBurrow = false;
                        }
                        else
                        {
                            return (firstBurrowRow, firstBurrowCol, row, col);
                        }
                    }
                }
            }

            return (0, 0, 0, 0);
        }

        static (int, int) GetSnakePosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
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
    }
}
