using System;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSmallestNumber(firstNumber, secondNumber, thirdNumber));
        }

        static int GetSmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
            {
                return firstNumber;
            }
            else if (secondNumber <= firstNumber && secondNumber <= thirdNumber)
            {
                return secondNumber;
            }
            else
            {
                return thirdNumber;
            }
        }
    }
}
