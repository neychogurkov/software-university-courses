using System;

namespace _03.CoffeeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int drinks = int.Parse(Console.ReadLine());
            double price = 0;

            if (drink == "Espresso")
            {
                if (sugar == "Without")
                {
                    price = 0.9;
                }
                else if (sugar == "Normal")
                {
                    price = 1;
                }
                else if (sugar == "Extra")
                {
                    price = 1.2;
                }
            }
            else if (drink == "Cappuccino")
            {
                if (sugar == "Without")
                {
                    price = 1;
                }
                else if (sugar == "Normal")
                {
                    price = 1.2;
                }
                else if (sugar == "Extra")
                {
                    price = 1.6;
                }
            }
            else if (drink == "Tea")
            {
                if (sugar == "Without")
                {
                    price = 0.5;
                }
                else if (sugar == "Normal")
                {
                    price = 0.6;
                }
                else if (sugar == "Extra")
                {
                    price = 0.7;
                }
            }
            price *= drinks;

            if (sugar == "Without")
            {
                price -= 0.35 * price;
            }

            if (drink == "Espresso" && drinks >= 5)
            {
                price -= 0.25 * price;
            }

            if (price > 15)
            {
                price -= 0.2 * price;
            }

            Console.WriteLine($"You bought {drinks} cups of {drink} for {price:f2} lv.");


        }
    }
}
