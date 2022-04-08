using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chikens = int.Parse(Console.ReadLine());
            int fishes = int.Parse(Console.ReadLine());
            int vegetarian = int.Parse(Console.ReadLine());
            double totalPrice = chikens * 10.35 + fishes * 12.4 + vegetarian * 8.15;
            totalPrice += totalPrice * 0.2;
            totalPrice += 2.5;
            Console.WriteLine(totalPrice);
        }
    }
}
