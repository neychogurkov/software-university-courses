using System;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split('|');

                if (command[0] == "Decode")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Move":
                        int count = int.Parse(command[1]);
                        message += message.Substring(0, count);
                        message = message.Remove(0, count);
                        break;
                    case "Insert":
                        int index = int.Parse(command[1]);
                        string value = command[2];
                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string textToReplace = command[1];
                        string replacement = command[2];
                        message = message.Replace(textToReplace, replacement);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
