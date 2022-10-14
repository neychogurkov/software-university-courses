using System;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = GetWallData(size);

            int vankoRow = 0;
            int vankoCol = 0;
            GetVankoPosition(wall, ref vankoRow, ref vankoCol);

            int holesCount = 0;
            int rodsHit = 0;
            bool isElectrocuted = false;
            string direction;
            while ((direction = Console.ReadLine()) != "End")
            {
                bool hasMoved = false;
                int newVankoRow = 0;
                int newVankoCol = 0;

                switch (direction)
                {
                    case "left":
                        if (vankoCol - 1 >= 0)
                        {
                            MoveVanko(wall, vankoRow, vankoCol - 1, ref holesCount, ref rodsHit, ref isElectrocuted, ref hasMoved);
                            SetNewVankoPosition(vankoRow, vankoCol - 1, hasMoved, ref newVankoRow, ref newVankoCol);
                        }
                        break;
                    case "right":
                        if (vankoCol + 1 < size)
                        {
                            MoveVanko(wall, vankoRow, vankoCol + 1, ref holesCount, ref rodsHit, ref isElectrocuted, ref hasMoved);
                            SetNewVankoPosition(vankoRow, vankoCol + 1, hasMoved, ref newVankoRow, ref newVankoCol);
                        }
                        break;
                    case "up":
                        if (vankoRow - 1 >= 0)
                        {
                            MoveVanko(wall, vankoRow - 1, vankoCol, ref holesCount, ref rodsHit, ref isElectrocuted, ref hasMoved);
                            SetNewVankoPosition(vankoRow - 1, vankoCol, hasMoved, ref newVankoRow, ref newVankoCol);
                        }
                        break;
                    case "down":
                        if (vankoRow + 1 < size)
                        {
                            MoveVanko(wall, vankoRow + 1, vankoCol, ref holesCount, ref rodsHit, ref isElectrocuted, ref hasMoved);
                            SetNewVankoPosition(vankoRow + 1, vankoCol, hasMoved, ref newVankoRow, ref newVankoCol);
                        }
                        break;
                }

                if (hasMoved)
                {
                    wall[vankoRow, vankoCol] = '*';
                    vankoRow = newVankoRow;
                    vankoCol = newVankoCol;
                    wall[vankoRow, vankoCol] = 'V';

                    if (isElectrocuted)
                    {
                        wall[vankoRow, vankoCol] = 'E';
                        break;
                    }
                }
            }

            holesCount++;
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsHit} rod(s).");
            }

            PrintWall(wall);
        }

        static char[,] GetWallData(int size)
        {
            char[,] wall = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = line[col];
                }
            }

            return wall;
        }

        static void GetVankoPosition(char[,] wall, ref int vankoRow, ref int vankoCol)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    if (wall[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
        }

        static void MoveVanko(char[,] wall, int vankoRow, int vankoCol, ref int holesCount, ref int rodsHit, ref bool isElectrocuted, ref bool hasMoved)
        {
            if (wall[vankoRow, vankoCol] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodsHit++;
            }
            else if (wall[vankoRow, vankoCol] == 'C')
            {
                isElectrocuted = true;
                holesCount++;
                hasMoved = true;
            }
            else if (wall[vankoRow, vankoCol] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                hasMoved = true;
            }
            else
            {
                holesCount++;
                hasMoved = true;
            }
        }

        static void SetNewVankoPosition(int vankoRow, int vankoCol, bool hasMoved, ref int newVankoRow, ref int newVankoCol)
        {
            if (hasMoved)
            {
                newVankoRow = vankoRow;
                newVankoCol = vankoCol;
            }
        }

        static void PrintWall(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
