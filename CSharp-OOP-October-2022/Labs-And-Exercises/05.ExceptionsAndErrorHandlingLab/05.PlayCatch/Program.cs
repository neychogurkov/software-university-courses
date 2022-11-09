using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int caughtExceptionsCount = 0;

            while (caughtExceptionsCount < 3)
            {
                string[] command = Console.ReadLine().Split();

                try
                {
                    ProcessCommand(numbers, command);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    caughtExceptionsCount++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    caughtExceptionsCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ProcessCommand(int[] numbers, string[] command)
        {
            string commandType = command[0];
            int index = int.Parse(command[1]);

            if (commandType == "Replace")
            {
                int element = int.Parse(command[2]);
                numbers[index] = element;
            }
            else if (commandType == "Print")
            {
                int endIndex = int.Parse(command[2]);

                List<int> numbersToPrint = new List<int>();

                for (int i = index; i <= endIndex; i++)
                {
                    numbersToPrint.Add(numbers[i]);
                }

                Console.WriteLine(string.Join(", ", numbersToPrint));
            }
            else if (commandType == "Show")
            {
                Console.WriteLine(numbers[index]);
            }
        }
    }
}
