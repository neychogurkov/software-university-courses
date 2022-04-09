using System;

namespace _01.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualFee = int.Parse(Console.ReadLine());
            double sneakersPrice = annualFee - 0.4 * annualFee;
            double kitPrice = sneakersPrice - 0.2 * sneakersPrice;
            double ballPrice = 0.25 * kitPrice;
            double accessories = 0.2 * ballPrice;
            double totalPrice = annualFee + sneakersPrice + kitPrice + ballPrice + accessories;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
