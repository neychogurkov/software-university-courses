using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            char[,] lair = new char[rowsCount, colsCount];
            List<Bunny> bunnies = new List<Bunny>();

            (int playerRow, int playerCol) = GetLairData(lair, bunnies);

            char[] directions = Console.ReadLine().ToCharArray();

            bool hasWon = false;
            bool hasDied = false;

            foreach (char direction in directions)
            {
                MovePlayer(lair, ref playerRow, ref playerCol, ref hasWon, ref hasDied, direction);

                List<Bunny> newBunnies = new List<Bunny>();

                MultiplyBunnies(lair, bunnies, ref hasDied, newBunnies);

                if (hasWon || hasDied)
                {
                    break;
                }

                bunnies.AddRange(newBunnies);
            }

            PrintLair(lair);

            if (hasDied)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        static (int, int) GetLairData(char[,] lair, List<Bunny> bunnies)
        {
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = line[col];

                    if (lair[row, col] == 'B')
                    {
                        Bunny bunny = new Bunny(row, col);
                        bunnies.Add(bunny);
                    }
                    else if (lair[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            return (playerRow, playerCol);
        }

        static void MovePlayer(char[,] lair, ref int playerRow, ref int playerCol, ref bool hasWon, ref bool hasDied, char direction)
        {
            switch (direction)
            {
                case 'L':
                    if (playerCol - 1 >= 0)
                    {
                        lair[playerRow, playerCol] = '.';

                        if (lair[playerRow, playerCol - 1] == 'B')
                        {
                            hasDied = true;
                        }
                        else
                        {
                            lair[playerRow, playerCol - 1] = 'P';
                        }

                        playerCol--;
                    }
                    else
                    {
                        hasWon = true;
                    }
                    break;
                case 'R':
                    if (playerCol + 1 < lair.GetLength(1))
                    {
                        lair[playerRow, playerCol] = '.';

                        if (lair[playerRow, playerCol + 1] == 'B')
                        {
                            hasDied = true;
                        }
                        else
                        {
                            lair[playerRow, playerCol + 1] = 'P';
                        }

                        playerCol++;

                    }
                    else
                    {
                        hasWon = true;
                    }
                    break;
                case 'U':
                    if (playerRow - 1 >= 0)
                    {
                        lair[playerRow, playerCol] = '.';

                        if (lair[playerRow - 1, playerCol] == 'B')
                        {
                            hasDied = true;
                        }
                        else
                        {
                            lair[playerRow - 1, playerCol] = 'P';
                        }

                        playerRow--;

                    }
                    else
                    {
                        hasWon = true;
                    }
                    break;
                case 'D':
                    if (playerRow + 1 < lair.GetLength(0))
                    {
                        lair[playerRow, playerCol] = '.';

                        if (lair[playerRow + 1, playerCol] == 'B')
                        {
                            hasDied = true;
                        }
                        else
                        {
                            lair[playerRow + 1, playerCol] = 'P';
                        }

                        playerRow++;

                    }
                    else
                    {
                        hasWon = true;
                    }
                    break;
            }

            if (hasWon)
            {
                lair[playerRow, playerCol] = '.';
            }
        }

        static void MultiplyBunnies(char[,] lair, List<Bunny> bunnies, ref bool hasDied, List<Bunny> newBunnies)
        {
            foreach (var bunny in bunnies)
            {
                int row = bunny.Row;
                int col = bunny.Col;

                if (row - 1 >= 0)
                {
                    if (lair[row - 1, col] == '.')
                    {
                        newBunnies.Add(new Bunny(row - 1, col));
                    }
                    else if (lair[row - 1, col] == 'P')
                    {
                        hasDied = true;
                    }

                    lair[row - 1, col] = 'B';
                }

                if (row + 1 < lair.GetLength(0))
                {
                    if (lair[row + 1, col] == '.')
                    {
                        newBunnies.Add(new Bunny(row + 1, col));
                    }
                    else if (lair[row + 1, col] == 'P')
                    {
                        hasDied = true;
                    }

                    lair[row + 1, col] = 'B';
                }

                if (col - 1 >= 0)
                {
                    if (lair[row, col - 1] == '.')
                    {
                        newBunnies.Add(new Bunny(row, col - 1));
                    }
                    else if (lair[row, col - 1] == 'P')
                    {
                        hasDied = true;
                    }

                    lair[row, col - 1] = 'B';
                }

                if (col + 1 < lair.GetLength(1))
                {
                    if (lair[row, col + 1] == '.')
                    {
                        newBunnies.Add(new Bunny(row, col + 1));
                    }
                    else if (lair[row, col + 1] == 'P')
                    {
                        hasDied = true;
                    }

                    lair[row, col + 1] = 'B';
                }
            }
        }

        static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }
        }
    }

    class Bunny
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Bunny(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
