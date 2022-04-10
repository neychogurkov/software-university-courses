using System;

namespace _04.MovieStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double initialBudget = double.Parse(Console.ReadLine());
            double budget = initialBudget;
            string name = Console.ReadLine();

            while (name != "ACTION")
            {
                double salary = 0;
                if (name.Length <= 15)
                {
                    salary = double.Parse(Console.ReadLine());
                }
                else
                {
                    salary = 0.2 * budget;
                }

                if (budget-salary < 0)
                {
                    Console.WriteLine($"We need {Math.Abs(budget-salary):f2} leva for our actors.");
                    return;
                }
                budget -= salary;

                name = Console.ReadLine();
            }

            Console.WriteLine($"We are left with {budget:f2} leva.");
        }
    }
}
