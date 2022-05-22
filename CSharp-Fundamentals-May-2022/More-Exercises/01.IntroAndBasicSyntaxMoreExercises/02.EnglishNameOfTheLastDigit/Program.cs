using System;

namespace _02.EnglishNameOfTheLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int lastDigit = number % 10;
            Console.WriteLine(LastDigitName(lastDigit));
        }

        static string LastDigitName(int number)
        {
            switch (number)
            {
                case 1: 
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 0:
                    return "zero";
                default: return null;
            }
        }
    }
}
