using System;

namespace _09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());
            double totalPrice = squareMeters * 7.61;
            double discount = totalPrice * 0.18;
            totalPrice -= discount;
            Console.WriteLine($"The final price is: {totalPrice} lv."); 
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
