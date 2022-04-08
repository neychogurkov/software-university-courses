using System;

namespace _04.InchesToCentimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberInInches = double.Parse(Console.ReadLine());
            double numberInCentimeters = numberInInches * 2.54;
            Console.WriteLine(numberInCentimeters);
        }
    }
}
