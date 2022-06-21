using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            int moves = 0;

            while (input != "end")
            {
                moves++;

                int[] indexes = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstIndex = indexes[0];
                int secondIndex = indexes[1];

                if (firstIndex == secondIndex || firstIndex < 0 || firstIndex >= numbers.Count || secondIndex < 0 ||
                    secondIndex >= numbers.Count)
                {
                    numbers.Insert(numbers.Count / 2, $"-{moves}a");
                    numbers.Insert(numbers.Count / 2, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (numbers[firstIndex] == numbers[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {numbers[firstIndex]}!");
                    numbers.RemoveAt(firstIndex);
                    if (secondIndex > firstIndex)
                    {
                        numbers.RemoveAt(secondIndex - 1);
                    }
                    else
                    {
                        numbers.RemoveAt(secondIndex);
                    }

                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
