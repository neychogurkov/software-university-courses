using System;

namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string decryptedMessage = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                char decryptedLetter = (char)(letter + key);
                decryptedMessage += decryptedLetter;
            }

            Console.WriteLine(decryptedMessage);
        }
    }
}
