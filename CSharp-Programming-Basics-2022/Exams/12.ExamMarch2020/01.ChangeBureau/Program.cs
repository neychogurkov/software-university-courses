using System;

namespace _01.ChangeBureau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double chineseYuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double money = (bitcoins * 1168 + chineseYuans * 0.15 * 1.76)/1.95;
            money -= commission / 100 * money;

            Console.WriteLine($"{money:f2}");
        }
    }
}
