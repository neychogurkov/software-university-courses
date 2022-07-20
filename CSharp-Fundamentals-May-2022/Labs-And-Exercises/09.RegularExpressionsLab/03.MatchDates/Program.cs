using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();

            string pattern = @"(?<day>\d{2})(?<separator>[-\/.])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})";
            Regex regex = new Regex(pattern);

            MatchCollection validDates = regex.Matches(dates);

            foreach (Match validDate in validDates)
            {
                Console.WriteLine($"Day: {validDate.Groups["day"]}, Month: {validDate.Groups["month"]}, Year: {validDate.Groups["year"]}");
            }
        }
    }
}
