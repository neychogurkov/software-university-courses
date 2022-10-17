using System;

namespace _02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int size = int.Parse(Console.ReadLine());
            char[][] field = GetFieldData(size);
            (int armyRow, int armyCol) = GetArmyPosition(field);

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                string direction = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                field[row][col] = 'O';

                int oldArmyRow = armyRow;
                int oldArmyCol = armyCol;

                switch (direction)
                {
                    case "up":
                        armyRow--;
                        break;
                    case "down":
                        armyRow++;
                        break;
                    case "left":
                        armyCol--;
                        break;
                    case "right":
                        armyCol++;
                        break;
                }

                armor--;

                if (armyRow >= 0 && armyRow < size && armyCol >= 0 && armyCol < size)
                {
                    field[oldArmyRow][oldArmyCol] = '-';

                    if (field[armyRow][armyCol] == 'O')
                    {
                        armor -= 2;
                    }
                    else if (field[armyRow][armyCol] == 'M')
                    {
                        field[armyRow][armyCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        break;
                    }
                }
                else
                {
                    armyRow = oldArmyRow;
                    armyCol = oldArmyCol;
                }

                if (armor <= 0)
                {
                    field[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                field[armyRow][armyCol] = 'A';
            }

            PrintField(field);
        }

        static char[][] GetFieldData(int size)
        {
            char[][] field = new char[size][];

            for (int row = 0; row < size; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();
            }

            return field;
        }

        static (int, int) GetArmyPosition(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
