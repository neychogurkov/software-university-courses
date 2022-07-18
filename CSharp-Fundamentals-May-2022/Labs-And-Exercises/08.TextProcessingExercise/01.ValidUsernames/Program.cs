using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (CheckIfUsernameIsValid(username))
                {
                    validUsernames.Add(username);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }

        static bool CheckIfUsernameIsValid(string username)
        {
            if (username.Length < 3 || username.Length > 16 || username.Any(ch => !(char.IsLetterOrDigit(ch) || ch == '-' || ch == '_')))
            {
                return false;
            }

            return true;
        }
    }
}
