using System;
using System.Drawing;

namespace _02.Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] bakery = GetBakeryData(size);
            (int row, int col) = GetStartingPosition(bakery);
            (int firstPillarRow, int firstPillarCol, int secondPillarRow, int secondPillarCol) = GetPillarsPositions(bakery);
            int collectedMoney = 0;

            while (collectedMoney < 50)
            {
                string direction = Console.ReadLine();

                bakery[row, col] = '-';

                switch (direction)
                {
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    case "left":
                        col--;
                        break;
                    case "right":
                        col++;
                        break;
                }

                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    break;
                }

                if (char.IsDigit(bakery[row, col]))
                {
                    collectedMoney += int.Parse(bakery[row, col].ToString());
                }
                else if (bakery[row, col] == 'O')
                {
                    bakery[row, col] = '-';

                    if (row == firstPillarRow && col == firstPillarCol)
                    {
                        row = secondPillarRow;
                        col = secondPillarCol;
                    }
                    else
                    {
                        row = firstPillarRow;
                        col = firstPillarCol;
                    }
                }

                bakery[row, col] = 'S';
            }

            Console.WriteLine(collectedMoney >= 50
                ? "Good news! You succeeded in collecting enough money!"
                : "Bad news, you are out of the bakery.");
            Console.WriteLine($"Money: {collectedMoney}");

            PrintBakery(bakery);
        }
        
        static char[,] GetBakeryData(int size)
        {
            char[,] bakery = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = line[col];
                }
            }

            return bakery;
        }

        static (int, int) GetStartingPosition(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col] == 'S')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static (int, int, int, int) GetPillarsPositions(char[,] bakery)
        {
            bool isFirstPillar = true;
            int firstPillarRow = 0;
            int firsPillarCol = 0;

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col] == 'O')
                    {
                        if (isFirstPillar)
                        {
                            firstPillarRow = row;
                            firsPillarCol = col;
                            isFirstPillar = false;
                        }
                        else
                        {
                            return (firstPillarRow, firsPillarCol, row, col);
                        }
                    }
                }
            }

            return (0, 0, 0, 0);
        }

        static void PrintBakery(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }

    }
}
