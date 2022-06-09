using System;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(GetSubtraction(firstNumber, secondNumber, thirdNumber));

        }

        static int GetSum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static int GetSubtraction(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GetSum(firstNumber, secondNumber) - thirdNumber;
        }
    }
}
