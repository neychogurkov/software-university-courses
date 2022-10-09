using System;

namespace _02.HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int moleRow = 0;
            int moleCol = 0;
            bool isFirstSpecialLocation = true;
            int firstSpecialRow = 0;
            int firstSpecialCol = 0;
            int secondSpecialRow = 0;
            int secondSpecialCol = 0;

            char[,] field = GetFieldData(size, ref moleRow, ref moleCol, ref isFirstSpecialLocation, ref firstSpecialRow, ref firstSpecialCol, ref secondSpecialRow, ref secondSpecialCol);

            int molePoints = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "End" || molePoints >= 25)
                {
                    break;
                }

                MoveMole(size, field, ref moleRow, ref moleCol, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol, ref molePoints, direction);
            }

            Console.WriteLine(molePoints >= 25
                ? "Yay! The Mole survived another game!" + Environment.NewLine + $"The Mole managed to survive with a total of {molePoints} points."
                : "Too bad! The Mole lost this battle!" + Environment.NewLine + $"The Mole lost the game with a total of {molePoints} points.");

            PrintField(size, field);
        }

        static char[,] GetFieldData(int size, ref int moleRow, ref int moleCol, ref bool isFirstSpecialLocation, ref int firstSpecialRow, ref int firstSpecialCol, ref int secondSpecialRow, ref int secondSpecialCol)
        {
            char[,] field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = line[col];

                    if (field[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                    else if (field[row, col] == 'S')
                    {
                        if (isFirstSpecialLocation)
                        {
                            firstSpecialRow = row;
                            firstSpecialCol = col;
                            isFirstSpecialLocation = false;
                        }
                        else
                        {
                            secondSpecialRow = row;
                            secondSpecialCol = col;
                        }
                    }
                }
            }

            return field;
        }

        static void MoveMole(int size, char[,] field, ref int moleRow, ref int moleCol, int firstSpecialRow, int firstSpecialCol, int secondSpecialRow, int secondSpecialCol, ref int molePoints, string direction)
        {
            switch (direction)
            {
                case "up":
                    if (moleRow - 1 >= 0)
                    {
                        field[moleRow, moleCol] = '-';
                        moleRow--;
                        ChangePointsAndPosition(field, ref moleRow, ref moleCol, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol, ref molePoints);
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    break;
                case "down":
                    if (moleRow + 1 < size)
                    {
                        field[moleRow, moleCol] = '-';
                        moleRow++;
                        ChangePointsAndPosition(field, ref moleRow, ref moleCol, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol, ref molePoints);
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    break;
                case "left":
                    if (moleCol - 1 >= 0)
                    {
                        field[moleRow, moleCol] = '-';
                        moleCol--;
                        ChangePointsAndPosition(field, ref moleRow, ref moleCol, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol, ref molePoints);
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    break;
                case "right":
                    if (moleCol + 1 < size)
                    {
                        field[moleRow, moleCol] = '-';
                        moleCol++;
                        ChangePointsAndPosition(field, ref moleRow, ref moleCol, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol, ref molePoints);
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    break;
            }
        }

        static void ChangePointsAndPosition(char[,] field, ref int moleRow, ref int moleCol, int firstSpecialRow, int firstSpecialCol, int secondSpecialRow, int secondSpecialCol, ref int molePoints)
        {
            if (char.IsDigit(field[moleRow, moleCol]))
            {
                molePoints += int.Parse(field[moleRow, moleCol].ToString());
            }
            else if (field[moleRow, moleCol] == 'S')
            {
                field[moleRow, moleCol] = '-';
                molePoints -= 3;

                if (moleRow == firstSpecialRow && moleCol == firstSpecialCol)
                {
                    moleRow = secondSpecialRow;
                    moleCol = secondSpecialCol;
                }
                else if (moleRow == secondSpecialRow && moleCol == secondSpecialCol)
                {
                    moleRow = firstSpecialRow;
                    moleCol = firstSpecialCol;
                }
            }

            field[moleRow, moleCol] = 'M';
        }

        static void PrintField(int size, char[,] field)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
