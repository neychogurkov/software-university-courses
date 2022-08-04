using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Done")
                {
                    break;
                }

                switch (command[0])
                {
                    case "TakeOdd":
                        for (int i = 0; i < password.Length; i+=2)
                        {
                            password = password.Remove(i, 1);
                            i--;
                        }
                        break;
                    case "Cut":
                        int index = int.Parse(command[1]);
                        int length = int.Parse(command[2]);

                        password = password.Remove(index, length);
                        break;
                    case "Substitute":
                        string substring = command[1];
                        string substitute = command[2];

                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                        }
                        else
                        {
                            Console.WriteLine($"Nothing to replace!");
                            continue;
                        }
                        break;
                }

                Console.WriteLine(password);
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
