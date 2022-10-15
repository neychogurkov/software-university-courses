using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = GetPondData(size);
            (int beaverRow, int beaverCol) = SetInitialBeaverPosition(pond);
            int woodBranchesLeft = GetWoodBranchesCount(pond);

            LinkedList<char> woodBranches = new LinkedList<char>();

            while (true)
            {
                string direction = Console.ReadLine();
                int oldBeaverRow = beaverRow;
                int oldBeaverCol = beaverCol;

                if (direction == "end")
                {
                    break;
                }

                switch (direction)
                {
                    case "up":
                        beaverRow--;
                        break;
                    case "down":
                        beaverRow++;
                        break;
                    case "left":
                        beaverCol--;
                        break;
                    case "right":
                        beaverCol++;
                        break;
                }

                if (beaverRow >= 0 && beaverRow < size && beaverCol >= 0 && beaverCol < size)
                {
                    pond[oldBeaverRow, oldBeaverCol] = '-';
                    (beaverRow, beaverCol) = MoveBeaver(size, pond, direction, beaverRow, beaverCol, woodBranches, ref woodBranchesLeft);
                }
                else
                {
                    beaverRow = oldBeaverRow;
                    beaverCol = oldBeaverCol;

                    if (woodBranches.Any())
                    {
                        woodBranches.RemoveLast();
                    }
                }

                if (woodBranchesLeft == 0)
                {
                    break;
                }
            }

            if (woodBranchesLeft == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {woodBranches.Count} wood branches: {string.Join(", ", woodBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodBranchesLeft} branches left.");
            }

            PrintPond(pond);
        }

        static char[,] GetPondData(int size)
        {
            char[,] pond = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = line[col];
                }
            }

            return pond;
        }

        static (int, int) SetInitialBeaverPosition(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (pond[row, col] == 'B')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static int GetWoodBranchesCount(char[,] pond)
        {
            int branches = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    if (char.IsLower(pond[row, col]))
                    {
                        branches++;
                    }
                }
            }

            return branches;
        }

        static (int, int) MoveBeaver(int size, char[,] pond, string direction, int beaverRow, int beaverCol, LinkedList<char> woodBranches, ref int woodBranchesLeft)
        {
            if (char.IsLower(pond[beaverRow, beaverCol]))
            {
                woodBranches.AddLast(pond[beaverRow, beaverCol]);
                woodBranchesLeft--;
            }
            else if (pond[beaverRow, beaverCol] == 'F')
            {
                pond[beaverRow, beaverCol] = '-';
                (beaverRow, beaverCol) = MoveBeaverToOppositePosition(size, direction, beaverRow, beaverCol);
                (beaverRow, beaverCol) = MoveBeaver(size, pond, direction, beaverRow, beaverCol, woodBranches, ref woodBranchesLeft);
            }

            pond[beaverRow, beaverCol] = 'B';

            return (beaverRow, beaverCol);
        }

        static (int, int) MoveBeaverToOppositePosition(int size, string direction, int beaverRow, int beaverCol)
        {
            switch (direction)
            {
                case "up":
                    if (beaverRow == 0)
                    {
                        beaverRow = size - 1;
                    }
                    else
                    {
                        beaverRow = 0;
                    }
                    break;
                case "down":
                    if (beaverRow == size - 1)
                    {
                        beaverRow = 0;
                    }
                    else
                    {
                        beaverRow = size - 1;
                    }
                    break;
                case "left":
                    if (beaverCol == 0)
                    {
                        beaverCol = size - 1;
                    }
                    else
                    {
                        beaverCol = 0;
                    }
                    break;
                case "right":
                    if (beaverCol == size - 1)
                    {
                        beaverCol = 0;
                    }
                    else
                    {
                        beaverCol = size - 1;
                    }
                    break;
            }

            return (beaverRow, beaverCol);
        }

        static void PrintPond(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
