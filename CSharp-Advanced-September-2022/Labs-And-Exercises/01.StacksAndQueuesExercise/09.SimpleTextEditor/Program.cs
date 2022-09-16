using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split();

                ExecuteCommands(text, stack, command);
            }
        }

        static void ExecuteCommands(StringBuilder text, Stack<string> stack, string[] command)
        {
            switch (int.Parse(command[0]))
            {
                case 1:
                    stack.Push(text.ToString());

                    string textToAppend = command[1];
                    text.Append(textToAppend);
                    break;
                case 2:
                    stack.Push(text.ToString());

                    int count = int.Parse(command[1]);
                    text.Remove(text.Length - count, count);
                    break;
                case 3:
                    int index = int.Parse(command[1]);
                    Console.WriteLine(text[index - 1]);
                    break;
                case 4:
                    text.Clear().Append(stack.Pop());
                    break;
            }
        }
    }
}
