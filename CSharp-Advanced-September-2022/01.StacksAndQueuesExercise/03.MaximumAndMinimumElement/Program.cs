using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCommands = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                ExecuteCommands(stack, command);
            }

            Console.WriteLine(string.Join(", ", stack));
        }

        static void ExecuteCommands(Stack<int> stack, string command)
        {
            if (command.StartsWith('1'))
            {
                stack.Push(int.Parse(command.Split()[1]));
            }
            else if (command == "2")
            {
                stack.Pop();
            }
            else if (command == "3")
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
            }
            else if (command == "4")
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
