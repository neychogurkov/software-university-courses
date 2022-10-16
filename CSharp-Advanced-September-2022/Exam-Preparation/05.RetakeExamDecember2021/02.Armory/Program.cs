using System;
using System.Drawing;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = GetArmoryData(size);
            (int officerRow, int officerCol) = GetInitialOfficerPosition(armory);
            (int firstMirrorRow, int firstMirrorCol, int secondMirrorRow, int secondMirrorCol) = GetMirrorsPositions(armory);

            int goldCoinsPaid = 0;

            while (goldCoinsPaid < 65)
            {
                armory[officerRow, officerCol] = '-';

                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        officerRow--;
                        break;
                    case "down":
                        officerRow++;
                        break;
                    case "left":
                        officerCol--;
                        break;
                    case "right":
                        officerCol++;
                        break;
                }

                if (officerRow >= 0 && officerRow < size && officerCol >= 0 && officerCol < size)
                {
                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        goldCoinsPaid += int.Parse(armory[officerRow, officerCol].ToString());
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        if(officerRow == firstMirrorRow && officerCol == firstMirrorCol)
                        {
                            officerRow = secondMirrorRow;
                            officerCol = secondMirrorCol;
                        }
                        else
                        {
                            officerRow = firstMirrorRow;
                            officerCol = firstMirrorCol;
                        }

                        armory[firstMirrorRow, firstMirrorCol] = '-';
                        armory[secondMirrorRow, secondMirrorCol] = '-';
                    }

                    armory[officerRow, officerCol] = 'A';
                }
                else
                {
                    break;
                }
            }

            if (goldCoinsPaid >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            else
            {
                Console.WriteLine("I do not need more swords!");
            }

            Console.WriteLine($"The king paid {goldCoinsPaid} gold coins.");

            PrintArmory(armory);
        }

        static char[,] GetArmoryData(int size)
        {
            char[,] armory = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = line[col];
                }
            }

            return armory;
        }

        static (int, int) GetInitialOfficerPosition(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'A')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static (int, int, int, int) GetMirrorsPositions(char[,] armory)
        {
            bool isFirstMirror = true;
            int firstMirrorRow = 0;
            int firstMirrorCol = 0;

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'M')
                    {
                        if (isFirstMirror)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                            isFirstMirror = false;
                        }
                        else
                        {
                            return (firstMirrorRow, firstMirrorCol, row, col);
                        }
                    }
                }
            }

            return (0, 0, 0, 0);
        }

        static void PrintArmory(char[,] armory)
        {
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
