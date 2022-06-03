using System;
using System.Linq;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugIndexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];

            for (int i = 0; i < ladybugIndexes.Length; i++)
            {
                int currentIndex = ladybugIndexes[i];
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 1;
                }
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split();
                int index = int.Parse(command[0]);
                string direction = command[1];
                int flyLength = int.Parse(command[2]);

                if (index < 0 || index > field.Length - 1 || field[index] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                field[index] = 0;

                if (direction == "right")
                {
                    int landIndex = index + flyLength;
                    if (landIndex > field.Length - 1)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    while (field[landIndex] == 1)
                    {
                        landIndex += flyLength;
                        if (landIndex >= fieldSize)
                        {
                            break;
                        }
                    }
                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {
                        field[landIndex] = 1;
                    }
                }
                else if (direction == "left")
                {
                    int landIndex = index - flyLength;
                    if (landIndex < 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    while (field[landIndex] == 1)
                    {
                        landIndex -= flyLength;
                        if (landIndex < 0)
                        {
                            break;
                        }
                    }

                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {
                        field[landIndex] = 1;
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
