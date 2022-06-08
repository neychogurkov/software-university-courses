using System;

namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    Add(firstNumber, secondNumber);
                    break;
                case "multiply":
                    Multiply(firstNumber, secondNumber);
                    break;
                case "subtract":
                    Subtract(firstNumber, secondNumber);
                    break;
                case "divide":
                    Divide(firstNumber, secondNumber);
                    break;
            }
        }

        static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void Multiply(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }
        static void Subtract(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }

        static void Divide(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }
    }
}
