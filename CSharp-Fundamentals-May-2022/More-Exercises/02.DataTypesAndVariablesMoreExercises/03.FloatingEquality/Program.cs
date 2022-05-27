using System;

namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool areEqual = Math.Abs(firstNumber - secondNumber) < eps;

            Console.WriteLine(areEqual);
        }
    }
}
