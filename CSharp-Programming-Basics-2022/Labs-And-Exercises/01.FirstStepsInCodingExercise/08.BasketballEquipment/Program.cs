using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualFee = int.Parse(Console.ReadLine());
            double trainersPrice = annualFee - 0.4 * annualFee;
            double kitPrice = trainersPrice - 0.2 * trainersPrice;
            double ballPrice = 0.25 * kitPrice;
            double accessoriesPrice = 0.2 * ballPrice;
            double totalExpenses = annualFee + trainersPrice + kitPrice + ballPrice + accessoriesPrice;
            Console.WriteLine(totalExpenses);
        }
    }
}
