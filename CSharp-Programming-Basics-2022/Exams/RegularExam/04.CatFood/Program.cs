using System;

namespace _04.CatFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cats = int.Parse(Console.ReadLine());
            int firstGroup = 0;
            int secondGroup = 0;
            int thirdGroup = 0;
            double totalFood = 0;

            for (int i = 0; i < cats; i++)
            {
                double food = double.Parse(Console.ReadLine());
                totalFood += food;
                
                if (food >= 100 && food < 200)
                {
                    firstGroup++;
                }
                else if (food >= 200 && food < 300)
                {
                    secondGroup++;
                }
                else
                {
                    thirdGroup++;
                }
            }

            totalFood /= 1000;
            double price = totalFood * 12.45;

            Console.WriteLine($"Group 1: {firstGroup} cats.");
            Console.WriteLine($"Group 2: {secondGroup} cats.");
            Console.WriteLine($"Group 3: {thirdGroup} cats.");
            Console.WriteLine($"Price for food per day: {price:f2} lv.");
        }
    }
}
