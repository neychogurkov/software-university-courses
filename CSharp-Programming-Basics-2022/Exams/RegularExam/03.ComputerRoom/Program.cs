using System;

namespace _03.ComputerRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0;

            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (timeOfDay == "day")
                    {
                        price = 10.5;
                    }
                    else if (timeOfDay == "night")
                    {
                        price = 8.4;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (timeOfDay == "day")
                    {
                        price = 12.6;
                    }
                    else if (timeOfDay == "night")
                    {
                        price = 10.2;
                    }
                    break;
            }

            if (people >= 4)
            {
                price -= 0.1 * price;
            }
            if (hours >= 5)
            {
                price -= 0.5 * price;
            }

            Console.WriteLine($"Price per person for one hour: {price:f2}");
            Console.WriteLine($"Total cost of the visit: {price * hours * people:f2}");
        }
    }
}
