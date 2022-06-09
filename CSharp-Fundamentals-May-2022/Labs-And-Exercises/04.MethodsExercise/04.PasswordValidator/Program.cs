using System;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            CheckIfPasswordIsValid(password);
        }

        static void CheckIfPasswordIsValid(string password)
        {
            bool isValid = true;

            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    isValid = false;
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }

            int digitCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    digitCount++;
                }
            }

            if (digitCount < 2)
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

    }
}
