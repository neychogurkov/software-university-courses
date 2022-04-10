using System;

namespace _06.EasterDecoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int customers = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 0; i < customers; i++)
            {
                double price = 0;
                int productsPurchased = 0;
                string purchase = Console.ReadLine();

                while (purchase != "Finish")
                {
                    productsPurchased++;

                    if (purchase == "basket")
                    {
                        price += 1.50;
                    }
                    else if (purchase == "wreath")
                    {
                        price += 3.8;
                    }
                    else if (purchase == "chocolate bunny")
                    {
                        price += 7;
                    }

                    purchase = Console.ReadLine();
                }

                if (productsPurchased % 2 == 0)
                {
                    price -= price * 0.2;
                }
                totalPrice += price;

                Console.WriteLine($"You purchased {productsPurchased} items for {price:f2} leva.");
            }

            Console.WriteLine($"Average bill per client is: {totalPrice / customers:f2} leva.");
        }
    }
}
