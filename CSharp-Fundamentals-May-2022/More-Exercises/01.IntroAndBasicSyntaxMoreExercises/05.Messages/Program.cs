using System;

namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                string str = number.ToString();
                if (number == 0)
                {
                    message += " ";
                    continue;
                }

                int digitCount = str.Length;
                int mainDigit = number % 10;
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digitCount - 1;
                char letter = (char)letterIndex;
                letter += 'a';
                message += letter;
            }
            Console.WriteLine(message);

        }
    }
}
