using System;

namespace _07.FuelTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());

            if(fuel!="Diesel"&& fuel != "Gasoline" && fuel != "Gas")
            {
                Console.WriteLine("Invalid fuel!");
                return;
            }

            if (liters >= 25)
            {
                Console.WriteLine($"You have enough {fuel.ToLower()}.");
            }
            else
            {
                Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
            }
        }
    }
}
