using System;
using System.Linq;

namespace _05.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMultiplicationSign(num1, num2, num3));
        }

        static string GetMultiplicationSign(int num1, int num2, int num3)
        {
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                return "zero";
            }

            int negativeNumbers = new int[] { num1, num2, num3 }.Count(n => n < 0);

            if (negativeNumbers % 2 != 0)
            {
                return "negative";
            }

            return "positive";
        }
    }
}
