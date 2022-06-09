using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double firstNumberFactorial = GetFactorial(firstNumber);
            double secondNumberFactorial = GetFactorial(secondNumber);
            double factorialsDivision = firstNumberFactorial / secondNumberFactorial;
            Console.WriteLine($"{factorialsDivision:f2}");
        }

        static double GetFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
