using System;

namespace _01.MovieProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int percentage = int.Parse(Console.ReadLine());

            double profit = days * tickets * ticketPrice;
            profit -= profit * ((double)percentage / 100);

            Console.WriteLine($"The profit from the movie {movieName} is {profit:f2} lv.");
        }
    }
}
