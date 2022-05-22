using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;

            if (groupType == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46;
                }
                price *= people;

                if (people >= 30)
                {
                    price -= 0.15 * price;
                }
            }
            else if (groupType == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 10.9;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.6;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }

                if (people >= 100)
                {
                    people -= 10;
                }
                price *= people;
            }
            else if (groupType == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.5;
                }
                price *= people;

                if (people >= 10 && people <= 20)
                {
                    price -= 0.05 * price;
                }
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
