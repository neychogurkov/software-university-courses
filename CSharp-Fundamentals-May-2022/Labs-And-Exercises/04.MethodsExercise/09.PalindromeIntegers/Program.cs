using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                int number = int.Parse(input);
                Console.WriteLine(CheckIfNumberIsPalindrome(number).ToString().ToLower());

                input = Console.ReadLine();
            }
        }

        static bool CheckIfNumberIsPalindrome(int number)
        {
            string reversedNumber = string.Empty;

            for (int i = number.ToString().Length - 1; i >= 0; i--)
            {
                reversedNumber += number.ToString()[i];
            }

            if (number == int.Parse(reversedNumber))
            {
                return true;
            }

            return false;
        }
    }
}
