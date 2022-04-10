using System;

namespace _03.FilmPremiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string film = Console.ReadLine();
            string packet = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            double price = 0;

            if (film == "John Wick")
            {
                if (packet == "Drink")
                {
                    price = 12;
                }
                else if (packet == "Popcorn")
                {
                    price = 15;
                }
                else if (packet == "Menu")
                {
                    price = 19;
                }
            }
            else if (film == "Star Wars")
            {
                if (packet == "Drink")
                {
                    price = 18;
                }
                else if (packet == "Popcorn")
                {
                    price = 25;
                }
                else if (packet == "Menu")
                {
                    price = 30;
                }
            }
            else if (film == "Jumanji")
            {
                if (packet == "Drink")
                {
                    price = 9;
                }
                else if (packet == "Popcorn")
                {
                    price = 11;
                }
                else if (packet == "Menu")
                {
                    price = 14;
                }
            }

            price *= tickets;

            if (film == "Star Wars" && tickets >= 4)
            {
                price -= 0.3 * price;
            }
            else if (film == "Jumanji" && tickets == 2)
            {
                price -= 0.15 * price;
            }

            Console.WriteLine($"Your bill is {price:f2} leva.");
        }
    }
}
