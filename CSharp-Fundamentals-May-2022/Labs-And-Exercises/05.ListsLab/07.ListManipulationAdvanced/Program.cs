using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            bool isChanged = false;

            while (input != "end")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Add":
                        {
                            int number = int.Parse(command[1]);
                            numbers.Add(number);
                            isChanged = true;
                            break;
                        }
                    case "Remove":
                        {
                            int number = int.Parse(command[1]);
                            numbers.Remove(number);
                            isChanged = true;
                            break;
                        }
                    case "RemoveAt":
                        {
                            int index = int.Parse(command[1]);
                            numbers.RemoveAt(index);
                            isChanged = true;
                            break;
                        }
                    case "Insert":
                        {
                            int number = int.Parse(command[1]);
                            int index = int.Parse(command[2]);
                            numbers.Insert(index, number);
                            isChanged = true;
                            break;
                        }
                    case "Contains":
                        {
                            int number = int.Parse(command[1]);
                            Console.WriteLine(numbers.Contains(number) ? "Yes" : "No such number");
                            break;
                        }
                    case "PrintEven":
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0).ToList()));
                            break;
                        }
                    case "PrintOdd":
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0).ToList()));
                            break;
                        }
                    case "GetSum":
                        {
                            Console.WriteLine(numbers.Sum());
                            break;
                        }
                    case "Filter":
                        {
                            string condition = command[1];
                            int number = int.Parse(command[2]);
                            Console.WriteLine(string.Join(" ", FilterList(numbers, condition, number)));
                            break;
                        }
                }

                input = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static List<int> FilterList(List<int> list, string condition, int number)
        {
            List<int> filteredList = new List<int>();

            switch (condition)
            {
                case ">":
                    filteredList = list.Where(n => n > number).ToList();
                    break;
                case "<":
                    filteredList = list.Where(n => n < number).ToList();
                    break;
                case ">=":
                    filteredList = list.Where(n => n >= number).ToList();
                    break;
                case "<=":
                    filteredList = list.Where(n => n <= number).ToList();
                    break;
            }

            return filteredList;
        }
    }
}
