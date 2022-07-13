using System;
using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder encryptedText = new StringBuilder();

            foreach (var character in text)
            {
                encryptedText.Append((char)(character + 3));
            }

            Console.WriteLine(encryptedText);
        }
    }
}
