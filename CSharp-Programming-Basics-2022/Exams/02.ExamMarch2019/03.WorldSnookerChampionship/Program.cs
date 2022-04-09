using System;

namespace _03.WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            char photo = char.Parse(Console.ReadLine());
            double price = 0;

            if (ticketType == "Standard")
            {
                if(stage=="Quarter final")
                {
                    price = 55.5;
                }
                else if (stage == "Semi final")
                {
                    price = 75.88;
                }
                else if (stage == "Final")
                {
                    price = 110.1;
                }
            }
            else if (ticketType == "Premium")
            {
                if (stage == "Quarter final")
                {
                    price = 105.2;
                }
                else if (stage == "Semi final")
                {
                    price = 125.22;
                }
                else if (stage == "Final")
                {
                    price = 160.66;
                }
            }
            else if (ticketType == "VIP")
            {
                if (stage == "Quarter final")
                {
                    price = 118.9;
                }
                else if (stage == "Semi final")
                {
                    price = 300.4;
                }
                else if (stage == "Final")
                {
                    price = 400;
                }
            }

            price *= tickets;

            if (price > 4000)
            {
                price -= 0.25 * price;
            }
            else if (price > 2500)
            {
                price -= 0.1 * price;

                if (photo == 'Y')
                {
                    price += tickets * 40;
                }
            }
            else
            {
                if (photo == 'Y')
                {
                    price += tickets * 40;
                }
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
