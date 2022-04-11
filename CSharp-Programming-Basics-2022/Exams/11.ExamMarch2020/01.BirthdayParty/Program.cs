using System;

namespace _01.BirthdayParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cakePrice = 0.2 * rent;
            double drinksPrice = cakePrice - 0.45 * cakePrice;
            double animatorPrice = rent / 3;
            double totalPrice = rent + cakePrice + drinksPrice + animatorPrice;

            Console.WriteLine(totalPrice);
        }
    }
}
