using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string starPattern = @"[STARstar]";
            string planetPattern = @"^[^-@!:>]*?@(?<planetName>[A-Za-z]+)[^-@!:>]*?:(?<population>\d+)[^-@!:>]*?!(?<attackType>[A|D])![^-@!:>]*?->(?<soldierCount>\d+)[^-@!:>]*?$";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int messagesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messagesCount; i++)
            {
                string message = Console.ReadLine();
                int decryptionKey = Regex.Matches(message, starPattern).Count;

                StringBuilder decryptedMessage = new StringBuilder();

                foreach (var character in message)
                {
                    decryptedMessage.Append((char)(character - decryptionKey));
                }

                Match match = Regex.Match(decryptedMessage.ToString(), planetPattern);

                if (match.Success)
                {
                    string planetName = match.Groups["planetName"].Value;
                    char attackType = char.Parse(match.Groups["attackType"].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var planet in attackedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
