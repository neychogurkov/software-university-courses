using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furnitureName>[A-Za-z]+)<<(?<price>[0-9]+.?[0-9]*?)!(?<quantity>[0-9]+)";

            string input = Console.ReadLine();

            List<string> furnitureBought = new List<string>();
            double totalPrice = 0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string furnitureName = match.Groups["furnitureName"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furnitureBought.Add(furnitureName);
                    totalPrice += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            foreach (var furniture in furnitureBought)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
