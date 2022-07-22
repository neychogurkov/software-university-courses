using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\s\b[A-Za-z\d][\w.-]*[A-Za-z\d]@[A-Za-z-]+\.[A-Za-z.-]*[A-Za-z]";

            string input = Console.ReadLine();

            MatchCollection validEmails = Regex.Matches(input, pattern);

            foreach (Match validEmail in validEmails)
            {
                Console.WriteLine(validEmail.Value.TrimStart());
            }
        }
    }
}
