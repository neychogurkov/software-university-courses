using System;
using System.Linq;

namespace _02.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] attackCoordinates = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;
            char[,] field = GetFieldData(size, ref firstPlayerShipsCount, ref secondPlayerShipsCount);
            int totalShipsCount = firstPlayerShipsCount + secondPlayerShipsCount;

            bool isDraw = true;

            for (int i = 0; i < attackCoordinates.Length; i += 2)
            {
                int row = attackCoordinates[i];
                int col = attackCoordinates[i + 1];

                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    continue;
                }

                if (field[row, col] == '<')
                {
                    firstPlayerShipsCount--;
                    field[row, col] = 'X';
                }
                else if (field[row, col] == '>')
                {
                    secondPlayerShipsCount--;
                    field[row, col] = 'X';
                }
                else if (field[row, col] == '#')
                {
                    int rowStartIndex = Math.Max(0, row - 1);
                    int rowEndIndex = Math.Min(size - 1, row + 1);
                    int colStartIndex = Math.Max(0, col - 1);
                    int colEndIndex = Math.Min(size - 1, col + 1);

                    for (int mineRow = rowStartIndex; mineRow <= rowEndIndex; mineRow++)
                    {
                        for (int mineCol = colStartIndex; mineCol <= colEndIndex; mineCol++)
                        {
                            if (field[mineRow, mineCol] == '<')
                            {
                                firstPlayerShipsCount--;
                            }
                            else if (field[mineRow, mineCol] == '>')
                            {
                                secondPlayerShipsCount--;
                            }

                            field[row, col] = 'X';
                        }
                    }
                }

                if (firstPlayerShipsCount == 0 || secondPlayerShipsCount == 0)
                {
                    isDraw = false;
                    break;
                }
            }

            if (isDraw)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} ships left. Player Two has {secondPlayerShipsCount} ships left.");
            }
            else
            {
                Console.WriteLine($"Player {(firstPlayerShipsCount == 0 ? "Two" : "One")} has won the game! {totalShipsCount - (firstPlayerShipsCount + secondPlayerShipsCount)} ships have been sunk in the battle.");
            }
        }

        static char[,] GetFieldData(int size, ref int firstPlayerShipsCount, ref int secondPlayerShipsCount)
        {
            char[,] field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = line[col];

                    if (field[row, col] == '<')
                    {
                        firstPlayerShipsCount++;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlayerShipsCount++;
                    }
                }
            }

            return field;
        }
    }
}
