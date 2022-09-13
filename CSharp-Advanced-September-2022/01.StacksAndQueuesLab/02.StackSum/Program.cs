using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(input);

            while (true)
            {
                string[] command = Console.ReadLine().ToLower().Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "add")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);

                    numbers.Push(firstNumber);
                    numbers.Push(secondNumber);
                }
                else if (command[0] == "remove")
                {
                    int count = int.Parse(command[1]);

                    if (count <= numbers.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }   
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
