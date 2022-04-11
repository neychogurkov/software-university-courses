using System;

namespace _04.FoodForPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodQuantity = double.Parse(Console.ReadLine());
            double totalEatenBiscuits = 0;
            int totalDogFood = 0;
            int totalCatFood = 0;
            double totalFoodEaten = 0;

            for (int i = 1; i <= days; i++)
            {
                double foodEatenToday = 0;
                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());
                totalDogFood += dogFood;
                totalCatFood += catFood;
                foodEatenToday += dogFood + catFood;
                totalFoodEaten += foodEatenToday;

                if (i % 3 == 0)
                {
                    totalEatenBiscuits += 0.1 * foodEatenToday;
                }

            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(totalEatenBiscuits)}gr.");
            Console.WriteLine($"{totalFoodEaten/foodQuantity*100:f2}% of the food has been eaten.");
            Console.WriteLine($"{totalDogFood/totalFoodEaten*100:f2}% eaten from the dog.");
            Console.WriteLine($"{totalCatFood/totalFoodEaten*100:f2}% eaten from the cat.");
        }
    }
}
