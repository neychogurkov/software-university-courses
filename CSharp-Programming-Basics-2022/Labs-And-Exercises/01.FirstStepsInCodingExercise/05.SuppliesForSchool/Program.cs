using System;

namespace _05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int liters = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine()) / 100;
            double totalPrice = pens * 5.8 + markers * 7.2 + liters * 1.2;
            totalPrice -= totalPrice * discount;
            Console.WriteLine(totalPrice);
        }
    }
}
