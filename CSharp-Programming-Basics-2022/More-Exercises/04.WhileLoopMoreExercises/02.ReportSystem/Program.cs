using System;

namespace _02.ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int estimatedProfit = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int profit = 0;
            int counter = 0;
            double creditCardSum = 0;
            int creditCardPayments = 0;
            double cashSum = 0;
            int cashPayments = 0;

            while (command != "End")
            {
                int price = int.Parse(command);
                counter++;

                if (counter % 2 == 0)
                {
                    if (price < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        profit += price;
                        creditCardSum += price;
                        creditCardPayments++;

                        Console.WriteLine("Product sold!");
                    }
                }
                else
                {
                    if (price > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        profit += price;
                        cashSum += price;
                        cashPayments++;

                        Console.WriteLine("Product sold!");
                    }

                }

                if (profit >= estimatedProfit)
                {
                    Console.WriteLine($"Average CS: {cashSum/cashPayments:f2}");
                    Console.WriteLine($"Average CC: {creditCardSum/creditCardPayments:f2}");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Failed to collect required money for charity.");
        }
    }
}
