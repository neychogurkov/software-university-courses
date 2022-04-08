using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double annualPercentageRate = double.Parse(Console.ReadLine());
            double sum = money + months * (money * annualPercentageRate/100) / 12;
            Console.WriteLine(sum);
        }
    }
}
