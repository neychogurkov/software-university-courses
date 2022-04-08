using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPassword = Console.ReadLine();
            string password = Console.ReadLine();

            while (password!=correctPassword)
            {
                password = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}