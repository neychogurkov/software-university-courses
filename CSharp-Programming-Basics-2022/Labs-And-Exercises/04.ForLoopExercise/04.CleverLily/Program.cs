using System;

namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double laundryPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int toys = 0;
            int savedMoney = 0;
            int money = 10;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += money;
                    money += 10;
                    savedMoney--;
                }
                else
                {
                    toys++;
                }
            }
            savedMoney += toys * toyPrice;

            double diff = Math.Abs(savedMoney - laundryPrice);
            if (savedMoney >= laundryPrice)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
