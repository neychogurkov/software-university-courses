using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int consecutiveSpendingDays = 0;

            while (currentMoney < excursionPrice)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                days++;

                if (action == "spend")
                {
                    consecutiveSpendingDays++;
                    if (money > currentMoney)
                    {
                        currentMoney = 0;
                    }
                    else
                    {
                        currentMoney -= money;
                    }
                }
                else if (action == "save")
                {
                    consecutiveSpendingDays = 0;
                    currentMoney += money;
                }

                if (consecutiveSpendingDays == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    return;
                }
            }

            Console.WriteLine($"You saved the money for {days} days.");
        }
    }
}
