using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string locations = Console.ReadLine();

            string pattern = @"([=\/])(?<location>[A-Z][A-Za-z]{2,})\1";

            MatchCollection validLocations = Regex.Matches(locations, pattern);

            int travelPoints = validLocations.Sum(l => l.Groups["location"].Value.Length);

            string[] destinations = validLocations.Select(l => l.Groups["location"].Value).ToArray();

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
