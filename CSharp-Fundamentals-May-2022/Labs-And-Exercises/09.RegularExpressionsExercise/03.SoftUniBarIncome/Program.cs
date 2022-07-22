using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customerName>[A-Z][a-z]+)%[^|\$%.]*?<(?<product>\w+)>[^|\$%.]*?\|(?<count>\d+)\|[^|\$%.]*?(?<price>\d+\.?\d+?)\$";

            string order = Console.ReadLine();

            double totalIncome = 0;

            while (order != "end of shift")
            {
                Match match = Regex.Match(order, pattern);

                if (match.Success)
                {
                    string customerName = match.Groups["customerName"].Value;
                    string product = match.Groups["product"].Value;
                    double totalPrice = double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["count"].Value);
                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
                }

                order = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
