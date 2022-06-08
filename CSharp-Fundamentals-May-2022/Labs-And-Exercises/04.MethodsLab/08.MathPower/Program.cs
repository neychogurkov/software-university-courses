using System;

namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(PowerNumber(baseNumber, power));
        }
        
        static double PowerNumber(double baseNumber, double power)
        {
            double poweredNumber = 1;
            for (int i = 0; i < power; i++)
            {
                poweredNumber *= baseNumber;
            }
            return poweredNumber;
        }
    }
}
