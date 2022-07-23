using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"@{6,10}|#{6,10}|\${6,10}|\^{6,10}";

            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    string leftHalf = ticket.Substring(0, 10);
                    string rightHalf = ticket.Substring(10);

                    Match leftMatch = Regex.Match(leftHalf, pattern);
                    Match rightMatch = Regex.Match(rightHalf, pattern);

                    string shorterMatch = leftMatch.Value;

                    if (rightMatch.Value.Length < shorterMatch.Length)
                    {
                        shorterMatch = rightMatch.Value;
                    }

                    if (leftMatch.Success && rightMatch.Success)
                    {
                        if (shorterMatch.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {shorterMatch.Length}{shorterMatch[0]} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {shorterMatch.Length}{shorterMatch[0]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
