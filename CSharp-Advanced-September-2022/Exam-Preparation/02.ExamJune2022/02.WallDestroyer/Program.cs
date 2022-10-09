using System;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int vankoRow = 0;
            int vankoCol = 0;
            int holesMade = 1;
            int rodsCount = 0;
            char[,] wall = GetWallData(size, ref vankoRow, ref vankoCol);

            bool isElectrocuted = false;

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
                        if (vankoRow - 1 >= 0)
                        {
                            isElectrocuted = MoveVanko(wall, vankoRow - 1, vankoCol, ref holesMade, ref rodsCount, isElectrocuted);

                            if (!(wall[vankoRow - 1, vankoCol] == 'R' || isElectrocuted))
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoRow--;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                    case "down":
                        if (vankoRow + 1 < size)
                        {
                            isElectrocuted = MoveVanko(wall, vankoRow + 1, vankoCol, ref holesMade, ref rodsCount, isElectrocuted);

                            if (!(wall[vankoRow + 1, vankoCol] == 'R' || isElectrocuted))
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoRow++;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                    case "left":
                        if (vankoCol - 1 >= 0)
                        {
                            isElectrocuted = MoveVanko(wall, vankoRow, vankoCol - 1, ref holesMade, ref rodsCount, isElectrocuted);
                            if (!(wall[vankoRow, vankoCol - 1] == 'R' || isElectrocuted))
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoCol--;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                    case "right":
                        if (vankoCol + 1 < size)
                        {
                            isElectrocuted = MoveVanko(wall, vankoRow, vankoCol + 1, ref holesMade, ref rodsCount, isElectrocuted);

                            if (!(wall[vankoRow, vankoCol + 1] == 'R' || isElectrocuted))
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoCol++;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                }

                if (isElectrocuted)
                {
                    wall[vankoRow, vankoCol] = '*';
                    break;
                }
            }

            Console.WriteLine(isElectrocuted
                ? $"Vanko got electrocuted, but he managed to make {holesMade} hole(s)."
                : $"Vanko managed to make {holesMade} hole(s) and he hit only {rodsCount} rod(s).");

            PrintWall(size, wall);
        }

        static char[,] GetWallData(int size, ref int vankoRow, ref int vankoCol)
        {
            char[,] wall = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = line[col];

                    if (wall[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            return wall;
        }

        static bool MoveVanko(char[,] wall, int row, int col, ref int holesMade, ref int rodsCount, bool isElectrocuted)
        {
            if (wall[row, col] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodsCount++;
            }
            else if (wall[row, col] == 'C')
            {
                wall[row, col] = 'E';
                holesMade++;
                isElectrocuted = true;
            }
            else if (wall[row, col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
            }
            else
            {
                holesMade++;
            }

            return isElectrocuted;
        }

        static void PrintWall(int size, char[,] wall)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
