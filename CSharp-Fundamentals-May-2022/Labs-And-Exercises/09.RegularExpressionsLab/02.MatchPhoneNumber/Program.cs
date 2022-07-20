using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phoneNumbers = Console.ReadLine();

            string pattern = @"\+359([- ])2\1[0-9]{3}\1[0-9]{4}\b";
            Regex regex = new Regex(pattern);

            MatchCollection validPhoneNumbers = regex.Matches(phoneNumbers);

            Console.WriteLine(string.Join(", ", validPhoneNumbers));
        }
    }
}
