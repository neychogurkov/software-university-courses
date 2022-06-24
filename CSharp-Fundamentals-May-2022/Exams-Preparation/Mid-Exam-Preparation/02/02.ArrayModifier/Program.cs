using System;
using System.Linq;

namespace _02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "swap":
                        {
                            int firstIndex = int.Parse(tokens[1]);
                            int secondIndex = int.Parse(tokens[2]);

                            int temp = numbers[firstIndex];
                            numbers[firstIndex] = numbers[secondIndex];
                            numbers[secondIndex] = temp;

                            break;
                        }
                    case "multiply":
                        {
                            int firstIndex = int.Parse(tokens[1]);
                            int secondIndex = int.Parse(tokens[2]);
                            numbers[firstIndex] *= numbers[secondIndex];
                            break;
                        }
                    case "decrease":
                        {
                            numbers = numbers.Select(n => --n).ToArray();
                            break;
                        }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}