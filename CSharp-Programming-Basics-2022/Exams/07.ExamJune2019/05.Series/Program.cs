using System;

namespace _05.Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int seriesCount = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 0; i < seriesCount; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                switch (name)
                {
                    case "Thrones":
                        price /= 2;
                        break;
                    case "Lucifer":
                        price -= 0.4 * price;
                        break;
                    case "Protector":
                        price -= 0.3 * price;
                        break;
                    case "TotalDrama":
                        price -= 0.2 * price;
                        break;
                    case "Area":
                        price -= 0.1 * price;
                        break;
                }

                totalPrice += price;
            }

            double diff = Math.Abs(budget - totalPrice);
            if (totalPrice <= budget)
            {
                Console.WriteLine($"You bought all the series and left with {diff:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {diff:f2} lv. more to buy the series!");
            }
        }
    }
}
