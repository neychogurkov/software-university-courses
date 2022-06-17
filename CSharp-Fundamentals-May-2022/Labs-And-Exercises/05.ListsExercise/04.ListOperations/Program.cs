using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        {
                            int number = int.Parse(tokens[1]);
                            numbers.Add(number);
                            break;
                        }
                    case "Insert":
                        {
                            int number = int.Parse(tokens[1]);
                            int index = int.Parse(tokens[2]);

                            if (index < 0 || index >= numbers.Count)
                            {
                                Console.WriteLine("Invalid index");
                            }
                            else
                            {
                                numbers.Insert(index, number);
                            }
                            break;
                        }
                    case "Remove":
                        {
                            int index = int.Parse(tokens[1]);

                            if (index < 0 || index >= numbers.Count)
                            {
                                Console.WriteLine("Invalid index");
                            }
                            else
                            {
                                numbers.RemoveAt(index);
                            }
                            break;
                        }
                    case "Shift":
                        {
                            int count = int.Parse(tokens[2]);
                            ShiftList(numbers, count, tokens[1]);
                            break;
                        }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void ShiftList(List<int> list, int count, string direction)
        {
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    list.Add(list[0]);
                    list.RemoveAt(0);
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < count; i++)
                {
                    list.Insert(0, list[list.Count - 1]);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
