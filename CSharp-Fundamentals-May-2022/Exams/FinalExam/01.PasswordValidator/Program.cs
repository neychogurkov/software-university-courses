using System;
using System.Linq;
using System.Text;

namespace _01.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder password = new StringBuilder(input);

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Complete")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Make":
                        if (command[1] == "Upper")
                        {
                            MakeUpper(command, password);
                        }
                        else if (command[1] == "Lower")
                        {
                            MakeLower(command, password);
                        }
                        break;
                    case "Insert":
                        Insert(command, password);
                        break;
                    case "Replace":
                        Replace(command, password);
                        break;
                    case "Validation":
                        Validation(password);
                        break;
                }
            }
        }

        private static void MakeUpper(string[] command, StringBuilder password)
        {
            int index = int.Parse(command[2]);
            password[index] = char.Parse(password[index].ToString().ToUpper());

            Console.WriteLine(password);
        }

        private static void MakeLower(string[] command, StringBuilder password)
        {
            int index = int.Parse(command[2]);
            password[index] = char.Parse(password[index].ToString().ToLower());

            Console.WriteLine(password);

        }

        private static void Insert(string[] command, StringBuilder password)
        {
            int index = int.Parse(command[1]);
            char character = char.Parse(command[2]);

            if (index >= 0 && index < password.Length)
            {
                password.Insert(index, character);
            }

            Console.WriteLine(password);
        }

        private static void Replace(string[] command, StringBuilder password)
        {
            char character = char.Parse(command[1]);
            int value = int.Parse(command[2]);

            if (password.ToString().Contains(character))
            {
                int totalValue = value + character;

                password.Replace(character, (char)totalValue);
            }

            Console.WriteLine(password);
        }

        private static void Validation(StringBuilder password)
        {
            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long!");
            }

            if (password.ToString().Any(ch => !char.IsLetterOrDigit(ch) && ch != '_'))
            {
                Console.WriteLine("Password must consist only of letters, digits and _!");
            }

            if (password.ToString().Where(char.IsLetter).Where(ch => ch == char.Parse(ch.ToString().ToUpper())).ToArray().Length == 0)
            {
                Console.WriteLine("Password must consist at least one uppercase letter!");
            }

            if (password.ToString().Where(char.IsLetter).Where(ch => ch == char.Parse(ch.ToString().ToLower())).ToArray().Length == 0)
            {
                Console.WriteLine("Password must consist at least one lowercase letter!");
            }

            if (password.ToString().Where(char.IsDigit).ToArray().Length == 0)
            {
                Console.WriteLine("Password must consist at least one digit!");
            }
        }
    }
}
