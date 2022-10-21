using System;

namespace _02.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int directionsCount = int.Parse(Console.ReadLine());
            char[,] field = GetFieldData(size);
            (int playerRow, int playerCol) = GetPlayerPosition(field);
            bool hasWon = false;

            for (int i = 0; i < directionsCount; i++)
            {
                string direction = Console.ReadLine();

                ModifyField(field, size, direction, ref playerRow, ref playerCol, ref hasWon);

                if (hasWon)
                {
                    break;
                }
            }

            Console.WriteLine($"Player {(hasWon ? "won" : "lost")}!");
            PrintField(field);
        }

        static char[,] GetFieldData(int size)
        {
            char[,] field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = line[col];
                }
            }

            return field;
        }

        static (int, int) GetPlayerPosition(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'f')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static void ModifyField(char[,] field, int size, string direction, ref int playerRow, ref int playerCol, ref bool hasWon)
        {
            if (field[playerRow, playerCol] != 'B' && field[playerRow, playerCol] != 'T')
            {
                field[playerRow, playerCol] = '-';
            }

            int oldPlayerRow = playerRow;
            int oldPlayerCol = playerCol;

            MovePlayer(size, direction, ref playerRow, ref playerCol);

            if (field[playerRow, playerCol] == 'B')
            {
                ModifyField(field, size, direction, ref playerRow, ref playerCol, ref hasWon);
            }
            else if (field[playerRow, playerCol] == 'T')
            {
                playerRow = oldPlayerRow;
                playerCol = oldPlayerCol;
            }
            else if (field[playerRow, playerCol] == 'F')
            {
                field[playerRow, playerCol] = 'f';
                hasWon = true;
                return;
            }

            field[playerRow, playerCol] = 'f';
        }

        static void MovePlayer(int size, string direction, ref int playerRow, ref int playerCol)
        {
            switch (direction)
            {
                case "up":
                    playerRow--;

                    if (playerRow < 0)
                    {
                        playerRow = size - 1;
                    }
                    break;
                case "down":
                    playerRow++;

                    if (playerRow >= size)
                    {
                        playerRow = 0;
                    }
                    break;
                case "left":
                    playerCol--;

                    if (playerCol < 0)
                    {
                        playerCol = size - 1;
                    }
                    break;
                case "right":
                    playerCol++;

                    if (playerCol >= size)
                    {
                        playerCol = 0;
                    }
                    break;
            }
        }

        static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
