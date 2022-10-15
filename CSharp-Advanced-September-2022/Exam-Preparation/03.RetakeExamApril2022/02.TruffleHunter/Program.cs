using System;
using System.Drawing;
using System.Linq;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = GetForestData(size);

            int blackTrufflesCount = 0;
            int summerTrufflesCount = 0;
            int whiteTrufflesCount = 0;
            int eatenTruffles = 0;

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Stop")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                if (command[0] == "Collect")
                {
                    if (row >= 0 && row < size && col >= 0 && col < size && forest[row, col] != '-')
                    {
                        CollectTruffle(forest, row, col, ref blackTrufflesCount, ref summerTrufflesCount, ref whiteTrufflesCount);
                    }
                }
                else if (command[0] == "Wild_Boar")
                {
                    string direction = command[3];

                    switch (direction)
                    {
                        case "up":
                            for (int i = row; i >= 0; i -= 2)
                            {
                                eatenTruffles = EatTruffle(forest, eatenTruffles, i, col);
                            }
                            break;
                        case "down":
                            for (int i = row; i < size; i += 2)
                            {
                                eatenTruffles = EatTruffle(forest, eatenTruffles, i, col);
                            }
                            break;
                        case "left":
                            for (int i = col; i >= 0; i -= 2)
                            {
                                eatenTruffles = EatTruffle(forest, eatenTruffles, row, i);
                            }
                            break;
                        case "right":
                            for (int i = col; i < size; i += 2)
                            {
                                eatenTruffles = EatTruffle(forest, eatenTruffles, row, i);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCount} black, {summerTrufflesCount} summer, and {whiteTrufflesCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");

            PrintForest(forest);
        }

        static char[,] GetForestData(int size)
        {
            char[,] forest = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = line[col];
                }
            }

            return forest;
        }

        static void CollectTruffle(char[,] forest, int row, int col, ref int blackTrufflesCount, ref int summerTrufflesCount, ref int whiteTrufflesCount)
        {
            if (forest[row, col] == 'B')
            {
                blackTrufflesCount++;
            }
            else if (forest[row, col] == 'S')
            {
                summerTrufflesCount++;
            }
            else if (forest[row, col] == 'W')
            {
                whiteTrufflesCount++;
            }

            forest[row, col] = '-';
        }

        static int EatTruffle(char[,] forest, int eatenTruffles, int row, int col)
        {
            if (forest[row, col] == 'B' || forest[row, col] == 'S' || forest[row, col] == 'W')
            {
                eatenTruffles++;
                forest[row, col] = '-';
            }

            return eatenTruffles;
        }

        static void PrintForest(char[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
