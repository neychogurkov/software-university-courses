using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                int element = int.Parse(tokens[1]);

                if (tokens[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == element);
                }
                else if (tokens[0] == "Insert")
                {
                    int position = int.Parse(tokens[2]);
                    numbers.Insert(position, element);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
