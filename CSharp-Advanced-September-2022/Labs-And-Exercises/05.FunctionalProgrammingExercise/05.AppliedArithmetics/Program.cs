using System;
using System.Linq;
using System.Security;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "print")
                {
                    print(numbers);
                    continue;
                }

                Func<int, int> modifyNumber = ModifyNumber(command);
                numbers = numbers.Select(x => modifyNumber(x)).ToArray();
            }
        }

        static Func<int, int> ModifyNumber(string command)
        {
            switch (command)
            {
                case "add":
                    return n => ++n;
                case "subtract":
                    return n => --n;
                case "multiply":
                    return n => n * 2;
                default:
                    return null;
            }
        }
    }
}
