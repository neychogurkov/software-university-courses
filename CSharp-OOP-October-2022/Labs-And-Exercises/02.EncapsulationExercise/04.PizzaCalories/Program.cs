using System;

namespace _04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string name = pizzaInfo[1];
                Pizza pizza = new Pizza(name);

                string[] doughInfo = Console.ReadLine().Split();
                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                int doughtWeight = int.Parse(doughInfo[3]);
                pizza.Dough = new Dough(flourType, bakingTechnique, doughtWeight);

                while (true)
                {
                    string[] toppingInfo = Console.ReadLine().Split();

                    if (toppingInfo[0] == "END")
                    {
                        break;
                    }

                    string ingredient = toppingInfo[0];
                    string type = toppingInfo[1];
                    int weight = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
