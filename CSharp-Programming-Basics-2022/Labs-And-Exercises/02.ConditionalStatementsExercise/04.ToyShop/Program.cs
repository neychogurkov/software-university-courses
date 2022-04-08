using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            double income = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
            if (puzzles + dolls + bears + minions + trucks >= 50)
            {
                income -= 0.25 * income;
            }
            income -= 0.1 * income;
            if (excursionPrice <= income)
            {
                Console.WriteLine($"Yes! {income-excursionPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {excursionPrice-income:f2} lv needed.");
            }
        }
    }
}
