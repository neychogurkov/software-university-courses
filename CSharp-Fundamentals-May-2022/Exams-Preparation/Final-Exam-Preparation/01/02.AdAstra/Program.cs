using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([|#])(?<name>[A-Za-z\s]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";

            MatchCollection matches = Regex.Matches(text, pattern);

            int totalCalories = matches.Sum(m => int.Parse(m.Groups["calories"].Value));

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");

            foreach (Match match in matches)
            {
                string itemName = match.Groups["name"].Value;
                string expirationDate = match.Groups["expirationDate"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {calories}");
            }
        }
    }
}
