using System;

namespace _05.Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int totalFood = int.Parse(Console.ReadLine());
            double dogDailyFood = double.Parse(Console.ReadLine());
            double catDailyFood = double.Parse(Console.ReadLine());
            double tortoiseDailyFood = double.Parse(Console.ReadLine())/1000;

            double foodNeeded = days * (dogDailyFood + catDailyFood + tortoiseDailyFood);
            double diff = Math.Abs(totalFood - foodNeeded);

            if (totalFood >= foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(diff)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(diff)} more kilos of food are needed.");
            }
        }
    }
}
