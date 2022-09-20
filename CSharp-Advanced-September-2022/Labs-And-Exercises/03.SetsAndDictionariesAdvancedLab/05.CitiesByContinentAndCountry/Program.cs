using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> citiesByCountryAndContinent = new Dictionary<string, Dictionary<string, List<string>>>();

            int citiesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < citiesCount; i++)
            {
                string[] cityInfo = Console.ReadLine().Split();

                AddCity(citiesByCountryAndContinent, cityInfo);
            }

            PrintCities(citiesByCountryAndContinent);
        }

        static void AddCity(Dictionary<string, Dictionary<string, List<string>>> citiesByCountryAndContinent, string[] cityInfo)
        {
            string continent = cityInfo[0];
            string country = cityInfo[1];
            string city = cityInfo[2];

            if (!citiesByCountryAndContinent.ContainsKey(continent))
            {
                citiesByCountryAndContinent[continent] = new Dictionary<string, List<string>>();
            }

            if (!citiesByCountryAndContinent[continent].ContainsKey(country))
            {
                citiesByCountryAndContinent[continent][country] = new List<string>();
            }

            citiesByCountryAndContinent[continent][country].Add(city);
        }

        static void PrintCities(Dictionary<string, Dictionary<string, List<string>>> citiesByCountryAndContinent)
        {
            foreach (var (continent, citiesByCountry) in citiesByCountryAndContinent)
            {
                Console.WriteLine(continent + ":");

                foreach (var (country, cities) in citiesByCountry)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
