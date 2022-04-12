using System;

namespace _01.AgencyProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string agencyName = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int childTickets = int.Parse(Console.ReadLine());
            double adultTicketNetPrice = double.Parse(Console.ReadLine());
            double additionalFee = double.Parse(Console.ReadLine());
            double childTicketNetPrice = adultTicketNetPrice - 0.7 * adultTicketNetPrice;
            adultTicketNetPrice += additionalFee;
            childTicketNetPrice += additionalFee;
            double totalProfit = adultTickets * adultTicketNetPrice + childTickets * childTicketNetPrice;

            double agencyProfit = 0.2 * totalProfit;
            Console.WriteLine($"The profit of your agency from {agencyName} tickets is {agencyProfit:f2} lv.");
        }
    }
}
