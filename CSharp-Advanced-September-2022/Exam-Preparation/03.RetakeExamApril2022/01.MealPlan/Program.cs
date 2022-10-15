using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> dailyCalories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int initialMealsCount = meals.Count;

            Dictionary<string, int> caloriesByMeal = new Dictionary<string, int>()
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790},
            };

            while (meals.Any() && dailyCalories.Any())
            {
                string currentMeal = meals.Dequeue();
                int currentCalories = dailyCalories.Pop();
                int caloriesLeft = currentCalories - caloriesByMeal[currentMeal];

                if (caloriesLeft > 0)
                {
                    dailyCalories.Push(currentCalories - caloriesByMeal[currentMeal]);
                }
                else
                {
                    if (dailyCalories.Any())
                    {
                        dailyCalories.Push(dailyCalories.Pop() + caloriesLeft);
                    }
                }
            }

            int mealsEaten = initialMealsCount - meals.Count;

            if (!meals.Any())
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
