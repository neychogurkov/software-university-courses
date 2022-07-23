using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace _04.SantasSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*?!(?<behaviour>[G|N])!";

            List<string> goodChildren = new List<string>();

            while (true)
            {
                string message = Console.ReadLine();

                if (message == "end")
                {
                    break;
                }

                StringBuilder decryptedMessage = new StringBuilder();

                foreach (var character in message)
                {
                    decryptedMessage.Append((char)(character - key));
                }

                Match match = Regex.Match(decryptedMessage.ToString(), pattern);

                if (match.Success)
                {
                    string childName = match.Groups["name"].Value;
                    string childBehaviour = match.Groups["behaviour"].Value;

                    if (childBehaviour == "G")
                    {
                        goodChildren.Add(childName);
                    }
                }
            }

            foreach (var child in goodChildren)
            {
                Console.WriteLine(child);
            }
        }
    }
}
