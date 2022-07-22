using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonsNames = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string healthPattern = @"[^\d\+\-\*\/.]";
            string damagePattern = @"\-?\d+\.?\d*";

            SortedDictionary<string, Demon> demons = new SortedDictionary<string, Demon>();

            foreach (var demonName in demonsNames)
            {
                demons[demonName] = new Demon();

                MatchCollection healthMatches = Regex.Matches(demonName, healthPattern);
                MatchCollection damageMatches = Regex.Matches(demonName, damagePattern);

                foreach (Match match in healthMatches)
                {
                    demons[demonName].Health += char.Parse(match.Value);
                }

                foreach (Match match in damageMatches)
                {
                    if (match.Value[0] == '-')
                    {
                        demons[demonName].Damage -= double.Parse(match.Value.Substring(1));
                    }
                    else
                    {
                        demons[demonName].Damage += double.Parse(match.Value);
                    }
                }

                foreach (var character in demonName)
                {
                    if (character == '*')
                    {
                        demons[demonName].Damage *= 2;
                    }
                    else if (character == '/')
                    {
                        demons[demonName].Damage /= 2;
                    }
                }
            }

            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Health} health, {demon.Value.Damage:f2} damage");
            }
        }
    }

    class Demon
    {
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}
