using System;

namespace _03.EnergyBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int sets = int.Parse(Console.ReadLine());
            double price = 0;

            if(size == "small")
            {
                switch (fruit)
                {
                    case "Watermelon":
                        price = 56;
                        break;
                    case "Mango":
                        price = 36.66;
                        break;
                    case "Pineapple":
                        price = 42.1;
                        break;
                    case "Raspberry":
                        price = 20;
                        break;
                }

                price *= 2;
            }
            else if (size == "big")
            {
                switch (fruit)
                {
                    case "Watermelon":
                        price = 28.7;
                        break;
                    case "Mango":
                        price = 19.6;
                        break;
                    case "Pineapple":
                        price = 24.8;
                        break;
                    case "Raspberry":
                        price = 15.2;
                        break;
                }

                price *= 5;
            }

            price *= sets;

            if (price >= 400 && price <= 1000)
            {
                price -= price * 0.15;
            }
            else if (price > 1000)
            {
                price /= 2;
            }

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
