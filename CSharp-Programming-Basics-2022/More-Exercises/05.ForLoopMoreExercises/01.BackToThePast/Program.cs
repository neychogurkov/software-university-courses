using System;

namespace _01.BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inheritedMoney = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            double moneySpent = 0;
            int age = 18;

            for (int i = 1800; i <= year; i++)
            {
                moneySpent += 12000;

                if (i % 2 != 0)
                {
                    moneySpent += 50 * age;
                }

                age++;
            }
            double diff = Math.Abs(inheritedMoney - moneySpent);

            if (inheritedMoney >= moneySpent)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {diff:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {diff:f2} dollars to survive.");
            }
        }
    }
}
