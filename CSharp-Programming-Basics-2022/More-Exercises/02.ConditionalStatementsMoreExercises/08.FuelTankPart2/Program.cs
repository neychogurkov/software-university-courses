using System;

namespace _08.FuelTankPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelQuantity = double.Parse(Console.ReadLine());
            string discountCard = Console.ReadLine();
            double price = 0;

            if (fuelType == "Gasoline")
            {
                price = 2.22;

                if (discountCard == "Yes")
                {
                    price -= 0.18;
                }
            }
            else if (fuelType == "Diesel")
            {
                price = 2.33;

                if (discountCard == "Yes")
                {
                    price -= 0.12;
                }
            }
            else if (fuelType == "Gas")
            {
                price = 0.93;

                if (discountCard == "Yes")
                {
                    price -= 0.08;
                }
            }

            price *= fuelQuantity;

            if (fuelQuantity >= 20 && fuelQuantity <= 25)
            {
                price -= 0.08 * price;
            }
            else if (fuelQuantity > 25)
            {
                price -= 0.1 * price;
            }

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
