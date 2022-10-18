using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] beach = GetBeachData(size);

            int collectedTokens = 0;
            int opponentTokens = 0;

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Gong")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                if (!(row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length))
                {
                    continue;
                }

                if (command[0] == "Find")
                {
                    if (beach[row][col] == 'T')
                    {
                        collectedTokens++;
                        beach[row][col] = '-';
                    }
                }
                else if (command[0] == "Opponent")
                {
                    string direction = command[3];

                    if (beach[row][col] == 'T')
                    {
                        opponentTokens++;
                        beach[row][col] = '-';
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        switch (direction)
                        {
                            case "up":
                                row--;
                                break;
                            case "down":
                                row++;
                                break;
                            case "left":
                                col--;
                                break;
                            case "right":
                                col++;
                                break;
                        }

                        if (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length && beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
            }

            PrintBeach(beach);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static char[][] GetBeachData(int size)
        {
            char[][] beach = new char[size][];

            for (int row = 0; row < size; row++)
            {
                beach[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            return beach;
        }

        static void PrintBeach(char[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(' ', beach[row]));
            }
        }
    }
}
