using System;
using System.Linq;

namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            string[] minerDirections = Console.ReadLine().Split();

            int minerRow = 0;
            int minerCol = 0;
            int coalsCount = 0;

            GetFieldData(field, ref minerRow, ref minerCol, ref coalsCount);

            foreach (var direction in minerDirections)
            {
                bool hasChangedPosition = false;

                MoveMiner(field, ref minerRow, ref minerCol, direction, ref hasChangedPosition);

                if (hasChangedPosition)
                {
                    if (field[minerRow, minerCol] == 'c')
                    {
                        coalsCount--;
                        field[minerRow, minerCol] = '*';

                        if (coalsCount == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                    else if (field[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        return;
                    }
                }

            }

            Console.WriteLine($"{coalsCount} coals left. ({minerRow}, {minerCol})");
        }

        static void GetFieldData(char[,] field, ref int minerRow, ref int minerCol, ref int coalsCount)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < field.GetLength(0); col++)
                {
                    field[row, col] = line[col];

                    if (field[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (field[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
        }

        static void MoveMiner(char[,] field, ref int minerRow, ref int minerCol, string direction, ref bool hasChangedPosition)
        {
            switch (direction)
            {
                case "up":
                    if (minerRow - 1 >= 0)
                    {
                        minerRow--;
                        hasChangedPosition = true;
                    }
                    break;
                case "left":
                    if (minerCol - 1 >= 0)
                    {
                        minerCol--;
                        hasChangedPosition = true;
                    }
                    break;
                case "down":
                    if (minerRow + 1 < field.GetLength(0))
                    {
                        minerRow++;
                        hasChangedPosition = true;
                    }
                    break;
                case "right":
                    if (minerCol + 1 < field.GetLength(0))
                    {
                        minerCol++;
                        hasChangedPosition = true;
                    }
                    break;
            }
        }
    }
}
