using System;

namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0;

            if (operation == '+')
            {
                result = number1 + number2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{number1} + {number2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{number1} + {number2} = {result} - odd");
                }
            }
            else if (operation == '-')
            {
                result = number1 - number2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{number1} - {number2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{number1} - {number2} = {result} - odd");
                }
            }
            if (operation == '*')
            {
                result = number1 * number2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{number1} * {number2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{number1} * {number2} = {result} - odd");
                }
            }
            else if (operation == '/')
            {
                if (number2 == 0)
                {
                    Console.WriteLine($"Cannot divide {number1} by zero");
                    return;
                }
                result = (double)number1 / number2;
                Console.WriteLine($"{number1} / {number2} = {result:f2}");
            }
            else if (operation == '%')
            {
                if (number2 == 0)
                {
                    Console.WriteLine($"Cannot divide {number1} by zero");
                    return;
                }
                int remainder = number1 % number2;
                Console.WriteLine($"{number1} % {number2} = {remainder}");
            }
        }
    }
}
