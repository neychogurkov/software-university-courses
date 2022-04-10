using System;

namespace _01.FruitMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasQuantity = double.Parse(Console.ReadLine());
            double orangesQuantity = double.Parse(Console.ReadLine());
            double raspberriesQuantity = double.Parse(Console.ReadLine());
            double strawberriesQuantity = double.Parse(Console.ReadLine());

            double raspberriesPrice = 0.5 * strawberriesPrice;
            double orangesPrice = raspberriesPrice - 0.4 * raspberriesPrice;
            double bananasPrice = raspberriesPrice - 0.8 * raspberriesPrice;

            double totalPrice = strawberriesPrice * strawberriesQuantity + bananasPrice * bananasQuantity + orangesPrice * orangesQuantity + raspberriesPrice * raspberriesQuantity;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
