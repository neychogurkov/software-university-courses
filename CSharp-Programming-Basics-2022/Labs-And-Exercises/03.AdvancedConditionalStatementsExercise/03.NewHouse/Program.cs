using System;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowersQuantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;

            switch (flowerType)
            {
                case "Roses":
                    {
                        price = 5 * flowersQuantity;
                        if (flowersQuantity > 80)
                        {
                            price -= price * 0.1;
                        }
                    }
                    break;
                case "Dahlias":
                    {
                        price = 3.8 * flowersQuantity;
                        if (flowersQuantity > 90)
                        {
                            price -= price * 0.15;
                        }
                    }
                    break;
                case "Tulips":
                    {
                        price = 2.8 * flowersQuantity;
                        if (flowersQuantity > 80)
                        {
                            price -= price * 0.15;
                        }
                    }
                    break;
                case "Narcissus":
                    {
                        price = 3 * flowersQuantity;
                        if (flowersQuantity < 120)
                        {
                            price += price * 0.15;
                        }
                    }
                    break;
                case "Gladiolus":
                    {
                        price = 2.5 * flowersQuantity;
                        if (flowersQuantity < 80)
                        {
                            price += price * 0.2;
                        }
                    }
                    break;
            }

            double diff = Math.Abs(budget - price);
            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersQuantity} {flowerType} and {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {diff:f2} leva more.");
            }
        }
    }
}
