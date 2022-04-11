using System;

namespace _04.Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double incomeGoal = double.Parse(Console.ReadLine());
            string cocktailName = Console.ReadLine();
            double clubIncome = 0;

            while (cocktailName != "Party!")
            {
                int cocktails = int.Parse(Console.ReadLine());
                double price = cocktails * cocktailName.Length;

                if (price % 2 != 0)
                {
                    price -= 0.25 * price;
                }
                clubIncome += price;

                if (clubIncome >= incomeGoal)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {clubIncome:f2} leva.");
                    return;
                }

                cocktailName = Console.ReadLine();
            }

            Console.WriteLine($"We need {incomeGoal-clubIncome:f2} leva more.");
            Console.WriteLine($"Club income - {clubIncome:f2} leva.");
        }
    }
}
