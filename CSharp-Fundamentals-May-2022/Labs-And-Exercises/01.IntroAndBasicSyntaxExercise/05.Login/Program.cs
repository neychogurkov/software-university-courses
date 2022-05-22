using System;
using System.Text;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            StringBuilder password = new StringBuilder(username);
            for (int i = 0; i < password.Length / 2; i++)
            {
                char swap = password[i];
                password[i] = password[password.Length - i - 1];
                password[password.Length - i - 1] = swap;
            }
            string input = Console.ReadLine();
            int incorrectPasswords = 0;
            while (input!=password.ToString())
            {
                incorrectPasswords++;
                if (incorrectPasswords == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");

                input = Console.ReadLine();
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
