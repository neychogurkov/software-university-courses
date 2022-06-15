using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Add":
                        {
                            int number = int.Parse(command[1]);
                            numbers.Add(number);
                            break;
                        }
                    case "Remove":
                        {
                            int number = int.Parse(command[1]);
                            numbers.Remove(number);
                            break;
                        }
                    case "RemoveAt":
                        {
                            int index = int.Parse(command[1]);
                            numbers.RemoveAt(index);
                            break;
                        }
                    case "Insert":
                        {
                            int number = int.Parse(command[1]);
                            int index = int.Parse(command[2]);
                            numbers.Insert(index, number);
                            break;
                        }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
