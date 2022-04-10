using System;

namespace _03.MobileOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string duration = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileData = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double price = 0;

            if (duration == "one")
            {
                switch (contractType)
                {
                    case "Small":
                        price = 9.98;
                        break;
                    case "Middle":
                        price = 18.99;
                        break;
                    case "Large":
                        price = 25.98;
                        break;
                    case "ExtraLarge":
                        price = 35.99;
                        break;
                }
            }
            else if (duration == "two")
            {
                switch (contractType)
                {
                    case "Small":
                        price = 8.58;
                        break;
                    case "Middle":
                        price = 17.09;
                        break;
                    case "Large":
                        price = 23.59;
                        break;
                    case "ExtraLarge":
                        price = 31.79;
                        break;
                }
            }

            if (mobileData == "yes")
            {
                if (price <= 10)
                {
                    price += 5.5;
                }
                else if (price <= 30)
                {
                    price += 4.35;
                }
                else
                {
                    price += 3.85;
                }
            }

            if (duration == "two")
            {
                price -= 0.0375 * price;
            }

            price *= months;
            Console.WriteLine($"{price:f2} lv.");

        }
    }
}
