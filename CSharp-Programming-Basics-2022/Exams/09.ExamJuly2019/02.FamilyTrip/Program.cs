using System;

namespace _02.FamilyTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int overnights = int.Parse(Console.ReadLine());
            double overnightPrice = double.Parse(Console.ReadLine());
            double otherExpensesPercentage = double.Parse(Console.ReadLine());

            if (overnights > 7)
            {
                overnightPrice -= overnightPrice * 0.05;
            }

            double totalPrice = overnightPrice * overnights + otherExpensesPercentage/100 * budget;
            double diff = Math.Abs(totalPrice - budget);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Ivanovi will be left with {diff:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{diff:f2} leva needed.");
            }
        }
    }
}
