using System;
using System.Linq;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split(":|:");

                if (command[0] == "Reveal")
                {
                    break;
                }

                switch (command[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(command[1]);
                        message = message.Insert(index, " ");
                        break;
                    case "Reverse":
                        string substring = command[1];

                        if (message.Contains(substring))
                        {
                            message = message.Remove(message.IndexOf(substring), substring.Length);
                            message += new string(substring.Reverse().ToArray());
                        }
                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        string textToReplace = command[1];
                        string replacement = command[2];

                        message = message.Replace(textToReplace, replacement);
                        break;
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
