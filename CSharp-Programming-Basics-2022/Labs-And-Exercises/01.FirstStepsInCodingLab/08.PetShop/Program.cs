using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFoodQuantity = int.Parse(Console.ReadLine());
            int catFoodQuantity = int.Parse(Console.ReadLine());
            double totalPrice = catFoodQuantity * 4 + dogFoodQuantity * 2.5;
            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
